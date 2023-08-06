using Service.Models;

namespace Service
{
    public class UserRepo
    {
        public static List<User> Users = new()
        {
            new() { UserName = "user", EmailAddress = "user@email.com", Password = "123", GivenName = "user", Surname = "user", Role = "Administrator" },
            new() { UserName = "other_user", EmailAddress = "other_user@email.com", Password = "MyPass_w0rd", GivenName = "Max", Surname = "Raz", Role = "Standard" },
        };
    }
}
