using Questions.Library.Controller;
using Questions.Library.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UniverseStimulator();

        }

        public static void UniverseStimulator()
        {
            IUniversManager _universeManager = new UniversManager();

            while (true)
            {
                Console.WriteLine("Question 2");
                Console.WriteLine("Conway's Game of Life");
                Console.WriteLine("-----------------------");

                try
                {
                    Console.WriteLine("Configure Board");
                    Console.Write("Enter Board Length:");
                    int lengthKey = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Board Height:");
                    int heightKey = Convert.ToInt32(Console.ReadLine());

                    bool configureBoard = _universeManager.ConfigureBoard(lengthKey, heightKey);

                    Console.WriteLine();
                    Console.WriteLine("Configure Generation");
                    Console.Write("Enter number of Geneation:");
                    int generationKey = Convert.ToInt32(Console.ReadLine());
                    _universeManager.ConigureUniversGeneration(generationKey);

                    if (_universeManager.LoadCells())
                        _universeManager.RunUniverseLivespan();

                    Console.Write("Do you want to try again? y/n");
                    string confirm = Console.ReadLine();

                    if (confirm == "y")
                        Console.Clear();
                    else
                        Environment.Exit(0);

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
