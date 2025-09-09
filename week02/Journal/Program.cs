using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;

        while(isRunning)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please Select one of the following choices:");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Load");
            Console.WriteLine("4.Save");
            Console.WriteLine("5.Quit");

            Console.Write("What would you like to do?:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("If I had one thing I could do over today what would it be?");
                string entry = Console.ReadLine();
            } 
            else if(choice == "2")
            {
                foreach 
            }
            else if(choice == "3")
            {

            }
            else if (choice == "4")
            {
                Console.WriteLine("Enter the name for your file:");
                string fileName = Console.ReadLine();

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                Journal fileManager = new Journal();
                fileManager.SaveToFile(filePath);
            }
            else if(choice == "5")
            {
                Console.WriteLine("See you next time!");
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid Choice. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }        
}
