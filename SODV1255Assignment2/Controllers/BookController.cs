using Microsoft.AspNetCore.Mvc;
using SODV1255Assignment2.Models;

namespace SODV1255Assignment2
{
    [Route("/books")]
    public class BookController : Controller
    {
        internal List<Book> books = new List<Book>()
        {
            new Book("1984", "George Orwell", "Dystopian", "1949"),
            new Book("The Hobbit", "J.R.R Tolkien", "Fantasy", "1937"),
            new Book("The Da Vinci Code", "Dan Brown", "Mystery Thriller", "2003"),
            new Book("Charlotte's Web", "E.B. White", "Children's Fiction", "1952"),
            new Book("To Kill a Mockingbird", "Harper Lee", "Southern Gothic", "1960")
        };

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(books);
        }


        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            return Ok(books[id - 1]);
        }

        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            books.Add(book);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Book book, int id)
        {
            books[id - 1] = book;
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Book book, int id)
        {
            books.RemoveAt(id);
            return NoContent();
        }
    }
}
