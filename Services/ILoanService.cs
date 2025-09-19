//using System.Collections.Generic;
using Models;

namespace Services
{
    public interface ILoanService
    {
        bool LoanBook(Book bookCopy, User user);
        bool ReturnBook(Book bookCopy);
        List<Loan> ListLoans();
    }
}