using System;

class Program
{
    static void Main(string[] args)
    {
        
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            Random magicNumber = new Random();
            int number = magicNumber.Next(1, 101);
            
            int guessedNumber = 0;

            int guessCount = 0;

            while (guessedNumber != number)
            {
                Console.Write("Enter the magic number: ");
                guessedNumber = int.Parse(Console.ReadLine());
                guessCount++;

                if (guessedNumber < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guessedNumber > number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed right!");
                }
            }
            Console.WriteLine($"You made {guessCount} guesses."); 


            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine(); 


        }
        Console.WriteLine("Thank you for playing");

        
    }
    
}

   