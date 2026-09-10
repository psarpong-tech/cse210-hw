using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "How many new connections did I make today?",
        "How many jobs did I apply for today?",
        "What was the best part of my day?",
        "How many pages of the scripture did I read today?",
        "Did I learn something new today? What was it?",
        "What challenge did I overcome today?",
        "What nearly ruined my day?",
        "Who on my contact list did I reach out to today?",
        "What is something I am grateful for today?",
        "How many new opportunities did I get today?",
        "How did I overcome today's challenge?",
        "Overall, how did my day go?",
        "Did I take a step toward my goal? what was it?"
    };

    public string GenerateRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}