using KronosDMS.Objects;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS.Files
{
    public class PartsFile
    {
        public Dictionary<string, Part> Parts { get; set; } = new Dictionary<string, Part>();

        public int MAX_RESULTS = 100;

        public PartsFile()
        {
            if (File.Exists(@"data/Parts.json"))
                Parts = JsonConvert.DeserializeObject<Dictionary<string, Part>>(File.ReadAllText(@"data/Parts.json"));
            if (Parts is null)
                Parts = new Dictionary<string, Part>();
        }

        public bool Add(string json)
        {
            try
            {
                return Add(JsonConvert.DeserializeObject<Part>(json));
            }
            catch { return false; }
        }

        public bool Add(string make, string number, string description)
        {
            Part part = new Part(make, number, description);
            return Add(part);
        }

        public bool Add(Part part)
        {
            part.Number = part.Number.Replace(" ", "").ToUpper();

            // Check if the part already exists
            if (Parts.ContainsKey(part.Number))
                return false;

            Parts.Add(part.Number, part);
            Write();

            Logger.Log("Added a new part to file", LogLevel.INFO,
                $"Make: {part.Make}\n" +
                $"Number: {part.Number}\n" +
                $"Description: {part.Description}");
            return true;
        }

        public bool Remove(string id)
        {
            if (!Parts.ContainsKey(id))
                return false;
            Logger.Log("Removed part from file", LogLevel.INFO, $"Number: {id}");
            Parts.Remove(id);
            Write();
            return true;
        }

        public bool Set(string json)
        {
            Part part;
            try
            {
                part = JsonConvert.DeserializeObject<Part>(json);
            }
            catch { return false; }

            // Check if the part does not exist
            if (!Parts.ContainsKey(part.Number))
                return false;

            Logger.Log("Modified part on file", LogLevel.INFO, $"Number: {part.Number}");
            Parts[part.Number] = part;
            Write();
            return true;
        }

        public string Search(string make, string number, string description, string id = "")
        {
            Dictionary<string, Part> result = new Dictionary<string, Part>();

            if (id != "")
            {
                if (Parts.ContainsKey(id))
                    result.Add(id, Parts[id]);
                return JsonConvert.SerializeObject(result);
            }

            int numResults = 0;
            foreach (KeyValuePair<string, Part> part in Parts)
            {
                Part p = part.Value;
                if (p.Make.ToUpper().Contains(make.ToUpper()) &&
                    p.Number.ToUpper().Contains(number.ToUpper()) &&
                    p.Description.ToUpper().Contains(description.ToUpper()))
                {
                    result.Add(part.Key, part.Value);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(Parts);
        }

        public bool FromJSON(string json)
        {
            try
            {
                Parts = JsonConvert.DeserializeObject<Dictionary<string, Part>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Parts, Formatting.Indented);
            File.WriteAllText(@"data/Parts.json", output);
        }
    }
}
