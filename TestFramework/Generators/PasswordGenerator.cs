using System.Text;

namespace TestFramework.Generators
{
    public static class PasswordGenerator
    {
        private static bool toggle = true;

        public static string GetRandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomGenerator.RandomString(4));
            builder.Append(RandomGenerator.RandomNumber(1000, 9999));
            builder.Append(RandomGenerator.RandomString(2));

            return builder.ToString();
        }

        public static string LastGeneratedPassword { get; set; }
    }
}
