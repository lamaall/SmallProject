//using System;
using Microsoft.VisualBasic;
using Models;
using Services;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Book HobbitBook = new Book
            {
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                ISBN = "978-0547928227",
                YearPublished = 1937
            };

            Book OrwellBook = new Book
            {
                Title = "1984",
                Author = "George Orwell",
                ISBN = "978-0451524935",
                YearPublished = 1949
            };

            User Adam = new User
            {
                Name = "Adam",
                Email = "adam@gmail.com"
            };

            User Boris = new User
            {
                Name = "Boris",
                Email = "boris@gmail.com"
            };


            LoanService loanService = new LoanService();

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