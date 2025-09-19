using SmallProject.Enums;
using SmallProject.Models;

namespace SmallProject.Services
{
    public interface ILoanService
    {
        bool LoanBook(Book bookCopy, User user);
        bool ReturnBook(Book bookCopy);
        List<Loan> ListLoans();
    }

    public class LoanService : ILoanService
    {
        private List<Loan> _loans = new List<Loan>();

        public bool LoanBook(Book book, User user)
        {
            if (book.Status == BookStatus.Available)
            {
                Loan loan = new(book, user, DateTime.Now);
                book.NoteLoan();
                _loans.Add(loan);

                return true;
            }
            return false;
        }

        public bool ReturnBook(Book book)
        {
            Loan? loan = _loans.FirstOrDefault(l => l.Book == book && l.ReturnDate == null);
            if (loan == null) return false;

            loan.NoteReturn(DateTime.Now);
            book.NoteReturn();

            return true;
        }

        public List<Loan> ListLoans()
        {
            return _loans;
        }
    }
}