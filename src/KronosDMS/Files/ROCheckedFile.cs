using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Files
{
    public class ROCheckedFile
    {
        public Dictionary<int, RepairOrder> RepairOrders { get; set; }

        public int MAX_RESULTS = 100;

        public ROCheckedFile()
        {
            if (File.Exists(@"data/ROChecked.json"))
                RepairOrders = JsonConvert.DeserializeObject<Dictionary<int, RepairOrder>>(File.ReadAllText(@"data/ROChecked.json"));
            if (RepairOrders is null)
                RepairOrders = new Dictionary<int, RepairOrder>();
        }

        public bool Add(string json)
        {
            if (json == null)
                return false;

            List<RepairOrder> ros = JsonConvert.DeserializeObject<List<RepairOrder>>(json);
            for (int i = 0; i < ros.Count; i++)
            {
                // Check if the RO already exists
                if (RepairOrders.ContainsKey(ros[i].Number))
                    continue;

                RepairOrders.Add(ros[i].Number, ros[i]);
                Write();
            }
            return true;
        }

        public bool Add(List<RepairOrder> ros)
        {
            for (int i = 0; i < ros.Count; i++)
            {
                // Check if the RO already exists
                if (RepairOrders.ContainsKey(ros[i].Number))
                    continue;

                RepairOrders.Add(ros[i].Number, ros[i]);
                Write();
            }
            return true;
        }

        public bool Add(RepairOrder ro)
        {
            // Check if the RO already exists
            if (RepairOrders.ContainsKey(ro.Number))
                return false;

            RepairOrders.Add(ro.Number, ro);
            Write();
            return true;
        }

        public bool Remove(int id)
        {
            if (!RepairOrders.ContainsKey(id))
                return false;
            RepairOrders.Remove(id);
            Write();
            return true;
        }

        public bool Set(string json)
        {
            RepairOrder ro;
            try
            {
                ro = JsonConvert.DeserializeObject<RepairOrder>(json);
            }
            catch { return false; }

            // Check if the RO does not exist
            if (!RepairOrders.ContainsKey(ro.Number))
                return false;

            RepairOrders[ro.Number] = ro;
            Write();
            return true;
        }
        public string Search(string number, string date = "")
        {
            Dictionary<int, RepairOrder> result = new Dictionary<int, RepairOrder>();

            if (number != "")
            {
                int n = 0;
                if (!int.TryParse(number, out n))
                    return "";
                if (RepairOrders.ContainsKey(n))
                    result.Add(n, RepairOrders[n]);
                return JsonConvert.SerializeObject(result);
            }

            if (date != "")
            {
                int numResults = 0;
                DateTime d;
                if (!DateTime.TryParse(date, out d))
                    return "";
                foreach (KeyValuePair<int, RepairOrder> repairOrder in RepairOrders)
                {
                    RepairOrder ro = repairOrder.Value;
                    if (ro.CreationDate.ToShortDateString() == d.ToShortDateString())
                    {
                        result.Add(ro.Number, ro);
                        numResults++;
                        if (numResults == MAX_RESULTS)
                            break;
                    }
                }
            }
            return JsonConvert.SerializeObject(result);
        }

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(RepairOrders);
        }

        public bool FromJSON(string json)
        {
            try
            {
                RepairOrders = JsonConvert.DeserializeObject<Dictionary<int, RepairOrder>>(json);
            }
            catch { return false; }
            return true;
        }

        public void Write()
        {
            string output = JsonConvert.SerializeObject(RepairOrders, Formatting.Indented);
            File.WriteAllText(@"data/ROChecked.json", output);
        }
    }
}
