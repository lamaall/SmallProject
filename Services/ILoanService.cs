//using System.Collections.Generic;
using Models;

namespace Services
{
    public interface ILoanService
    {
        bool LoanBook(BookCopy bookCopy, User user);
        bool ReturnBook(BookCopy bookCopy);
        List<Loan> ListLoans();
    }
}