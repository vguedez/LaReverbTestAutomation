namespace TestFramework.Generators
{
    public static class PasswordGenerator
    {
        private static bool toggle = true;

        public static string GetRandomPassword()
        {
            var password = "";
            password = toggle ? "Password" : "New Password";

            toggle = !toggle;
            LastGeneratedPassword = password;
            return password;
        }

        public static string LastGeneratedPassword { get; set; }
    }
}
