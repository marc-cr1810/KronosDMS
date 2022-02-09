using KronosDMS.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS.Files
{
    public class CSVFormatsFile
    {
        public Dictionary<string, CSVFormat> Formats { get; set; } = new Dictionary<string, CSVFormat>();

        public int MAX_RESULTS = 100;

        public CSVFormatsFile()
        {
            if (File.Exists(@"data/CSVFormats.json"))
                Formats = JsonConvert.DeserializeObject<Dictionary<string, CSVFormat>>(File.ReadAllText(@"data/CSVFormats.json"));
            if (Formats is null)
                Formats = new Dictionary<string, CSVFormat>();
        }

        public bool Add(string name, string json)
        {
            CSVFormat csvFormat;
            try
            {
                csvFormat = JsonConvert.DeserializeObject<CSVFormat>(json);
            }
            catch { return false; }

            // Check if the CSV Format already exists
            if (Formats.ContainsKey(name))
                return false;

            Formats.Add(name, csvFormat);
            Write();
            return true;
        }

        public void Add(string name, List<string> models)
        {
            CSVFormat CSVFormat = new CSVFormat();
            Formats.Add(name, CSVFormat);
            Write();
        }

        public bool Set(string name, string json)
        {
            CSVFormat csvFormat;
            try
            {
                csvFormat = JsonConvert.DeserializeObject<CSVFormat>(json);
            }
            catch { return false; }

            // Check if the CSV Format does not exist
            if (!Formats.ContainsKey(name))
                return false;

            Formats[name] = csvFormat;
            Write();
            return true;
        }

        public string Get(string name)
        {
            if (!Formats.ContainsKey(name))
                return "{}";

            return JsonConvert.SerializeObject(Formats[name]);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(Formats);
        }

        public bool FromJSON(string json)
        {
            try
            {
                Formats = JsonConvert.DeserializeObject<Dictionary<string, CSVFormat>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Formats, Formatting.Indented);
            File.WriteAllText(@"data/CSVFormats.json", output);
        }
    }
}
