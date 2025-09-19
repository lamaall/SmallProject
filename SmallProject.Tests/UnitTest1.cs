using Xunit;
using SmallProject.Models;
using SmallProject.Services;
using SmallProject.Enums;

namespace SmallProject.Tests
{
    public class LoanServiceTests
    {
        [Fact]
        public void BookCreationTest()
        {
            Book HobbitBook = new("The Hobbit", "J.R.R. Tolkien", "978-0547928227", 1937);

            Assert.Equal("The Hobbit", HobbitBook.Title);
            Assert.Equal("J.R.R. Tolkien", HobbitBook.Author);
            Assert.Equal("978-0547928227", HobbitBook.ISBN);
            Assert.Equal(1937, HobbitBook.YearPublished);
        }

        [Fact]
        public void UserCreationTest()
        {
            User Adam = UserFactory.CreateUser(UserType.Regular, "Adam", "adam@gmail.com");

            Assert.Equal("Adam", Adam.Name);
            Assert.Equal("adam@gmail.com", Adam.Email);
            Assert.IsType<RegularUser>(Adam);

            User Boris = UserFactory.CreateUser(UserType.Premium, "Boris", "boris@gmail.com");

            Assert.Equal("Boris", Boris.Name);
            Assert.Equal("boris@gmail.com", Boris.Email);
            Assert.IsType<PremiumUser>(Boris);
        }

        [Fact]
        public void LoanServiceTest()
        {
            Book HobbitBook = new("The Hobbit", "J.R.R. Tolkien", "978-0547928227", 1937);

            User Adam = UserFactory.CreateUser(UserType.Regular, "Adam", "adam@gmail.com");
            User Boris = UserFactory.CreateUser(UserType.Premium, "Boris", "boris@gmail.com");

            LoanService loanService = new();

            Assert.True(loanService.LoanBook(HobbitBook, Adam));
            Loan? loan = loanService.ListLoans().FirstOrDefault();
            Assert.NotNull(loan);
            Assert.Equal(HobbitBook, loan.Book);
            Assert.Equal(Adam, loan.User);
            Assert.Null(loan.ReturnDate);

            Assert.False(loanService.LoanBook(HobbitBook, Boris));

            Assert.Single(loanService.ListLoans());

            Assert.True(loanService.ReturnBook(HobbitBook));
            Assert.False(loanService.ReturnBook(HobbitBook));

            Assert.True(loanService.LoanBook(HobbitBook, Boris));
            Assert.Equal(2, loanService.ListLoans().Count);
        }
    }
}