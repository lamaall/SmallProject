using SmallProject.Enums;

namespace SmallProject.Models
{
    public class Book(string title, string author, string isbn, int yearPublished)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public string ISBN { get; } = isbn;
        public int YearPublished { get; } = yearPublished;
        public BookStatus Status { get; private set; } = BookStatus.Available;

        public void NoteReturn()
        {
            if (Status == BookStatus.Available) return;
            Status = BookStatus.Available;
        }

        public void NoteLoan()
        {
            if (Status == BookStatus.Loaned) return;
            Status = BookStatus.Loaned;
        }

    }
}