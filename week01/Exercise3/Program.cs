using System;

class Program
{
    static void Main(string[] args)
    {
        int guessCount = 0;
        string playAgain="yes";
        while(playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);

            Console.WriteLine("The randomly generated number: " + number);

            bool keepPlaying = true;
            while(keepPlaying)
            {
                Console.Write("What is your guess?:  ");
                string input2 = Console.ReadLine();
                int guess = int.Parse(input2);
                guessCount ++;

                if (number == guess)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine("You guessed it in " +guessCount+  " guesses!");
                    keepPlaying = false;
                }
                else if(number >= guess)
                {
                    Console.WriteLine("Higher!");
                }
                else
                {
                    Console.WriteLine("Lower!");
                }

            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        
        }
        Console.WriteLine("Thanks for playing");
    }
}