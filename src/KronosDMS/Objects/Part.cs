namespace KronosDMS.Objects
{
    public struct Part
    {
        public string Make { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }

        public string Bin { get; set; }

        public string Predecessor { get; set; }

        public string Successor { get; set; }

        public Part(string make, string number, string description)
        {
            this.Make = make;
            this.Number = number;
            this.Description = description;
            this.Bin = "";
            this.Predecessor = "";
            this.Successor = "";
        }

        public override string ToString()
        {
            return $"{this.Number}:\n" +
                $"  Make: {this.Make}\n" +
                $"  Description: {this.Description}\n" +
                $"  Bin: {this.Bin}\n" +
                $"  Predecessor: {this.Predecessor}\n" +
                $"  Successor: {this.Successor}";
        }
    }
}
