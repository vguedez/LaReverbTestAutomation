using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Generators
{
    public static class RandomGenerator
    {
        public static int RandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int index = 0; index < size; index++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static List<string> GetRandomStringList(int listLength, int stringLength)
        {
            List<string> randomTextList = new List<string>();
            int index = 0;
            while (index < listLength) 
            {
                randomTextList.Add(RandomGenerator.RandomString(stringLength));
                index++; 
            }

            return randomTextList;
        }
    }
}
