using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Objects
{
    public struct CSVFormat
    {
        //
        //  Data
        //
        public struct KitFormat
        {
            public string Index;
            public string PartNumber;
            public string Quantity;
            public string Make;
            public string Description;
        }

        public struct RecallFormat
        {
            public string Index;
            public string PartNumber;
            public string Quantity;
            public string Make;
            public string Description;
        }

        public Dictionary<string, string> MakeIDs;

        public KitFormat Kit;
        public RecallFormat Recall;

        //
        // Functions
        //
        public KeyValuePair<Part, int>[] GetKitPartsList(string file)
        {
            List<KeyValuePair<Part, int>> result = new List<KeyValuePair<Part, int>>();

            string[] lines = File.ReadAllLines(file);
            string[] layout = lines[0].Split(',');

            int colPartNumber = Array.IndexOf(layout, Kit.PartNumber);
            int colQuantity = Array.IndexOf(layout, Kit.Quantity);
            int colMake = Array.IndexOf(layout, Kit.Make);
            int colDescription = Array.IndexOf(layout, Kit.Description);

            foreach (string line in lines)
            {
                string[] data = line.Replace("\"", "").Split(',');

                if (data[0] == Kit.Index)
                    continue;

                Part p = new Part
                {
                    Number = data[colPartNumber].Replace(" ", "").ToUpper(),
                    Make = GetMakeFromID(data[colMake]),
                    Description = data[colDescription]
                };
                int qty = int.Parse(data[colQuantity].Split('.')[0]);

                result.Add(new KeyValuePair<Part, int>(p, qty));
            }

            return result.ToArray();
        }

        public KeyValuePair<Part, int>[] GetRecallPartsList(string file)
        {
            List<KeyValuePair<Part, int>> result = new List<KeyValuePair<Part, int>>();

            string[] lines = File.ReadAllLines(file);
            string[] layout = lines[0].Split(',');

            int colPartNumber = Array.IndexOf(layout, Recall.PartNumber);
            int colQuantity = Array.IndexOf(layout, Recall.Quantity);
            int colMake = Array.IndexOf(layout, Recall.Make);
            int colDescription = Array.IndexOf(layout, Recall.Description);

            foreach (string line in lines)
            {
                string[] data = line.Replace("\"", "").Split(',');

                if (data[0] == Recall.Index)
                    continue;

                Part p = new Part
                {
                    Number = data[colPartNumber].Replace(" ", "").ToUpper(),
                    Make = GetMakeFromID(data[colMake]),
                    Description = data[colDescription]
                };
                int qty = int.Parse(data[colQuantity].Split('.')[0]);

                result.Add(new KeyValuePair<Part, int>(p, qty));
            }

            return result.ToArray();
        }

        private string GetMakeFromID(string id)
        {
            if (MakeIDs.ContainsKey(id))
                return MakeIDs[id];
            return "";
        }
    }
}
