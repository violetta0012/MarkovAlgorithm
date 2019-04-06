using System;
using System.Collections.Generic;
using System.IO;

namespace MarkovAlgorithm
{
    internal class Program
    {
        private static Scheme ReadScheme()
        {
            var lst = new List<string>();
            while (true)
            {
                var str = Console.ReadLine();
                if (str.Equals("END"))
                    break;
                lst.Add(str);
            }

            return new Scheme(lst);
        }

        private const string Instructions = "Введите схемы подстановок по одной в строке. По завершении введите END.\na" +
                                            "Примеры подстановок: \nxx -> x \nxy ->. y";

        public static void Main(string[] args)
        {
            Console.WriteLine(Instructions);
            var scheme = ReadScheme();
            Console.WriteLine("Введите слово для применения");
            var word = Console.ReadLine();
            scheme.Apply(word);
        }
    }
}