namespace TestFramework.Generators
{
    public static class UserGenerator
    {
        public static User LastGeneratedUser;

        public static void Initialize()
        {
            LastGeneratedUser = null;
        }

        public static User Generate()
        {
            var user = new User
            {
                UserName = EmailAddressGenerator.GetRandomEmailAddress(),
                Password = PasswordGenerator.GetRandomPassword()
            };

            LastGeneratedUser = user;
            return user;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
    }
}
