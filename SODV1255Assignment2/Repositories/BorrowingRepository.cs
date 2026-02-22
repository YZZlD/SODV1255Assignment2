using SODV1255Assignment2.Models;

namespace SODV1255Assignment2.Repositories
{
    public class BorrowingRepository
    {
        private List<Borrowing> _borrowings = new List<Borrowing>();

        public List<Borrowing> GetAllBorrowings()
        {
            return _borrowings;
        }

        public Borrowing GetBorrowingById(int id)
        {
            return _borrowings[id];
        }

        public Borrowing AddBorrowing(Book book, Reader reader)
        {
            Borrowing borrowing = new Borrowing(book, reader);
            _borrowings.Add(borrowing);
            return borrowing;
        }

        public Borrowing UpdateBorrowing(Book book, Reader reader, int id)
        {
            Borrowing tempBorrowing = _borrowings[id];
            Borrowing updatedBorrowing = new Borrowing(book, reader);
            _borrowings[id] = updatedBorrowing;
            tempBorrowing.Book.ToggleAvailability();
            return updatedBorrowing;
        }

        public void DeleteBorrowing(int id)
        {
            _borrowings[id].Book.ToggleAvailability();
            _borrowings.RemoveAt(id);
        }
    }
}
