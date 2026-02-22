using System.ComponentModel.DataAnnotations;

namespace SODV1255Assignment2.Models
{
    public class Book
    {
        // A book has an author, title, genre and publication date. Availability is automatically determined and manipulated by
        //different actions in the LMS such as adding or deleting a borrowing listing or modifying the book in that listing

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

        public bool Availability { get; private set; }

        public Book(string title, string author, string genre, int publication)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Publication = publication;
            Availability = true;
        }

        public void ToggleAvailability()
        {
            Availability = !Availability;
        }

        public override string ToString()
        {
            return $"Title: {Title} | Author: {Author} | Genre: {Genre} | Publication Year: {Publication} | Available: {(Availability ? "Yes" : "No")}";
        }
    }
}
