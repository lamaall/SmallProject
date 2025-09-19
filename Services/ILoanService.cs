//using System.Collections.Generic;
using SmallProject.Models;

namespace SmallProject.Services
{
    public interface ILoanService
    {
        bool LoanBook(Book bookCopy, IUser user);
        bool ReturnBook(Book bookCopy);
        List<Loan> ListLoans();
    }
}