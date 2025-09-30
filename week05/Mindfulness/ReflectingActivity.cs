public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectingActivity()
    {
        Name = "Reflecting Activity";
        Description = "This activity will help you reflect on time in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is you favorite thing about this experience",
            "What could you learn about yourself through this experience?",
            "How can you use this experience to your advantage in the future?"
        };
    }
    public override void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            DisplayQuestions();
        }
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }
    public void DisplayPrompt()
    {
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n---{GetRandomPrompt()}---\n");
        Console.WriteLine("WHen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now, ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.Clear();
    }
    public void DisplayQuestions()
    {
        Console.Write($"> {GetRandomQuestion()}");
        ShowSpinner(10);
        Console.WriteLine();
    }
}