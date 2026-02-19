namespace SODV1255Assignment2.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Publication { get; set; }
        public bool Availability { get; private set; }

        public Book(string title, string author, string genre, string publication)
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
