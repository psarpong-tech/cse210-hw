using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public string _health;
    public List<Entry> _entries = new List<Entry>();
    public void DisplayAll()
    {
        Console.WriteLine($"Today's health: {_health}");
        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Health|{_health}");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._time}|{entry._promptText}|{entry._textEntry}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        _health = lines[0].Split('|')[1];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            Entry entry = new Entry();

            entry._date = parts[0];
            entry._time = parts[1];
            entry._promptText = parts[2];
            entry._textEntry = parts[3];

            _entries.Add(entry);
        }
    }
}