using KronosDMS.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace KronosDMS.Files
{
    public class RecallFile
    {
        public Dictionary<string, Recall> Recalls { get; set; } = new Dictionary<string, Recall>();

        public int MAX_RESULTS = 100;

        public RecallFile()
        {
            if (File.Exists(@"data/Recalls.json"))
                Recalls = JsonConvert.DeserializeObject<Dictionary<string, Recall>>(File.ReadAllText(@"data/Recalls.json"));
            if (Recalls is null)
                Recalls = new Dictionary<string, Recall>();
        }

        public bool Add(string json)
        {
            Recall recall;
            try
            {
                recall = JsonConvert.DeserializeObject<Recall>(json);
            }
            catch { return false; }

            // Check if the recall already exists
            if (Recalls.ContainsKey(recall.Number))
                return false;

            Recalls.Add(recall.Number, recall);
            Write();
            return true;
        }

        public void Add(string make, string model, string number, string description)
        {
            Recall recall = new Recall(number, description, make, model, new List<PartQuantityPairNote>());
            Recalls.Add(number, recall);
            Write();
        }

        public bool Remove(string id)
        {
            // Check if the recall does not exist
            if (!Recalls.ContainsKey(id))
                return false;

            // Check if the recall is locked
            if (Recalls[id].Locked)
                return false;

            Recalls.Remove(id);
            Write();
            return true;
        }

        public bool Set(string json)
        {
            Recall recall;
            try
            {
                recall = JsonConvert.DeserializeObject<Recall>(json);
            }
            catch { return false; }

            // Check if the recall does not exist
            if (!Recalls.ContainsKey(recall.Number))
                return false;

            // Check if the recall is locked
            if (Recalls[recall.Number].Locked)
                return false;

            Recalls[recall.Number] = recall;
            Write();
            return true;
        }

        public bool SetLockState(string id, bool locked)
        {
            if (!Recalls.ContainsKey(id))
                return false;
            Recall r = Recalls[id];
            r.Locked = locked;
            Recalls[id] = r;
            Write();
            return true;
        }

        public string Search(string make, string model, string number, string description, string id = "")
        {
            Dictionary<string, Recall> result = new Dictionary<string, Recall>();

            if (id != "")
            {
                if (Recalls.ContainsKey(id))
                    result.Add(id, Recalls[id]);
                return JsonConvert.SerializeObject(result);
            }

            int numResults = 0;
            foreach (KeyValuePair<string, Recall> recall in Recalls)
            {
                Recall r = recall.Value;
                if (r.Make.ToUpper().Contains(make.ToUpper()) &&
                    r.Model.ToUpper().Contains(model.ToUpper()) &&
                    r.Number.ToUpper().Contains(number.ToUpper()) &&
                    r.Description.ToUpper().Contains(description.ToUpper()))
                {
                    result.Add(recall.Key, recall.Value);
                    numResults++;
                    if (numResults == MAX_RESULTS)
                        break;
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(Recalls);
        }

        public bool FromJSON(string json)
        {
            try
            {
                Recalls = JsonConvert.DeserializeObject<Dictionary<string, Recall>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(Recalls, Formatting.Indented);
            File.WriteAllText(@"data/Recalls.json", output);
        }
    }
}
