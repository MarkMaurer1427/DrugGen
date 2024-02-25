using DrugGen.Common;
using DrugGen.DrugValues;
using DrugGen.Name;
using DrugGen.Repo;

namespace DrugGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            DrugGenerator drugGen = new DrugGenerator();

            Console.WriteLine("Welcome to Mark's Drug Generator");
            Console.WriteLine();

            while (running)
            {
                string input = "";
                Console.WriteLine();
                Console.Write("Generate a new drug? Y/N: ");
                bool haveInput = false;
                while (haveInput == false)
                {
                    input = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    if (input == "y" ||  input == "n" || input == "c") {haveInput = true;}
                    else
                    {
                        Console.WriteLine("That's not \'y\' or \'n\'. ");
                        Console.Write("Generate a new drug? Y/N: ");
                    }
                }
                Console.WriteLine();
                if (input == "y")
                {
                    Console.WriteLine();
                    Drug d = drugGen.GenerateDrug();
                    d.PrintDrug();

                }
                else if (input == "n"){ running = false; }
                else if (input == "c")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Console.WriteLine();
                        Drug d = drugGen.GenerateDrug();
                        d.PrintDrug();
                    }
                }

            }
            drugGen.ExportAll();
        }
    }
}