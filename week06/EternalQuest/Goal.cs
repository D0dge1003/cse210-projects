public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    public abstract void RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_shortName},{_description},{_points}";
    }

    public virtual int GetPoints()
    {
        return _points;
    }

    public virtual bool IsComplete()
    {
        return false;
    }
}