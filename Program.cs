//using System;
using Microsoft.VisualBasic;
using SmallProject.Models;
using SmallProject.Services;

namespace SmallProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Book HobbitBook = new()
            {
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                ISBN = "978-0547928227",
                YearPublished = 1937
            };

            Book OrwellBook = new()
            {
                Title = "1984",
                Author = "George Orwell",
                ISBN = "978-0451524935",
                YearPublished = 1949
            };

            IUser Adam = UserFactory.CreateUser("Regular", "Adam", "adam@gmail.com");
            IUser Boris = UserFactory.CreateUser("Regular", "Boris", "boris@gmail.com");


            LoanService loanService = new();

            loanService.LoanBook(HobbitBook, Adam);
            loanService.LoanBook(OrwellBook, Boris);
            loanService.LoanBook(HobbitBook, Boris);
            loanService.ReturnBook(HobbitBook);

            foreach (Loan loan in loanService.ListLoans())
            {
                Console.WriteLine(loan);
            }

        }
    }
}