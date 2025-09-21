using Microsoft.AspNetCore.Mvc;
using SmallProject.Services;
using SmallProject.Api.DTOs;

namespace SmallProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private IUserService userService = userService;

        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<UserDTO> userDTOs = userService.ListUsers()
            .Select(user => new UserDTO(
                user.Name,
                user.Email
            ));

            return Ok(userDTOs);
        }
    }
}