namespace day2.Models
{
    public record Product
    {
        public int id { get; init; }
        public string name { get; init; }
        public string description { get; init; }
        public double price { get; init; }
    }
}
