using Microsoft.AspNetCore.Mvc;
using SODV1255Assignment2.Models;

namespace SODV1255Assignment2.Repositories
{
    public class BookRepository
    {
        //Book repository handles book storage through a singleton instance binding in the main program
        private List<Book> _books = new List<Book>()
        {
            new Book("1984", "George Orwell", "Dystopian", 1949),
            new Book("The Hobbit", "J.R.R Tolkien", "Fantasy", 1937),
            new Book("The Da Vinci Code", "Dan Brown", "Mystery Thriller", 2003),
            new Book("Charlotte's Web", "E.B. White", "Children's Fiction", 1952),
            new Book("To Kill a Mockingbird", "Harper Lee", "Southern Gothic", 1960)
        };

        //Returns all books from the list
        public List<Book> GetAllBooks()
        {
            return _books;
        }

        //Gets on book from list
        public Book GetBookById(int id)
        {
            return _books[id];
        }

        //Adds a book to list and returns the added book
        public Book AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        //Updates the value of the book in a list to another provided book object and returns the new book
        public Book UpdateBook(Book book, int id)
        {
            _books[id] = book;
            return book;
        }

        //Delete the book in the list
        public void DeleteBook(int id)
        {
            _books.RemoveAt(id);
        }
    }
}
