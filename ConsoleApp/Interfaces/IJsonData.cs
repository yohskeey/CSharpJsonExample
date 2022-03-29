namespace ConsoleApp.Interfaces
{
    public interface IJsonData
    {
        public string? StringData { get; set; }
        public string? JapaneseString { get; set; }
        public decimal? NumericData { get; set; }
        public decimal? OrderFirstNumericData { get; set; }
        public decimal? OrderLastNumericData { get; set; }
        public List<decimal>? NumericArray { get; set; }
        public List<string>? StringArray { get; set; }
    }
}
