using SmallProject.Enums;

namespace SmallProject.Api.DTOs
{
    public class UserDTO(string name, string email)
    {
        public string Name { get; } = name;
        public string Email { get; } = email;
    }
}