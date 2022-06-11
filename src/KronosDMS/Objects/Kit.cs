using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Objects
{
    public struct Kit
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool Locked { get; set; }
        public List<PartQuantityPair> Parts { get; set; }

        public Kit(string name, string description, string Make, string model, List<PartQuantityPair> parts)
        {
            this.Number = name;
            this.Description = description;
            this.Make = Make;
            this.Model = model;
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
    }
}
