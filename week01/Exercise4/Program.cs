using System;
using System.Collections.Generic;
using System.Collections.Immutable;


class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numberInput = -1;
        while (numberInput != 0)
        {
            Console.Write("Enter a number (enter 0 to quit): ");

            string userInput = Console.ReadLine();
            numberInput = int.Parse(userInput);

            if (numberInput != 0)
            {
                numbers.Add(numberInput);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = -1;
        foreach (int number in numbers)
            {
                if (number > largest)
                {
                    largest = number;
                }
                    
            }       
        Console.WriteLine($"The largest number is: {largest}");

    }
}
