using Enums;
using Models;

namespace Services
{
    public class LoanService : ILoanService
    {
        private readonly List<Loan> _loans = new List<Loan>();

        public bool LoanBook(Book book, User user)
        {
            if (book.Status == BookStatus.Available)
            {
                Loan loan = new Loan
                {
                    Book = book,
                    User = user,
                    LoanDate = DateTime.Now,
                    ReturnDate = null
                };

                book.Status = BookStatus.Loaned;
                _loans.Add(loan);

                Console.WriteLine("Book successfully loaned");
                return true;
            }
            Console.WriteLine("Book cant be loaned");
            return false;
        }

        public bool ReturnBook(Book book)
        {
            Loan? loan = _loans.FirstOrDefault(l => l.Book == book && l.ReturnDate == null);
            if (loan == null)
            {
                Console.WriteLine("Book cant be returned");
                return false;
            }

            loan.ReturnDate = DateTime.Now;
            book.Status = BookStatus.Available;

            Console.WriteLine("Book successfully returned");
            return true;
        }

        public List<Loan> ListLoans()
        {
            return _loans;
        }
    }
}