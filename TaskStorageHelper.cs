using CyberSecurityChatBot.CybersecurityChatBot;
using CyberSecurityChatBot.CybersScurityChatBot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CybersecurityChatbot
    {
        public class TaskStorageHelper
        {
            private readonly string _filePath;

            public TaskStorageHelper()
            {
                // Store in the same folder as the executable
                _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");
            }

            public List<CyberTask> LoadTasks()
            {
                try
                {
                    if (File.Exists(_filePath))
                    {
                        string json = File.ReadAllText(_filePath);
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            return JsonConvert.DeserializeObject<List<CyberTask>>(json) ?? new List<CyberTask>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error loading tasks] {ex.Message}");
                }
                return new List<CyberTask>();
            }

            public void SaveTasks(List<CyberTask> tasks)
            {
                if (tasks == null) return;

                try
                {
                    string directory = Path.GetDirectoryName(_filePath);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    string json = JsonConvert.SerializeObject(tasks.OrderBy(t => t.Id), Formatting.Indented);
                    File.WriteAllText(_filePath, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error saving tasks] {ex.Message}");
                }
            }

            public int AddTask(string title, string description, string reminder)
            {
                var tasks = LoadTasks();
                int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

                var newTask = new CyberTask
                {
                    Id = newId,
                    Title = string.IsNullOrWhiteSpace(title) ? "Untitled Task" : title.Trim(),
                    Description = description?.Trim() ?? "",
                    Reminder = reminder?.Trim() ?? "",
                    IsComplete = false,
                    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                };

                tasks.Add(newTask);
                SaveTasks(tasks);

                return newId;
            }

            public bool MarkAsComplete(int id)
            {
                var tasks = LoadTasks();
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task == null) return false;

                task.IsComplete = true;
                SaveTasks(tasks);
                return true;
            }

            public bool DeleteTask(int id)
            {
                var tasks = LoadTasks();
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task == null) return false;

                tasks.Remove(task);
                SaveTasks(tasks);
                return true;
            }

            public string GetFilePath() => _filePath;
        }
    }

