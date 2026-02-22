using Microsoft.AspNetCore.Mvc;
using SODV1255Assignment2.Models;
using SODV1255Assignment2.Repositories;

namespace SODV1255Assignment2.Controllers
{
    [ApiController]
    [Route("/borrowings")]
    public class BorrowingController : Controller
    {
        private readonly BorrowingRepository _borrowingRepository;
        private readonly BookRepository _bookRepository;
        private readonly ReaderRepository _readerRepository;

        public BorrowingController(BorrowingRepository borrowingRepository, BookRepository bookRepository, ReaderRepository readerRepository)
        {
            _borrowingRepository = borrowingRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
        }

        [HttpGet]
        public IActionResult GetAllBorrowings()
        {
            return Ok(_borrowingRepository.GetAllBorrowings());
        }

        [HttpGet("{id}")]
        public IActionResult GetBorrowingById(int id)
        {
            try
            {
                return Ok(_borrowingRepository.GetBorrowingById(id));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Borrowing #{id} not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly");
            }

        }

        [HttpPost]
        public IActionResult AddBorrowing([FromBody] BorrowingDTO borrowingDTO)
        {
            try
            {
                Book book = _bookRepository.GetBookById(borrowingDTO.bookID - 1);
                Reader reader = _readerRepository.GetReaderById(borrowingDTO.readerID - 1);
                if(!book.Availability) return Ok("Book is not available");
                return Ok(_borrowingRepository.AddBorrowing(book, reader));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Reader or Book ID not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBorrowing([FromBody] BorrowingDTO borrowingDTO, int id)
        {
            try
            {
                Book book = _bookRepository.GetBookById(borrowingDTO.bookID - 1);
                Reader reader = _readerRepository.GetReaderById(borrowingDTO.readerID - 1);
                if(!book.Availability && (_bookRepository.GetBookById(borrowingDTO.bookID - 1) != _borrowingRepository.GetBorrowingById(id - 1).Book)) return Ok("Book is not available");
                return Ok(_borrowingRepository.UpdateBorrowing(book, reader, id - 1));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Reader, Book or Borrowing ID not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBorrowing(int id)
        {
            try
            {
                _borrowingRepository.DeleteBorrowing(id - 1);
                return NoContent();
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Borrowing #{id} not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }

    }
}
