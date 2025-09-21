using SmallProject.Enums;

/* 
 Vybral som Factory pattern na možnosť 1 v úlohe 2. 
 Centralizovanie tvorby Userov do jednej triedy umožňuje ľahkú škálovateľnosť.
*/
namespace SmallProject.Models
{
    public abstract class User(string name, string email)
    {
        public string Name { get; } = name;
        public string Email { get; } = email;
    }

    public class RegularUser(string name, string email) : User(name, email) { }
    public class PremiumUser(string name, string email) : User(name, email) { }

    public static class UserFactory
    {
        public static User CreateUser(UserType type, string name, string email)
        {
            return type switch
            {
                UserType.Regular => new RegularUser(name, email),
                UserType.Premium => new PremiumUser(name, email),
                _ => throw new ArgumentException("Invalid user type")
            };
        }
    }

}