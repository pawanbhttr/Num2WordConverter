using System;

namespace Num2WordConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Console.ReadLine();
            Console.WriteLine(new Num2Word().ConvertToWord(num));
        }
    }
}
