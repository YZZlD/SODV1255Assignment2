using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class BorrowingDTO
    {
        //Grabs all necessary information for a borrowing listing

        [Required]
        public int bookID { get; set; }

        [Required]
        public int readerID { get; set; }
    }
}
