using System.Collections.Generic;

namespace KronosDMS.Objects
{
    public struct Make
    {
        public string Name { get; set; }
        public List<string> Models { get; set; }

        public Make(string name, List<string> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public override string ToString()
        {
            string models = "";
            for (int i = 0; i < Models.Count; i++)
            {
                models += $"    {Models[i]}\n";
            }
            return $"{this.Name}:\n" +
                $"  Models: [\n{models}  ]";
        }
    }
}
