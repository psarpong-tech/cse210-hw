using System;
using System.Collections.Generic;

public class Entry
{
    public string _date;
    public string _time;
    public string _promptText;
    public string _textEntry;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Time: {_time}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_textEntry}");
        Console.WriteLine();
    }
}