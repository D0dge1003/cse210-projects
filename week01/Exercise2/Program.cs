using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade: ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);

        if (number >=90)
        {
            string letter = "A";
            Console.WriteLine($"Your grade is: {letter}");
        }
        else if(number >=80)
        {
            string letter = "B";
            Console.WriteLine($"Your grade is: {letter}");
        }
        else if(number >=70)
        {
            string letter = "C";
            Console.WriteLine($"Your grade is: {letter}");
        }
        else if(number >=60)
        {
            string letter = "D";
            Console.WriteLine($"Your grade is: {letter}");
        }
        else
        {
            string letter = "F";
            Console.WriteLine($"Your grade is: {letter}");
        }

        Console.WriteLine("A>=90\nB>=80\nC=>70\nD>=60\nF<60");



        if(number >70)
        {
            Console.WriteLine("Congratulations you passed, great work!");
        }
        else
        {
            Console.WriteLine("Unfortunately you didn't meet the required grades to pass, better luck next time!");
        }


    }
}