using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
    {
        public class ActivityLogger
        {
            private readonly List<string> _logEntries = new List<string>();

          
            public void Log(string action)
            {
                string entry = $"[{DateTime.Now:HH:mm:ss}] {action}";
                _logEntries.Add(entry);

               
                if (_logEntries.Count > 100)
                    _logEntries.RemoveAt(0);
            }

        
            public string GetRecentLog(int count = 10)
            {
                if (_logEntries.Count == 0)
                    return "No activities recorded yet.";

                var recent = _logEntries.TakeLast(count).ToList();

                return string.Join("\n", recent.Select((entry, index) =>
                    $"{index + 1}. {entry}"));
            }

     
            public string GetFullLog()
            {
                if (_logEntries.Count == 0)
                    return "No activities recorded yet.";

                return string.Join("\n", _logEntries.Select((entry, index) =>
                    $"{index + 1}. {entry}"));
            }

            public int GetCount() => _logEntries.Count;

    
            public void Clear()
            {
                _logEntries.Clear();
            }
        }
    }
