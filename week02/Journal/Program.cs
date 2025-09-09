using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;

        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

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
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                Console.Write(">");
                string userEntryText = Console.ReadLine();
                
                Entry anEntry = new Entry();
                anEntry._date = DateTime.Now.ToShortDateString();
                anEntry._promptText = randomPrompt;
                anEntry._entryText = userEntryText;

                theJournal.AddEntry(anEntry);
                Console.WriteLine("\nSaved!");
                Console.WriteLine("Press enter to go back to welcome page.");
                Console.ReadKey();
            } 
            else if (choice =="2")
            {
                theJournal.DisplayAll();
                Console.WriteLine("Press enter to go back to welcome page.");
                Console.ReadKey();
            }
            else if (choice =="3")
            {
                Console.WriteLine("Enter the filename to load: ");
                Console.Write(">");
                string fileName = Console.ReadLine();
                theJournal.LoadFromFile(fileName);
                Console.WriteLine("Press enter to go back to welcome page.");
                Console.ReadKey();
            }
            
            else if (choice == "4")
            {
                Console.WriteLine("Enter the name for your file:  (No special characters e.g format:text.txt)");
                Console.Write(">");
                string fileName = Console.ReadLine();

                theJournal.SaveToFile(fileName);
                Console.WriteLine("Press enter to go back to welcome page.");
                Console.ReadKey();
            }
            else if(choice == "5")
            {
                Console.WriteLine("See you next time!");
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid Choice. Press any key to try again.");
                Console.WriteLine("Press enter to go back to welcome page.");
                Console.ReadKey();
            }
        }
    }        
}
