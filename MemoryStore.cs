using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

public class MemoryStore
{
    private readonly List<string> _conversationHistory = new List<string>();
    private readonly Dictionary<string, string> _userPreferences = new Dictionary<string, string>();

    public void AddToHistory(string userInput, string botResponse)
    {
        if (_conversationHistory.Count > 20) // Keep only last 20 exchanges
            _conversationHistory.RemoveAt(0);

        _conversationHistory.Add($"You: {userInput}");
        _conversationHistory.Add($"Bot: {botResponse}");
    }

    public string GetRecentHistory(int count = 5)
    {
        if (_conversationHistory.Count == 0)
            return "No conversation history yet.";

        var recent = _conversationHistory.TakeLast(count * 2).ToList();
        return string.Join("\n", recent);
    }

    public void RememberPreference(string key, string value)
    {
        _userPreferences[key.ToLower()] = value;
    }

    public string RecallPreference(string key)
    {
        return _userPreferences.TryGetValue(key.ToLower(), out string? value) ? value : null;
    }

    public void ClearHistory()
    {
        _conversationHistory.Clear();
    }
}
