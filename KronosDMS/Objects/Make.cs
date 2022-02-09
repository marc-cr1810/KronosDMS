using System.Collections.Generic;

namespace KronosDMS.Objects
{
    public struct Model
    {
        public List<string> SubModels { get; set; }

        public Model(List<string> submodels)
        {
            SubModels = new List<string>();
        }

        public void AddSubModel(string submodel)
        {
            if (SubModels is null)
                SubModels = new List<string>();
            SubModels.Add(submodel);
        }
    }

    public struct Make
    {
        public string Name { get; set; }
        public Dictionary<string, Model> Models { get; set; }

        public Make(string name, Dictionary<string, Model> models)
        {
            this.Name = name;
            this.Models = models;
        }

        public override string ToString()
        {
            string models = "";
            for (int i = 0; i < Models.Count; i++)
            {
                models += $"    {"null"}\n";
            }
            return $"{this.Name}:\n" +
                $"  Models: [\n{models}  ]";
        }
    }
}
