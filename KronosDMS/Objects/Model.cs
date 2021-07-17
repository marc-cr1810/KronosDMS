namespace KronosDMS.Objects
{
    public struct Model
    {
        public string ModelName { get; set; }
        public Make Make { get; set; }

        public Model(string modelName, Make Make)
        {
            this.ModelName = modelName;
            this.Make = Make;
        }
    }
}
