using System;
using System.IO;

namespace V5DataGenerator
{
    public class Program
    {
        private static readonly Random Random = new Random();

        static float NextFloat()
        {
            double mantissa = (Random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, Random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        static void Main(string[] args)
        {
            using var streamWriter = new StreamWriter("V5Data.txt");
            for (int i = 0; i < 100; i++)
            {
                streamWriter.WriteLine($"{NextFloat()} {NextFloat()} {NextFloat()} {NextFloat()}");
            }
        }
    }
}
