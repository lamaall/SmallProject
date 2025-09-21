using SmallProject.Models;
using SmallProject.Enums;

namespace SmallProject.Services
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUserByEmail(string email);
        List<User> ListUsers();
    }

    public class UserService : IUserService
    {
        private List<User> users = new();

        public UserService()
        {
            AddUser(UserFactory.CreateUser(UserType.Regular, "Adam", "adam@gmail.com"));
            AddUser(UserFactory.CreateUser(UserType.Premium, "Boris", "boris@gmail.com"));
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public User? GetUserByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> ListUsers()
        {
            return users;
        }
    }

}