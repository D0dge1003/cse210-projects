public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"\nWell done! You have recorded progress on '{_shortName}' and earned {_points} points.");
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) - Eternal Goal";
    }
}