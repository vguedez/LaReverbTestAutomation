namespace TestFramework.Generators
{
    public class EmailAddressGenerator
    {
        public static string GetRandomEmailAddress()
        {
            return RandomGenerator.RandomString(6) + "@lareverb.com";
        }
    }
}
