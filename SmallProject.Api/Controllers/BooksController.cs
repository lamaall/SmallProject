using Microsoft.AspNetCore.Mvc;
using SmallProject.Services;
using SmallProject.Api.DTOs;

namespace SmallProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private IBookService bookService = bookService;

        [HttpGet]
        public IActionResult GetBooks()
        {
            IEnumerable<BookDTO> bookDTOs = bookService.ListBooks()
            .Select(book => new BookDTO(
                book.Title,
                book.Author,
                book.ISBN,
                book.YearPublished,
                book.Status
            ));

            return Ok(bookDTOs);
        }
    }
}