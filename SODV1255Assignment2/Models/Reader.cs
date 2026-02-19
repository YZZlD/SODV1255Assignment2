namespace SODV1255Assignment2.Models
{
    public class Reader
    {
        public int ReaderID { get; set; }
        public string? Name { get; set; }

        static int readerid = 1000;

        public Reader(string name)
        {
            Name = name;
            ReaderID = readerid;
            readerid++;
        }

        public override string ToString()
        {
            return $"ReaderID: {ReaderID} | Name: {Name}";
        }
    }
}
