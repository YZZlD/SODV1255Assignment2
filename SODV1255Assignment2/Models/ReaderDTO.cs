using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class ReaderDTO
    {
        [Required(ErrorMessage = "Name is mandatory.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters.")]
        public string Name { get; set; }
    }
}
