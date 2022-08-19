using KronosDMS.Utils;
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
        public List<PartsOption> Options { get; set; }
        //public List<PartQuantityPairNote> Parts { get; set; }

        public Recall(string name, string description, string Make, string model, List<PartQuantityPairNote> parts)
        {
            this.Number = name;
            this.Description = description;
            this.Make = Make;
            this.Model = model;
            this.AttentionNote = "";
            this.Locked = false;

            //Parts = parts;

            Options = new List<PartsOption>();
        }

        public void AddPart(int option, string part, int quantity)
        {
            foreach (PartQuantityPairNote p in Options[option].Parts)
            {
                if (p.Number == part)
                    return;
            }
            Options[option].Parts.Add(new PartQuantityPairNote(part, quantity, ""));
        }

        public override string ToString()
        {
            string parts = "";
            for (int i = 0; i < Options.Count; i++)
            {
                PartsOption option = Options[i];
                parts += $"    {option.Name}: [\n";
                for (int j = 0; j < option.Parts.Count; j++)
                {
                    PartQuantityPairNote part = option.Parts[j];
                    parts += $"        {part.Number}\tx{part.Quantity}\t{part.Note}\n";
                }
                parts += $"    ]\n";
            }
            return $"{this.Number}:\n" +
                $"  Make: {this.Make}\n" +
                $"  Model: {this.Model}\n" +
                $"  Description: {this.Description}\n" +
                $"  Options: [\n{parts}  ]";
        }
    }
}
