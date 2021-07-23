using KronosDMS.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KronosDMS.Files
{
    public class KitFile
    {
        public Dictionary<string, Kit> Kits { get; set; } = new Dictionary<string, Kit>();

        private readonly int MAX_RESULTS = 100;

        public KitFile()
        {
            if (File.Exists(@"data/Kits.json"))
                Kits = JsonConvert.DeserializeObject<Dictionary<string, Kit>>(File.ReadAllText(@"data/Kits.json"));
            if (Kits is null)
                Kits = new Dictionary<string, Kit>();
        }

        public bool Add(string json)
        {
            Kit Kit;
            try
            {
                Kit = JsonConvert.DeserializeObject<Kit>(json);
            }
            catch { return false; }

            int num = 1;
            if (Kit.Number is null)
            {
                if (Kits.Count != 0)
                {
                    num = int.Parse(Kits.Last().Key.Substring(1, 6));
                    while (Kits.ContainsKey($"K{num:D6}"))
                        num++;
                }
            }
            Kit.Number = $"K{num:D6}";
            Kits.Add(Kit.Number, Kit);
            Write();
            return true;
        }

        public void Add(string make, string model, string number, string description)
        {
            Kit Kit = new Kit(number, description, make, model, new List<PartQuantityPair>());
            Kits.Add(number, Kit);
            Write();
        }

        public bool Remove(string id)
        {
            if (!Kits.ContainsKey(id))
                return false;
            Kits.Remove(id);
            Write();
            return true;
        }

        public bool Set(string json)
        {
            Kit Kit;
            try
            {
                Kit = JsonConvert.DeserializeObject<Kit>(json);
            }
            catch { return false; }

            // Check if the Kit does not exist
            if (!Kits.ContainsKey(Kit.Number))
                return false;

            Kits[Kit.Number] = Kit;
            Write();
            return true;
        }

        public string Search(string make, string model, string number, string description, string id = "")
        {
            Dictionary<string, Kit> result = new Dictionary<string, Kit>();

            if (id != "")
            {
                if (Kits.ContainsKey(id))
                    result.Add(id, Kits[id]);
                return JsonConvert.SerializeObject(result);
            }

            int numResults = 0;
            foreach (KeyValuePair<string, Kit> Kit in Kits)
            {
                Kit k = Kit.Value;
                if (k.Make.ToUpper().Contains(make.ToUpper()) &&
                    k.Model.ToUpper().Contains(model.ToUpper()) &&
                    k.Number.ToUpper().Contains(number.ToUpper()) &&
                    k.Description.ToUpper().Contains(description.ToUpper()))
                {
                    result.Add(Kit.Key, Kit.Value);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(Kits);
        }

        public bool FromJSON(string json)
        {
            try
            {
                Kits = JsonConvert.DeserializeObject<Dictionary<string, Kit>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Kits, Formatting.Indented);
            File.WriteAllText(@"data/Kits.json", output);
        }
    }
}
