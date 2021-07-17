using KronosDMS.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS.Files
{
    public class MakeFile
    {
        public Dictionary<string, Make> Makes { get; set; } = new Dictionary<string, Make>();

        private readonly int MAX_RESULTS = 100;

        public MakeFile()
        {
            if (File.Exists(@"data/Makes.json"))
                Makes = JsonConvert.DeserializeObject<Dictionary<string, Make>>(File.ReadAllText(@"data/Makes.json"));
            if (Makes is null)
                Makes = new Dictionary<string, Make>();
        }

        public bool Add(string json)
        {
            Make make;
            try
            {
                make = JsonConvert.DeserializeObject<Make>(json);
            }
            catch { return false; }

            // Check if the part already exists
            if (Makes.ContainsKey(make.Name))
                return false;

            Makes.Add(make.Name, make);
            Write();
            return true;
        }

        public void Add(string name, List<string> models)
        {
            Make Make = new Make(name, models);
            Makes.Add(name, Make);
            Write();
        }

        public bool Set(string json)
        {
            Make make;
            try
            {
                make = JsonConvert.DeserializeObject<Make>(json);
            }
            catch { return false; }

            // Check if the make does not exist
            if (!Makes.ContainsKey(make.Name))
                return false;

            Makes[make.Name] = make;
            Write();
            return true;
        }

        public string Search(string name)
        {
            Dictionary<string, Make> result = new Dictionary<string, Make>();

            int numResults = 0;
            foreach (KeyValuePair<string, Make> make in Makes)
            {
                Make m = make.Value;
                if (m.Name.ToUpper().Contains(name.ToUpper()))
                {
                    result.Add(make.Key, make.Value);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(Makes);
        }

        public bool FromJSON(string json)
        {
            try
            {
                Makes = JsonConvert.DeserializeObject<Dictionary<string, Make>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Makes, Formatting.Indented);
            File.WriteAllText(@"data/Makes.json", output);
        }
    }
}
