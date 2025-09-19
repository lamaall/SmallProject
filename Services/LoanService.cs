using Enums;
using Models;

namespace Services
{
    public class LoanService : ILoanService
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public bool LoanBook(BookCopy bookCopy, User user)
        {
            if (bookCopy.Status == BookStatus.Available)
            {
                Loan loan = new Loan
                {
                    BookCopy = bookCopy,
                    User = user,
                    LoanDate = DateTime.Now,
                    ReturnDate = null
                };

                bookCopy.Status = BookStatus.Loaned;
                _loans.Add(loan);

                Console.WriteLine("Book successfully loaned");
                return true;
            }
            Console.WriteLine("Book cant be loaned");
            return false;
        }

        public bool ReturnBook(BookCopy bookCopy)
        {
            Loan? loan = _loans.FirstOrDefault(l => l.BookCopy == bookCopy && l.ReturnDate == null);
            if (loan == null)
            {
                Console.WriteLine("Book cant be returned");
                return false;
            }

            loan.ReturnDate = DateTime.Now;
            bookCopy.Status = BookStatus.Available;

            Console.WriteLine("Book successfully returned");
            return true;
        }

        public List<Loan> ListLoans()
        {
            return _loans;
        }
    }
}