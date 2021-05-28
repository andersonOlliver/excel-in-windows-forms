using System;
using System.Text;

namespace Dotnet.Teste.Core.Util
{
    
    public class RandomGenerator
    {
        private readonly Random _random = new Random();
        private readonly DateTime _start = new DateTime(1993, 12, 5);

        // Reference: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/  
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Reference: https://stackoverflow.com/a/1064907/7143045
        public double RandomNumber(double minimum, double maximum)
        {
            return _random.NextDouble() * (maximum - minimum) + minimum;
        }

        // Reference: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/ 
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            
            var offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; 

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        // Reference: https://stackoverflow.com/a/194870/7143045
        public DateTime RandomDateTime()
        {
            var range = (DateTime.Today - _start).Days;
            return _start.AddDays(_random.Next(range));
        }
    }
}
