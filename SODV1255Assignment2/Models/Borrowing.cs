namespace SODV1255Assignment2.Models
{
    public class Borrowing
    {
        // A borrowing object has a reader and book object within it and a tied in borrowing date determined upon object creation

        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateOnly BorrowDate { get; set; }

        public Borrowing(Book book, Reader reader)
        {
            Reader = reader;
            Book = book;
            Book.ToggleAvailability();
            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
        }

        public override string ToString()
        {
            return $"Reader: {Reader} | Book: {Book} BorrowDate: {BorrowDate}";
        }
    }
}
