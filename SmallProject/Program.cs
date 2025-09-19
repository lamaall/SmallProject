using SmallProject.Models;
using SmallProject.Services;
using SmallProject.Enums;

namespace SmallProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Book HobbitBook = new("The Hobbit", "J.R.R. Tolkien", "978-0547928227", 1937);
            Book OrwellBook = new("1984", "George Orwell", "978-0451524935", 1949);

            User Adam = UserFactory.CreateUser(UserType.Regular, "Adam", "adam@gmail.com");
            User Boris = UserFactory.CreateUser(UserType.Premium, "Boris", "boris@gmail.com");

            LoanService loanService = new();

            loanService.LoanBook(HobbitBook, Adam);
            loanService.LoanBook(OrwellBook, Boris);
            loanService.ReturnBook(HobbitBook);

            foreach (Loan loan in loanService.ListLoans())
            {
                Console.WriteLine(loan);
            }

        }
    }
}