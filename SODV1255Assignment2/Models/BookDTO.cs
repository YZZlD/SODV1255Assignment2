using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class BookDTO
    {
        //Serves to grab and validate all necessary fields for a book model object
        [Required(ErrorMessage = "Title is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Author must be between 2 and 100 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is mandatory.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Genre must be between 2 and 100 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Publication is mandatory.")]
        [Range(868, 3000, ErrorMessage = "Publication must be between year 868 and 3000")]
        public int Publication { get; set; }
    }
}
