using System.Collections.Generic;

namespace KronosDMS.Objects
{
    public struct Recall
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string AttentionNote { get; set; }
        public bool Locked { get; set; }
        public List<PartQuantityPair> Parts { get; set; }

        public Recall(string name, string description, string Make, string model, List<PartQuantityPair> parts)
        {
            this.Number = name;
            this.Description = description;
            this.Make = Make;
            this.Model = model;
            this.AttentionNote = "";
            this.Locked = false;

            Parts = parts;
        }

        public void AddPart(string part, int quantity)
        {
            foreach (PartQuantityPair p in Parts)
            {
                if (p.Number == part)
                    return;
            }
            Parts.Add(new PartQuantityPair(part, quantity));
        }

        public override string ToString()
        {
            string parts = "";
            for (int i = 0; i < Parts.Count; i++)
            {
                PartQuantityPair part = Parts[i];
                parts += $"    {part.Number}\tx{part.Quantity}\n";
            }
            return $"{this.Number}:\n" +
                $"  Make: {this.Make}\n" +
                $"  Model: {this.Model}\n" +
                $"  Description: {this.Description}\n" +
                $"  Parts: [\n{parts}  ]";
        }
    }
}
