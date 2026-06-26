using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        private readonly Chatbot _chatbot;
        private readonly TaskManager _taskManager;
        private readonly ActivityLogger _activityLogger;
        private readonly QuizManager _quizManager;

        private ObservableCollection<CyberTask> _tasks = new ObservableCollection<CyberTask>();

        public MainWindow()
        {
            InitializeComponent();

            _activityLogger = new ActivityLogger();
            _taskManager = new TaskManager(_activityLogger);
            _quizManager = new QuizManager();
            _chatbot = new Chatbot(_taskManager, _activityLogger, _quizManager);

            AppendToChat("Bot", _chatbot.GetWelcomeMessage(), Colors.Cyan);

            LoadTasksIntoUI();
            RefreshActivityLog();
            ShowPanel(ChatPanel);
        }

        private void ShowPanel(Grid panel)
        {
            ChatPanel.Visibility = Visibility.Collapsed;
            TasksPanel.Visibility = Visibility.Collapsed;
            QuizPanel.Visibility = Visibility.Collapsed;
            LogPanel.Visibility = Visibility.Collapsed;
            panel.Visibility = Visibility.Visible;
        }

        private void NavChat_Click(object sender, RoutedEventArgs e) => ShowPanel(ChatPanel);
        private void NavTasks_Click(object sender, RoutedEventArgs e) => ShowPanel(TasksPanel);
        private void NavQuiz_Click(object sender, RoutedEventArgs e) => ShowPanel(QuizPanel);
        private void NavLog_Click(object sender, RoutedEventArgs e) => ShowPanel(LogPanel);

        private void BtnSend_Click(object sender, RoutedEventArgs e) => SendUserMessage();
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SendUserMessage();
        }

        private void SendUserMessage()
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AppendToChat("You", input, Colors.Yellow);
            string response = _chatbot.ProcessInput(input);
            AppendToChat("Bot", response, Colors.Cyan);

            txtInput.Clear();
            rtbChat.ScrollToEnd();

            LoadTasksIntoUI();
            RefreshActivityLog();
        }

        private void AppendToChat(string sender, string message, Color color)
        {
            var p = new Paragraph();
            p.Inlines.Add(new Run(sender + ": ") { FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush(color) });
            p.Inlines.Add(new Run(message));
            rtbChat.Document.Blocks.Add(p);
        }

        private void LoadTasksIntoUI()
        {
            _tasks.Clear();
            foreach (var t in _taskManager.GetAllTasks()) _tasks.Add(t);
            // lvTasks.ItemsSource = _tasks; // Add ListView in XAML if needed
        }

        private void RefreshActivityLog()
        {
            rtbActivityLog.Document.Blocks.Clear();
            rtbActivityLog.Document.Blocks.Add(new Paragraph(new Run(_activityLogger.GetRecentLog(12))));
        }

        // Menu Handlers
        private void MenuNewTask_Click(object sender, RoutedEventArgs e) => ShowPanel(TasksPanel);
        private void MenuStartQuiz_Click(object sender, RoutedEventArgs e) => ShowPanel(QuizPanel);
        private void MenuExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void MenuRefreshAll_Click(object sender, RoutedEventArgs e) => LoadTasksIntoUI();
        private void MenuClearLog_Click(object sender, RoutedEventArgs e) => rtbActivityLog.Document.Blocks.Clear();
        private void MenuHowToUse_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Use natural language in chat.");
        private void MenuAbout_Click(object sender, RoutedEventArgs e) => MessageBox.Show("PROG6221 Part 3 Project");
    }
}