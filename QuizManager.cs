

namespace CyberSecurityChatBot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace CybersecurityChatBot
    {
        public class QuizManager
        {
            private List<QuizQuestion> _questions = new List<QuizQuestion>();
            private int _currentIndex = 0;
            private int _score = 0;

            public QuizManager()
            {
                PopulateQuestions();
            }

            private void PopulateQuestions()
            {
                _questions.AddRange(new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What should you do if you receive an email asking for your password?",
                    Options = new List<string> { "A) Reply with password", "B) Delete the email", "C) Report as phishing", "D) Ignore it" },
                    CorrectAnswer = "C",
                    Explanation = "Correct! Reporting phishing helps protect you and others."
                },
                new QuizQuestion
                {
                    Question = "Which is the strongest password?",
                    Options = new List<string> { "A) Password123", "B) MyDog2025", "C) P@ssw0rd!", "D) Tr0ub4dor&3x!" },
                    CorrectAnswer = "D",
                    Explanation = "Strong passwords mix letters, numbers, and symbols."
                },
                new QuizQuestion
                {
                    Question = "What does HTTPS mean?",
                    Options = new List<string> { "A) HyperText Transfer Protocol Secure", "B) High Transfer Protocol", "C) Hidden Text Protocol", "D) None of the above" },
                    CorrectAnswer = "A",
                    Explanation = "HTTPS encrypts data between browser and website."
                },
                new QuizQuestion
                {
                    Question = "Should you reuse the same password on multiple sites?",
                    Options = new List<string> { "A) Yes", "B) No", "C) Only for unimportant sites", "D) It doesn't matter" },
                    CorrectAnswer = "B",
                    Explanation = "Reusing passwords increases risk if one account is breached."
                },
                new QuizQuestion
                {
                    Question = "What is Two-Factor Authentication (2FA)?",
                    Options = new List<string> { "A) Two passwords", "B) Extra verification via phone/email", "C) Two computers", "D) Backup files" },
                    CorrectAnswer = "B",
                    Explanation = "2FA adds a strong second layer of security."
                },
                new QuizQuestion
                {
                    Question = "What is social engineering?",
                    Options = new List<string> { "A) Hacking software", "B) Manipulating people to reveal info", "C) Building networks", "D) Writing viruses" },
                    CorrectAnswer = "B",
                    Explanation = "Humans are often the weakest link in security."
                },
                new QuizQuestion
                {
                    Question = "Is public Wi-Fi safe without a VPN?",
                    Options = new List<string> { "A) Yes", "B) No", "C) Only for browsing", "D) Only if password protected" },
                    CorrectAnswer = "B",
                    Explanation = "Public Wi-Fi traffic can be intercepted."
                },
                new QuizQuestion
                {
                    Question = "What should you do if you suspect malware?",
                    Options = new List<string> { "A) Ignore it", "B) Run antivirus scan", "C) Restart PC", "D) Download more software" },
                    CorrectAnswer = "B",
                    Explanation = "Run a full scan with trusted antivirus software."
                },
                new QuizQuestion
                {
                    Question = "True or False: You should click links in unsolicited emails.",
                    Options = new List<string> { "A) True", "B) False" },
                    CorrectAnswer = "B",
                    Explanation = "Never click links in suspicious emails."
                },
                new QuizQuestion
                {
                    Question = "What is ransomware?",
                    Options = new List<string> { "A) Steals data", "B) Encrypts files and demands ransom", "C) Speeds up PC", "D) Backup tool" },
                    CorrectAnswer = "B",
                    Explanation = "Maintain backups and never pay the ransom."
                },
                new QuizQuestion
                {
                    Question = "Why keep your software updated?",
                    Options = new List<string> { "A) New features", "B) Patch security vulnerabilities", "C) Better graphics", "D) Use more storage" },
                    CorrectAnswer = "B",
                    Explanation = "Updates fix critical security holes."
                }
            });
            }

            public QuizQuestion GetCurrentQuestion() => _currentIndex < _questions.Count ? _questions[_currentIndex] : null!;

            public bool SubmitAnswer(string answer)
            {
                var q = GetCurrentQuestion();
                if (q == null) return false;

                bool correct = answer.Trim().ToUpper().StartsWith(q.CorrectAnswer);
                if (correct) _score++;
                _currentIndex++;
                return correct;
            }

            public bool IsFinished() => _currentIndex >= _questions.Count;
            public string GetCurrentScore() => _score.ToString();
            public int GetTotalQuestions() => _questions.Count;
            public string GetFinalScore() => $"{_score} / {_questions.Count}";

            public string GetFinalMessage()
            {
                double percent = (double)_score / _questions.Count * 100;
                if (percent >= 90) return "🏆 Excellent! Cybersecurity Champion!";
                if (percent >= 70) return "🎉 Great Job!";
                if (percent >= 50) return "👍 Good effort. Keep learning.";
                return "📚 Keep studying cybersecurity best practices.";
            }

            public string GetFeedback(bool correct)
            {
                return correct ? "✅ Correct!" : $"❌ Incorrect. {GetCurrentQuestion()?.Explanation}";
            }

            public void Reset()
            {
                _currentIndex = 0;
                _score = 0;
            }
        }
    }
}

