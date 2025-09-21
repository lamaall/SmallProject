using SmallProject.Enums;
using SmallProject.Models;

namespace SmallProject.Services
{
    public interface ILoanService
    {
        bool LoanBook(Book book, User user);
        bool ReturnBook(Book book);
        List<Loan> ListLoans();
    }

    public class LoanService : ILoanService
    {
        private List<Loan> loans = new();

        public bool LoanBook(Book book, User user)
        {
            if (book.Status == BookStatus.Available)
            {
                Loan loan = new(book, user, DateTime.Now);
                book.NoteLoan();
                loans.Add(loan);

                return true;
            }
            return false;
        }

        public bool ReturnBook(Book book)
        {
            Loan? loan = loans.FirstOrDefault(l => l.Book == book && l.ReturnDate == null);
            if (loan == null) return false;

            loan.NoteReturn(DateTime.Now);
            book.NoteReturn();

            return true;
        }

        public List<Loan> ListLoans()
        {
            return loans;
        }
    }
}