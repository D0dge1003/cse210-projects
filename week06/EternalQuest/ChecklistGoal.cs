public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            Console.WriteLine($"\nProgress made on '{_shortName}'. You earned {_points} points.");

            if (IsComplete())
            {
                Console.WriteLine($"\n*** CONGRATULATIONS! You completed '{_shortName}'! ***");
                Console.WriteLine($"You earned a {_bonus} point bonus!");
            }
        }
        else
        {
            Console.WriteLine($"\nYou already completed '{_shortName}'. No new points awarded.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }

    public override int GetPoints()
    {
        if (IsComplete())
        {
            return _points + _bonus;
        }
        else
        {
            return _points;
        }
    }
}