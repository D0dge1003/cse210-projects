public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int timeElapsed = 0;
        while (timeElapsed < Duration)
        {
            Console.Write("\nBreathe in...");
            CountDown(4);
            Console.Write("\nBreathe out...");
            CountDown(6);
            timeElapsed += 10;
        }

        DisplayEndingMessage();
    }
}