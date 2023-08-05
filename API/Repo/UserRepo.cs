namespace API.Repo
{
    public class UserRepo
    {
        public static List<User> Users = new()
        {
            new() { UserName = "user", EmailAddress = "user@email.com", Password = "123", GivenName = "user", Surname = "user", Role = "Administrator" },
            new() { UserName = "lydia_standard", EmailAddress = "lydia.standard@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Burton", Role = "Standard" },
        };
    }
}
