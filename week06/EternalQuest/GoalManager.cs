using System;
using System.Collections.Generic;
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

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            DisplayPlayerInfo();

            Console.WriteLine("\n1. Create a new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Keep going on your Eternal Quest!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = _score / 1000 + 1;
        string title = level switch
        {
            1 => "Quest Beginner",
            2 => "Faithful Adventurer",
            3 => "Covenant Champion",
            _ => "Eternal Quest Master"
        };

        Console.WriteLine($"Score: {_score} points");
        Console.WriteLine($"Level: {level} - {title}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = ReadText("Choose a goal type: ");
        string name = ReadText("Enter the goal name: ");
        string description = ReadText("Enter the description: ");
        int points = ReadInt("Enter the points for each event: ");

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                int target = ReadInt("How many times must you complete it? ");

                while (target <= 0)
                {
                    Console.WriteLine("The target must be greater than zero.");
                    target = ReadInt("Enter the target: ");
                }

                int bonus = ReadInt("Enter the completion bonus: ");
                goal = new ChecklistGoal(
                    name, description, points, target, bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalNames();

        int choice = ReadInt("Enter the goal number: ");

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        if (selectedGoal is SimpleGoal && selectedGoal.IsComplete())
        {
            Console.WriteLine("That simple goal is already complete.");
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine($"You earned {earnedPoints} points!");
        DisplayPlayerInfo();
    }

    
    public void SaveGoals()
    {
        Console.Write("Enter a filename to save your goals: ");
        string fileName = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".txt";
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Save the current score.
                writer.WriteLine($"Score|{_score}");

                // Save each goal.
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals and score saved successfully to {fileName}.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Could not save goals: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied: {ex.Message}");
        }
    }

    
    public void LoadGoals()
    {
        Console.Write("Enter the filename to load your goals from: ");
        string fileName = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            fileName += ".txt";
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"The file '{fileName}' was not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);

            List<Goal> loadedGoals = new List<Goal>();
            int loadedScore = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Load the saved score.
                if (line.StartsWith("Score|"))
                {
                    if (int.TryParse(line.Substring(6), out int savedScore))
                    {
                        loadedScore = savedScore;
                    }

                    continue;
                }

                // Separate the goal type from its saved information.
                string[] typeAndData = line.Split(new[] { ':' }, 2);

                if (typeAndData.Length != 2)
                {
                    continue;
                }

                string type = typeAndData[0];
                string[] data = typeAndData[1].Split('|');

                if (data.Length < 3 ||
                    !int.TryParse(data[2], out int points))
                {
                    continue;
                }

                // Re-create the appropriate goal type.
                switch (type)
                {
                    case "SimpleGoal":
                        if (data.Length >= 4 &&
                            bool.TryParse(data[3], out bool complete))
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(
                                data[0],
                                data[1],
                                points
                            );

                            // Restore the goal's completion status.
                            if (complete)
                            {
                                simpleGoal.RecordEvent();
                            }

                            loadedGoals.Add(simpleGoal);
                        }
                        break;

                    case "EternalGoal":
                        loadedGoals.Add(
                            new EternalGoal(
                                data[0],
                                data[1],
                                points
                            )
                        );
                        break;

                    case "ChecklistGoal":
                        if (data.Length >= 6 &&
                            int.TryParse(data[3], out int target) &&
                            int.TryParse(data[4], out int bonus) &&
                            int.TryParse(data[5], out int completed))
                        {
                            loadedGoals.Add(
                                new ChecklistGoal(
                                    data[0],
                                    data[1],
                                    points,
                                    target,
                                    bonus,
                                    completed
                                )
                            );
                        }
                        break;
                }
            }

            
            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine(
                $"Goals and score loaded successfully from {fileName}."
            );
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Could not load goals: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied: {ex.Message}");
        }
    }


    private string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid whole number.");
        }
    }
}
