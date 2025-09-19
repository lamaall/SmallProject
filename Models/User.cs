//using System;

namespace SmallProject.Models
{
    public interface IUser
    {
        string Name { get; }
        string Email { get; }
    }


    public class RegularUser(string name, string email) : IUser
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
    }

    public class PremiumUser(string name, string email) : IUser
    {
        public string Name { get; private set; } = name;
        public string Email { get; private set; } = email;
    }

    public static class UserFactory
    {
        public static IUser CreateUser(string type, string name, string email)
        {
            return type switch
            {
                "Regular" => new RegularUser(name, email),
                "Premium" => new PremiumUser(name, email),
                _ => throw new ArgumentException("Invalid user type")
            };
        }
    }
    
}