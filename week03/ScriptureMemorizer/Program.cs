using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Scripture Memorizer!");
        Reference reference = new Reference("Alma", 46, 15);
        string text = "And those who did belong to the church were faithful; yea, all those who were true believers in Christ took upon them, gladly, the name of Christ, or Christians as they were called, because of their belief in Christ who should come.";
        Scripture scripture = new Scripture(reference, text);

        string input = "";
        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish. (Enter ('hint') to show hints)");
            Console.Write(">");
            input = Console.ReadLine();

            if (input == "")
            {
                scripture.HideRandomWords(3);
            }
            else if (input.ToLower() == "hint") //gives the user hints, (Exceeding Requirements)
            {
                scripture.ShowRandomWord();
            }
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("See you Next time!");

    }
}