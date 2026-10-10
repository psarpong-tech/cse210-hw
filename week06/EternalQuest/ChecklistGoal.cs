public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description,
        int points, int target, int bonus)
        : this(name, description, points, target, bonus, 0)
    {
    }

    public ChecklistGoal(string name, string description,
        int points, int target, int bonus,
        int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

        public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        int earnedPoints = GetPoints();

        if (_amountCompleted == _target)
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {GetShortName()} - {GetDescription()} " +
               $"Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
