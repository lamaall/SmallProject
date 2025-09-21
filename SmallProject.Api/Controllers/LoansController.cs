using Microsoft.AspNetCore.Mvc;
using SmallProject.Services;
using SmallProject.Models;
using SmallProject.Api.DTOs;

namespace SmallProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController(ILoanService loanService, IBookService bookService, IUserService userService) : ControllerBase
    {
        private ILoanService loanService = loanService;
        private IBookService bookService = bookService;
        private IUserService userService = userService;


        [HttpGet]
        public IActionResult GetActiveLoans()
        {
            IEnumerable<LoanDTO> loanDTOs = loanService.ListLoans()
            .Where(loan => loan.ReturnDate == null)
            .Select(loan => new LoanDTO(
                loan.Book.ISBN,
                loan.User.Email,
                loan.LoanDate
            ));

            return Ok(loanDTOs);
        }

        [HttpPost("loan")]
        public IActionResult LoanBook([FromBody] LoanRequest request)
        {
            Book? book = bookService.GetBookByISBN(request.ISBN);
            if (book == null) return BadRequest("Book does not exist");

            User? user = userService.GetUserByEmail(request.Email);
            if (user == null) return BadRequest("User does not exist");

            if (!loanService.LoanBook(book, user))
                return BadRequest("Book is already loaned");

            return Ok("Book loaned successfully");
        }

        [HttpPost("return")]
        public IActionResult ReturnBook([FromBody] ReturnRequest request)
        {
            Book? book = bookService.GetBookByISBN(request.ISBN);
            if (book == null) return BadRequest("Book does not exist");

            if (!loanService.ReturnBook(book))
                return BadRequest("Book was not loaned");

            return Ok("Book returned successfully");
        }


    }
}