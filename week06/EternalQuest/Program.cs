// I added a level-up system that calculates a player's level from their score
// and displays achievement titles to make progress more motivating.
// Users can also choose their own filenames when saving and loading their goals.


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}