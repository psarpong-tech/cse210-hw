using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2026, 9, 13), 20, 4.0));
        activities.Add(new Cycling(new DateTime(2026, 10, 12), 10, 10.0));
        activities.Add(new Swimming(new DateTime(2026, 10, 14), 50, 25));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

    