
namespace SmallProject.Api.DTOs
{
    public class LoanDTO(string isbn, string email, DateTime loanDate)
    {
        public string ISBN { get; } = isbn;
        public string Email { get; } = email;
        public DateTime LoanDate { get; } = loanDate;
    }
}