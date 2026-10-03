// I added a session counter that keeps track of
// how many mindfulness activities the user completes.

using System;

class Program
{
    static void Main(string[] args)
    {
        int activitiesCompleted = 0;

        string pick = "";

        while (pick != "4")
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu (enter numbers): ");

            pick = Console.ReadLine();

            if (pick == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                activitiesCompleted++;
            }
            else if (pick == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                activitiesCompleted++;
            }
            else if (pick == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                activitiesCompleted++;
            }
            else if (pick == "4")
            {
                Console.WriteLine();
                Console.WriteLine($"You completed {activitiesCompleted} mindfulness activities this session.");
                Console.WriteLine("Thank you for using the Mindfulness Program!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid choice. Please select a valid option.");
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}