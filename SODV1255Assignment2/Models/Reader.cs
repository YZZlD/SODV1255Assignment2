using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class Reader
    {
        public int ReaderID { get; set; }

        [Required(ErrorMessage = "Name is mandatory.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters.")]
        public string Name { get; set; }

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
