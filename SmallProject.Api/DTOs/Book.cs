using SmallProject.Enums;

namespace SmallProject.Api.DTOs
{
    public class BookDTO(string title, string author, string isbn, int yearPublished, BookStatus status)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public string ISBN { get; } = isbn;
        public int YearPublished { get; } = yearPublished;
        public BookStatus Status { get; } = status;
    }
}