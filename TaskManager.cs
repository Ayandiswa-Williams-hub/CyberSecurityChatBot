using CybersecurityChatbot;
using CyberSecurityChatBot;
using CyberSecurityChatBot.CybersecurityChatBot;
using CyberSecurityChatBot.CybersScurityChatBot;
using System.Collections.Generic;

namespace CyberSecurityChatBot
{
    public class TaskManager
    {
        private readonly TaskStorageHelper _storage;
        private readonly ActivityLogger _logger;

        public TaskManager(ActivityLogger logger)
        {
            _storage = new TaskStorageHelper();
            _logger = logger;
        }

        public string AddTask(string title, string description, string reminder = "")
        {
            int taskId = _storage.AddTask(title, description, reminder);

            string reminderInfo = string.IsNullOrEmpty(reminder)
                ? "(no reminder)"
                : $"(Reminder: {reminder})";

            _logger.Log($"Task added: '{title}' {reminderInfo} (ID: {taskId})");

            return $"✅ Task added successfully: '{title}'";
        }

        public List<CyberTask> GetAllTasks()
        {
            return _storage.LoadTasks();
        }

        public void MarkComplete(int id)
        {
            if (_storage.MarkAsComplete(id))
            {
                _logger.Log($"Task marked complete: ID {id}");
            }
        }

        public void Delete(int id)
        {
            if (_storage.DeleteTask(id))
            {
                _logger.Log($"Task deleted: ID {id}");
            }
        }
    }
}
