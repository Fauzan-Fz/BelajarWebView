using System;

namespace PuppeteerWebView
{
    public class RandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator()
        {
            _random = new Random();
        }

        /// <summary>
        /// Menghasilkan angka acak dari min hingga max (inklusif).
        /// </summary>
        /// <returns>Integer acak antara min dan max</returns>
        public int RandomNumber(int min, int max)
        {
            if (min > max)
                throw new ArgumentException("Min harus lebih kecil atau sama dengan Max");

            return _random.Next(min, max + 1); // max + 1 karena .Next eksklusif di batas atas
        }
    }
}