using SODV1255Assignment2.Models;

namespace SODV1255Assignment2.Repositories
{
    public class BorrowingRepository
    {

        //Similar to other repositories in this project with the difference of update
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

        //Update must temporarily store the original book to toggle the availability of the book after replacing it (assuming no error are thrown)
        public Borrowing UpdateBorrowing(Book book, Reader reader, int id)
        {
            Borrowing tempBorrowing = _borrowings[id];
            Borrowing updatedBorrowing = new Borrowing(book, reader);
            _borrowings[id] = updatedBorrowing;
            tempBorrowing.Book.ToggleAvailability();
            return updatedBorrowing;
        }

        //Deleting the book must also toggle the availability of the book accessed before deleting it.
        public void DeleteBorrowing(int id)
        {
            _borrowings[id].Book.ToggleAvailability();
            _borrowings.RemoveAt(id);
        }
    }
}
