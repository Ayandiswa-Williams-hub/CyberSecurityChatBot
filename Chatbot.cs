using System;
using System.Text;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private readonly TaskManager _taskManager;
        private readonly ActivityLogger _activityLogger;
        private readonly QuizManager _quizManager;

        private readonly KeywordResponder _keywordResponder = new KeywordResponder();
        private readonly SentimentDetector _sentimentDetector = new SentimentDetector();
        private readonly MemoryStore _memoryStore = new MemoryStore();

        public Chatbot(TaskManager taskManager, ActivityLogger activityLogger, QuizManager quizManager)
        {
            _taskManager = taskManager;
            _activityLogger = activityLogger;
            _quizManager = quizManager;
        }

        public string ProcessInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "Please enter something.";

            string originalInput = userInput.Trim();
            string input = originalInput.ToLower();

          
            if (ContainsAny(input, "add task", "add a task", "create task", "new task"))
            {
                string taskTitle = ExtractTaskTitle(originalInput);
                string response = _taskManager.AddTask(taskTitle, "Added via chatbot conversation");

                _activityLogger.Log($"NLP recognised task: '{originalInput}'");
                _memoryStore.AddToHistory(originalInput, response);

                return response + "\n\nWould you like to set a reminder?";
            }

            if (ContainsAny(input, "remind me", "set reminder", "reminder for"))
            {
                _activityLogger.Log($"Reminder set: '{originalInput}'");
                _memoryStore.AddToHistory(originalInput, "Reminder noted");
                return $"✅ Reminder noted: '{originalInput}'";
            }

            if (ContainsAny(input, "start quiz", "take quiz", "quiz me", "play quiz"))
            {
                _quizManager.Reset();
                _activityLogger.Log("Quiz started via chat");
                _memoryStore.AddToHistory(originalInput, "Quiz started");
                return "🎮 Quiz started! Go to the Quiz panel.";
            }

            if (ContainsAny(input, "show activity log", "what have you done", "what did you do", "activity log"))
            {
                _activityLogger.Log("Activity log viewed");
                _memoryStore.AddToHistory(originalInput, "Log displayed");
                return "📜 Activity Log:\n" + _activityLogger.GetRecentLog(10);
            }

    
            string keywordResp = _keywordResponder.GetResponse(originalInput);
            if (!string.IsNullOrEmpty(keywordResp))
            {
                _activityLogger.Log($"Keyword matched: {originalInput}");
                _memoryStore.AddToHistory(originalInput, keywordResp);
                return keywordResp;
            }

            
            string sentiment = _sentimentDetector.AnalyzeSentiment(originalInput);
            string sentimentReply = _sentimentDetector.GetSentimentResponse(sentiment);
            if (!string.IsNullOrEmpty(sentimentReply))
            {
                _memoryStore.AddToHistory(originalInput, sentimentReply);
                return sentimentReply;
            }

           
            if (input.Contains("history") || input.Contains("remember"))
            {
                return "📖 Recent History:\n" + _memoryStore.GetRecentHistory(5);
            }

           
            _activityLogger.Log($"Unknown input: '{originalInput}'");
            _memoryStore.AddToHistory(originalInput, "Fallback");

            return "🤔 Sorry, I didn't understand. Try commands like:\n" +
                   "• add task Enable 2FA\n" +
                   "• start quiz\n" +
                   "• show activity log";
        }

        public string GetWelcomeMessage()
        {
            _activityLogger.Log("Application started");
            _memoryStore.AddToHistory("Welcome", "Bot greeting");

            return "🛡️ Welcome to Cybersecurity Awareness Bot!\n\n" +
                   "I can help you with:\n" +
                   "• Cybersecurity advice\n" +
                   "• Managing tasks\n" +
                   "• Taking the quiz\n" +
                   "• Viewing activity history\n\n" +
                   "Just type to begin!";
        }

        private bool ContainsAny(string text, params string[] keywords)
        {
            return keywords.Any(k => text.Contains(k));
        }

        private string ExtractTaskTitle(string input)
        {
            string title = input
                .Replace("add task", "", StringComparison.OrdinalIgnoreCase)
                .Replace("add a task", "", StringComparison.OrdinalIgnoreCase)
                .Replace("create task", "", StringComparison.OrdinalIgnoreCase)
                .Trim();

            return string.IsNullOrWhiteSpace(title) ? "Untitled Task" : title;
        }
    }
}