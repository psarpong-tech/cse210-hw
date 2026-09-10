// I added an extra menu option to delete a journal file.
// I added a time to the entries, and added nore prompts to my promptgenerator file
// I also added a code to ask of the health of the user immediately they run the program
// and save it once to the journal file and entries, and also added a closing message 
// when user chooses the Quit option

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.Write("What is your health today? ");
        journal._health = Console.ReadLine();

        string pick = "";

        while (pick != "6")
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Delete a journal file");
            Console.WriteLine("6. Quit");

            pick = Console.ReadLine();
            if (pick == "1")
            {
                string prompt = promptGenerator.GenerateRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();

                Entry newEntry = new Entry();
                newEntry._date = date;
                newEntry._time = time;
                newEntry._promptText = prompt;
                newEntry._textEntry = response;

                journal.AddEntry(newEntry);
            }
            else if (pick == "2")
            {
                journal.DisplayAll();
            }
            else if (pick == "3")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (pick == "4")
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (pick == "5")
            {
                Console.Write("Enter the filename you want to delete: ");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    File.Delete(filename);
                    Console.WriteLine("File deleted successfully.");
                }
            }
            else if (pick == "6")
            {
                Console.WriteLine("Nice having you today");
                Console.WriteLine("Don't forget to drink a lot of water");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}