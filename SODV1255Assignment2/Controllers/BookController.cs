using Microsoft.AspNetCore.Mvc;
using SODV1255Assignment2.Models;
using SODV1255Assignment2.Repositories;

namespace SODV1255Assignment2.Controllers
{
    [ApiController]
    [Route("/books")]
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookRepository.GetAllBooks());
        }


        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                return Ok(_bookRepository.GetBookById(id - 1));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Book #{id} not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDTO)
        {
            Book book = new Book(bookDTO.Title, bookDTO.Author, bookDTO.Genre, bookDTO.Publication);
            return Ok(_bookRepository.AddBook(book));
        }

        [HttpPut("{id}")]
        public IActionResult AddBook([FromBody] BookDTO bookDTO, int id)
        {
            Book book = new Book(bookDTO.Title, bookDTO.Author, bookDTO.Genre, bookDTO.Publication);

            try
            {
                return Ok(_bookRepository.UpdateBook(book, id - 1));
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Book #{id} not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id - 1);
                return NoContent();
            } catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Book #{id} not found.");
            } catch (FormatException)
            {
                return NotFound($"Query formatted incorrectly.");
            }

        }
    }
}
