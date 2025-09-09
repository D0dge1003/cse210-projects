using System;
using System.Collections.Generic;
using System.IO;
public class Journal
{   
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal Empty, Write an entry (1) or load a file. (3)");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            if(parts.Length == 3)
            {
                Entry newEntry = new Entry();
                newEntry._date = parts[0];
                newEntry._promptText = parts[1];
                newEntry._entryText = parts[2];
                _entries.Add(newEntry);
            }
        }
        Console.WriteLine($"Journal successfully loaded from '{fileName}'.");
        }
    }
}