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

            BookCopy HobbitCopy1 = new BookCopy
            {
                CopyId = 1,
                Book = HobbitBook
            };

            Book OrwellBook = new Book
            {
                Title = "1984",
                Author = "George Orwell",
                ISBN = "978-0451524935",
                YearPublished = 1949
            };

            BookCopy OrwellCopy1 = new BookCopy
            {
                CopyId = 1,
                Book = OrwellBook
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

            loanService.LoanBook(HobbitCopy1, Adam);
            loanService.LoanBook(OrwellCopy1, Boris);
            loanService.LoanBook(HobbitCopy1, Boris);
            loanService.ReturnBook(HobbitCopy1);

            foreach (Loan loan in loanService.ListLoans())
            {
                Console.WriteLine(loan);
            }

        }
    }
}