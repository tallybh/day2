namespace day2.Models
{
    public class MyFile
    {
        public string Path { get; set; }
        public string Extension { get; set; }

        public long Size { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
