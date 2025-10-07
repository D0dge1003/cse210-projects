using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private string GetLevel()
{
    if (_score >= 5000)
    {
        return "Grand Master (Level 5)";
    }
    else if (_score >= 2500)
    {
        return "Champion (Level 4)";
    }
    else if (_score >= 1000)
    {
        return "Veteran (Level 3)";
    }
    else if (_score >= 300)
    {
        return "Apprentice (Level 2)";
    }
    else
    {
        return "Novice (Level 1)";
    }
}

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou currently have {_score} points.");

        // ADDED LINE: Display the level
        Console.WriteLine($"Current Rank: {GetLevel()}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation cancelled.");
                return;
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine($"\nGoal '{name}' created successfully!");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            bool wasCompleteBefore = goal.IsComplete();

            goal.RecordEvent();

            int pointsEarned = goal.GetPoints();
            if (goal.GetType().Name == "ChecklistGoal" && !wasCompleteBefore && goal.IsComplete())
            {
                _score += pointsEarned;
            }
            else if (goal.GetType().Name != "SimpleGoal" || !wasCompleteBefore)
            {
                _score += goal.GetPoints();
            }
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void SaveGoals(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals and score saved successfully to '{filename}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile '{filename}' not found. Starting with a new score and no goals.");
            _goals.Clear();
            _score = 0;
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);

            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(
                            details[0],
                            details[1],
                            int.Parse(details[2]),
                            bool.Parse(details[3])
                        ));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(
                            details[0],
                            details[1],
                            int.Parse(details[2])
                        ));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(
                            details[0],
                            details[1],
                            int.Parse(details[2]),
                            int.Parse(details[3]),
                            int.Parse(details[4]),
                            int.Parse(details[5])
                        ));
                        break;
                }
            }
            Console.WriteLine($"\nGoals and score loaded successfully from '{filename}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while loading. Data may be corrupted: {ex.Message}");
            _goals.Clear();
            _score = 0;
        }
        
    }
}