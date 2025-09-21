using SmallProject.Models;
using SmallProject.Enums;

namespace SmallProject.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        Book? GetBookByISBN(string isbn);
        List<Book> ListBooks();
    }

    public class BookService : IBookService
    {
        private List<Book> books = new();

        public BookService()
        {
            AddBook(new("The Hobbit", "J.R.R. Tolkien", "978-0547928227", 1937));
            AddBook(new("1984", "George Orwell", "978-0451524935", 1949));
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book? GetBookByISBN(string isbn)
        {
            return books.FirstOrDefault(b => b.ISBN == isbn);
        }

        public List<Book> ListBooks()
        {
            return books;
        }
    }
}