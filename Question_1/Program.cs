using Questions.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringModulator();
        }

        public static void StringModulator()
        {
            while (true)
            {
                Console.WriteLine("Question 1");
                Console.WriteLine("-----------------------");
                Console.WriteLine();
                Console.Write("Enter Word: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string word = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(word))
                {
                    var result = Question1.InGenericSort(word);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Output: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{result}");
                }
                else
                    Console.WriteLine("Input can not be null");


                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);

                Console.Write("Do you want to try again? y/n: ");

                string confirm = Console.ReadLine();

                if (confirm.ToLower() == "y")
                    Console.Clear();
                else
                    Environment.Exit(0);

            }
        }
    }
}
