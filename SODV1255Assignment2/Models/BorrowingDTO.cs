using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class BorrowingDTO
    {
        [Required]
        public int bookID { get; set; }

        [Required]
        public int readerID { get; set; }
    }
}
