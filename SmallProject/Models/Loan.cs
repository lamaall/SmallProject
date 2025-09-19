namespace SmallProject.Models
{
    public class Loan(Book book, User user, DateTime loanDate)
    {
        public Book Book { get; } = book;
        public User User { get; } = user;
        public DateTime LoanDate { get; } = loanDate;
        public DateTime? ReturnDate { get; private set; } = null;

        public void NoteReturn(DateTime returnDate)
        {
            if (ReturnDate.HasValue) return;
            ReturnDate = returnDate;
        }

        public override string ToString()
        {
            string returnDate = ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not returned";
            return $"{Book.Title} -> {User.Name}, Loaned: {LoanDate:yyyy-MM-dd}, Returned: {returnDate}";
        }
    }
}