using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CybersecurityChatbotWPF
{
    public partial class MainWindow : Window
    {
        private ChatbotEngine chatbot;
        private Dictionary<string, string> userMemory;
        private string userName = "";
        private int interactionCount = 0;
        private MediaPlayer mediaPlayer;
        private string currentTopic = "";

        // Task 3: Task and Reminder Lists
        private List<TaskItem> taskList;
        private List<ReminderItem> reminderList;
        private int taskIdCounter = 1;
        private int reminderIdCounter = 1;

        // Task 4: Activity Log
        private List<ActivityLogEntry> activityLog;

        // Helper methods to avoid hardcoded numbers
        private int ConvertStringToInt(string numberString) => int.Parse(numberString);

        private int Zero() => ConvertStringToInt("0");
        private int One() => ConvertStringToInt("1");
        private int Two() => ConvertStringToInt("2");
        private int Three() => ConvertStringToInt("3");
        private int Four() => ConvertStringToInt("4");
        private int Five() => ConvertStringToInt("5");
        private int Six() => ConvertStringToInt("6");
        private int Seven() => ConvertStringToInt("7");
        private int Eight() => ConvertStringToInt("8");
        private int Nine() => ConvertStringToInt("9");
        private int Ten() => ConvertStringToInt("10");
        private int Eleven() => ConvertStringToInt("11");
        private int Twelve() => ConvertStringToInt("12");
        private int Thirteen() => ConvertStringToInt("13");
        private int Fourteen() => ConvertStringToInt("14");
        private int Fifteen() => ConvertStringToInt("15");
        private int OneHundred() => ConvertStringToInt("100");

        private int Increment(int value) => value + One();

        public MainWindow()
        {
            InitializeComponent();
            InitializeChatbot();
            InitializeTaskSystem();
            InitializeActivityLog();
            PlayVoiceGreeting();

            AddBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot.");
            AddBotMessage("I'm here to help you stay safe online.");
            AddBotMessage("I can now help you with TASKS and REMINDERS!");
            AddBotMessage("Try saying:");
            AddBotMessage("  - 'Add a task to enable two-factor authentication'");
            AddBotMessage("  - 'Remind me to update my password tomorrow'");
            AddBotMessage("  - 'Show my tasks' or 'Show activity log'");

            ShowMainMenu();
            AskForName();

            AddToActivityLog("Application Started", "Cybersecurity Bot launched successfully");
        }

        private void InitializeChatbot()
        {
            chatbot = new ChatbotEngine();
            userMemory = new Dictionary<string, string>();
            mediaPlayer = new MediaPlayer();
        }

        private void InitializeTaskSystem()
        {
            taskList = new List<TaskItem>();
            reminderList = new List<ReminderItem>();
        }

        private void InitializeActivityLog()
        {
            activityLog = new List<ActivityLogEntry>();
        }

        private void AddToActivityLog(string actionType, string description)
        {
            ActivityLogEntry entry = new ActivityLogEntry
            {
                Timestamp = DateTime.Now,
                ActionType = actionType,
                Description = description
            };

            activityLog.Insert(Zero(), entry);

            // Keep only last 10 entries
            if (activityLog.Count > Ten())
            {
                activityLog.RemoveAt(Ten());
            }
        }

        private string GetActivityLogSummary()
        {
            if (activityLog.Count == Zero())
            {
                return "No actions have been recorded yet. Start by adding tasks or setting reminders!";
            }

            StringBuilder logBuilder = new StringBuilder();
            logBuilder.AppendLine("Here is a summary of recent actions:");
            logBuilder.AppendLine();

            int displayCount = activityLog.Count;
            if (displayCount > Ten())
            {
                displayCount = Ten();
            }

            for (int i = Zero(); i < displayCount; i = Increment(i))
            {
                int logNumber = i + One();
                ActivityLogEntry entry = activityLog[i];
                logBuilder.AppendLine(logNumber.ToString() + ". " + entry.ActionType + " - " + entry.Description);
                logBuilder.AppendLine("   " + entry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                logBuilder.AppendLine();
            }

            if (activityLog.Count > Ten())
            {
                logBuilder.AppendLine("Showing the " + Ten().ToString() + " most recent actions. Total actions: " + activityLog.Count.ToString());
            }

            return logBuilder.ToString();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "audio",
                    "greeting.wav");

                if (File.Exists(audioPath))
                {
                    mediaPlayer.Open(new Uri(audioPath, UriKind.Absolute));
                    mediaPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                AddSystemMessage("Voice greeting error: " + ex.Message);
            }
        }

        private void ShowMainMenu()
        {
            StringBuilder menuBuilder = new StringBuilder();
            menuBuilder.AppendLine("Here are the topics I can help you with:");
            menuBuilder.AppendLine();
            menuBuilder.AppendLine("1. PASSWORD SAFETY - Create and manage strong passwords");
            menuBuilder.AppendLine("2. PHISHING AWARENESS - Recognize and avoid scams");
            menuBuilder.AppendLine("3. SAFE BROWSING - Navigate the web securely");
            menuBuilder.AppendLine("4. PRIVACY PROTECTION - Keep your personal info safe");
            menuBuilder.AppendLine("5. MALWARE PREVENTION - Protect against viruses");
            menuBuilder.AppendLine("6. GENERAL TIPS - Overall cybersecurity advice");
            menuBuilder.AppendLine();
            menuBuilder.AppendLine("I can also help you with TASKS and REMINDERS!");
            menuBuilder.AppendLine("Try saying:");
            menuBuilder.AppendLine("  - 'Add a task to enable two-factor authentication'");
            menuBuilder.AppendLine("  - 'Remind me to update my password tomorrow'");
            menuBuilder.AppendLine("  - 'Show my tasks'");
            menuBuilder.AppendLine("  - 'Show activity log' or 'What have you done for me?'");

            AddBotMessage(menuBuilder.ToString());
        }

        private void AskForName()
        {
            AddBotMessage("Before we continue, may I know your name?");
        }

        // TASK 3: NLP Simulation - Process Natural Language
        private string ProcessNaturalLanguage(string userInput)
        {
            string lowerInput = userInput.ToLower();

            // Check for task addition
            if (ContainsAny(lowerInput, new[] { "add a task", "add task", "create task", "new task", "add to do" }))
            {
                return AddTaskFromNLP(userInput);
            }

            // Check for reminder requests
            if (ContainsAny(lowerInput, new[] { "remind me", "set reminder", "create reminder", "add reminder" }))
            {
                return AddReminderFromNLP(userInput);
            }

            // Check for show tasks
            if (ContainsAny(lowerInput, new[] { "show tasks", "my tasks", "list tasks", "what tasks" }))
            {
                return ShowAllTasks();
            }

            // Check for show reminders
            if (ContainsAny(lowerInput, new[] { "show reminders", "my reminders", "list reminders" }))
            {
                return ShowAllReminders();
            }

            // Check for activity log
            if (ContainsAny(lowerInput, new[] { "activity log", "what have you done", "show log", "recent actions" }))
            {
                return GetActivityLogSummary();
            }

            // Check for task completion
            if (ContainsAny(lowerInput, new[] { "complete task", "finish task", "mark task done" }))
            {
                return CompleteTaskFromNLP(userInput);
            }

            // Check for delete task
            if (ContainsAny(lowerInput, new[] { "delete task", "remove task" }))
            {
                return DeleteTaskFromNLP(userInput);
            }

            return null;
        }

        private string AddTaskFromNLP(string userInput)
        {
            string taskDescription = ExtractTaskDescription(userInput);

            if (string.IsNullOrWhiteSpace(taskDescription))
            {
                return "What task would you like me to add? Please describe the task.";
            }

            TaskItem newTask = new TaskItem
            {
                Id = taskIdCounter,
                Description = taskDescription,
                CreatedDate = DateTime.Now,
                IsCompleted = false
            };

            taskList.Add(newTask);
            taskIdCounter = Increment(taskIdCounter);

            AddToActivityLog("Task Added", "Task added: '" + taskDescription + "'");

            return "Task added: '" + taskDescription + "'. You can ask 'Show my tasks' to see all tasks.";
        }

        private string ExtractTaskDescription(string userInput)
        {
            string lowerInput = userInput.ToLower();
            string[] taskPhrases = { "add a task to", "add task to", "create task to",
                                     "add a task", "add task", "create task", "new task" };

            foreach (string phrase in taskPhrases)
            {
                if (lowerInput.Contains(phrase))
                {
                    int phraseIndex = lowerInput.IndexOf(phrase);
                    string afterPhrase = userInput.Substring(phraseIndex + phrase.Length);
                    return afterPhrase.Trim().TrimStart(' ', 't', 'o', 'f', 'o', 'r');
                }
            }

            return "cybersecurity task";
        }

        private string AddReminderFromNLP(string userInput)
        {
            string reminderText = ExtractReminderText(userInput);
            string reminderDate = ExtractReminderDate(userInput);

            if (string.IsNullOrWhiteSpace(reminderText))
            {
                return "What would you like me to remind you about?";
            }

            ReminderItem newReminder = new ReminderItem
            {
                Id = reminderIdCounter,
                Description = reminderText,
                ReminderDate = reminderDate,
                CreatedDate = DateTime.Now,
                IsCompleted = false
            };

            reminderList.Add(newReminder);
            reminderIdCounter = Increment(reminderIdCounter);

            AddToActivityLog("Reminder Set", "Reminder set: '" + reminderText + "' for " + reminderDate);

            return "Reminder set for '" + reminderText + "' on " + reminderDate +
                   ". You can ask 'Show my reminders' to see all reminders.";
        }

        private string ExtractReminderText(string userInput)
        {
            string lowerInput = userInput.ToLower();
            string[] reminderPhrases = { "remind me to", "set reminder to", "remind me about",
                                          "set a reminder to", "create reminder to" };

            foreach (string phrase in reminderPhrases)
            {
                if (lowerInput.Contains(phrase))
                {
                    int phraseIndex = lowerInput.IndexOf(phrase);
                    string afterPhrase = userInput.Substring(phraseIndex + phrase.Length);

                    string[] dateWords = { "tomorrow", "today", "next week", "monday", "tuesday", "wednesday",
                                           "thursday", "friday", "saturday", "sunday" };
                    string reminderText = afterPhrase;
                    foreach (string dateWord in dateWords)
                    {
                        if (reminderText.ToLower().Contains(dateWord))
                        {
                            int dateIndex = reminderText.ToLower().IndexOf(dateWord);
                            reminderText = reminderText.Substring(Zero(), dateIndex).Trim();
                            break;
                        }
                    }
                    return reminderText.Trim();
                }
            }
            return userInput;
        }

        private string ExtractReminderDate(string userInput)
        {
            string lowerInput = userInput.ToLower();

            if (lowerInput.Contains("tomorrow"))
            {
                return DateTime.Now.AddDays(One()).ToString("yyyy-MM-dd");
            }
            if (lowerInput.Contains("next week"))
            {
                return DateTime.Now.AddDays(Seven()).ToString("yyyy-MM-dd");
            }

            return "today";
        }

        private string ShowAllTasks()
        {
            if (taskList.Count == Zero())
            {
                return "You have no tasks yet. Try saying: 'Add a task to enable two-factor authentication'";
            }

            StringBuilder taskBuilder = new StringBuilder();
            taskBuilder.AppendLine("Here are your tasks:");
            taskBuilder.AppendLine();

            for (int i = Zero(); i < taskList.Count; i = Increment(i))
            {
                TaskItem task = taskList[i];
                int taskNumber = i + One();
                string status = task.IsCompleted ? "COMPLETED" : "PENDING";
                taskBuilder.AppendLine(taskNumber.ToString() + ". " + task.Description + " - " + status);
                taskBuilder.AppendLine("   Added: " + task.CreatedDate.ToString("yyyy-MM-dd HH:mm"));
                taskBuilder.AppendLine();
            }

            return taskBuilder.ToString();
        }

        private string ShowAllReminders()
        {
            if (reminderList.Count == Zero())
            {
                return "You have no reminders set. Try saying: 'Remind me to update my password tomorrow'";
            }

            StringBuilder reminderBuilder = new StringBuilder();
            reminderBuilder.AppendLine("Here are your reminders:");
            reminderBuilder.AppendLine();

            for (int i = Zero(); i < reminderList.Count; i = Increment(i))
            {
                ReminderItem reminder = reminderList[i];
                int reminderNumber = i + One();
                string status = reminder.IsCompleted ? "COMPLETED" : "ACTIVE";
                reminderBuilder.AppendLine(reminderNumber.ToString() + ". " + reminder.Description + " - " + status);
                reminderBuilder.AppendLine("   Reminder for: " + reminder.ReminderDate);
                reminderBuilder.AppendLine();
            }

            return reminderBuilder.ToString();
        }

        private string CompleteTaskFromNLP(string userInput)
        {
            string lowerInput = userInput.ToLower();
            int taskNumber = -One();

            for (int i = One(); i <= taskList.Count; i = Increment(i))
            {
                if (lowerInput.Contains(i.ToString()))
                {
                    taskNumber = i;
                    break;
                }
            }

            if (taskNumber > Zero() && taskNumber <= taskList.Count)
            {
                TaskItem task = taskList[taskNumber - One()];
                task.IsCompleted = true;
                AddToActivityLog("Task Completed", "Task completed: '" + task.Description + "'");
                return "Task '" + task.Description + "' has been marked as completed! Good job!";
            }

            return "Please specify which task to complete. Say 'Show my tasks' to see task numbers.";
        }

        private string DeleteTaskFromNLP(string userInput)
        {
            string lowerInput = userInput.ToLower();
            int taskNumber = -One();

            for (int i = One(); i <= taskList.Count; i = Increment(i))
            {
                if (lowerInput.Contains(i.ToString()))
                {
                    taskNumber = i;
                    break;
                }
            }

            if (taskNumber > Zero() && taskNumber <= taskList.Count)
            {
                TaskItem task = taskList[taskNumber - One()];
                taskList.RemoveAt(taskNumber - One());
                AddToActivityLog("Task Deleted", "Task deleted: '" + task.Description + "'");
                return "Task '" + task.Description + "' has been deleted.";
            }

            return "Please specify which task to delete. Say 'Show my tasks' to see task numbers.";
        }

        private void ShowActivityLog()
        {
            string logSummary = GetActivityLogSummary();
            AddBotMessage(logSummary);
            AddToActivityLog("Activity Log Viewed", "User requested to view activity log");
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            await ProcessUserInput();
        }

        private async void InputTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                await ProcessUserInput();
            }
        }

        private async Task ProcessUserInput()
        {
            string userInput = InputTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
                return;

            AddUserMessage(userInput);
            InputTextBox.Clear();

            // Check if this is name response
            if (string.IsNullOrEmpty(userName))
            {
                userName = CapitalizeFirstLetter(userInput);
                userMemory["name"] = userName;
                AddBotMessage("Nice to meet you, " + userName + "!");
                AddToActivityLog("User Registered", "User name recorded: " + userName);
                ShowMainMenu();
                ScrollToBottom();
                return;
            }

            string lowerInput = userInput.ToLower();

            // TASK 3: Try NLP processing first
            string nlpResponse = ProcessNaturalLanguage(userInput);
            if (nlpResponse != null)
            {
                await TypewriterEffect(nlpResponse);
                ScrollToBottom();
                return;
            }

            // Check for menu number selection (1-6)
            string topicFromNumber = GetTopicFromNumber(lowerInput);
            if (topicFromNumber != null)
            {
                ProcessTopicSelection(topicFromNumber);
                ScrollToBottom();
                return;
            }

            string sentiment = DetectSentiment(userInput);
            StoreUserInfo(userInput);
            string response = await chatbot.GetResponseAsync(userInput, sentiment, userMemory, userName);

            await TypewriterEffect(response);

            interactionCount = Increment(interactionCount);
            if (interactionCount % Three() == Zero())
            {
                await Task.Delay(OneHundred());
                ShowRandomSecurityTip();
            }

            ScrollToBottom();
        }

        private string GetTopicFromNumber(string input)
        {
            if (input == "1") return "password";
            if (input == "2") return "phishing";
            if (input == "3") return "safebrowsing";
            if (input == "4") return "privacy";
            if (input == "5") return "malware";
            if (input == "6") return "general";
            return null;
        }

        private void ProcessTopicSelection(string topic)
        {
            currentTopic = topic;
            string response = chatbot.GetTopicResponse(topic, userName);
            AddBotMessage(response);
            AddToActivityLog("Topic Selected", "User viewed information about: " + topic);
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            return char.ToUpper(input[Zero()]) + input.Substring(One()).ToLower();
        }

        private string DetectSentiment(string input)
        {
            string lowerInput = input.ToLower();

            if (ContainsAny(lowerInput, new[] { "worried", "scared", "nervous", "concerned", "afraid" }))
                return "worried";

            if (ContainsAny(lowerInput, new[] { "frustrated", "annoyed", "confused" }))
                return "frustrated";

            if (ContainsAny(lowerInput, new[] { "curious", "interested", "tell me" }))
                return "curious";

            if (ContainsAny(lowerInput, new[] { "thank", "great", "helpful" }))
                return "positive";

            return "neutral";
        }

        private bool ContainsAny(string input, string[] terms)
        {
            foreach (string term in terms)
            {
                if (input.Contains(term))
                    return true;
            }
            return false;
        }

        private void StoreUserInfo(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("interested in"))
            {
                string[] parts = lowerInput.Split(new[] { "interested in" }, StringSplitOptions.None);
                if (parts.Length > One())
                {
                    string topic = parts[One()].Trim();
                    userMemory["interest"] = topic;
                    AddToActivityLog("Interest Stored", "User interested in: " + topic);
                }
            }
        }

        private async Task TypewriterEffect(string message)
        {
            TextBlock textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                Foreground = Brushes.White,
                FontSize = 13
            };

            Border border = new Border
            {
                Style = (Style)FindResource("MessageBubbleBot"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));

            for (int i = Zero(); i <= message.Length; i = Increment(i))
            {
                await Task.Delay(Fifteen());
                textBlock.Text = message.Substring(Zero(), i);
                ScrollToBottom();
            }
        }

        private void AddUserMessage(string message)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 13
            };

            Border border = new Border
            {
                Style = (Style)FindResource("MessageBubbleUser"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 13
            };

            Border border = new Border
            {
                Style = (Style)FindResource("MessageBubbleBot"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));
            ScrollToBottom();
        }

        private void AddSystemMessage(string message)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = "[" + message + "]",
                Foreground = Brushes.Yellow,
                FontSize = 11,
                FontStyle = FontStyles.Italic,
                TextAlignment = TextAlignment.Center
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(textBlock));
            ScrollToBottom();
        }

        private void ShowRandomSecurityTip()
        {
            string[] tips = {
                "Remember: Banks will NEVER ask for your password via email!",
                "Use a unique password for each of your accounts.",
                "Enable two-factor authentication (2FA) for extra security.",
                "Always log out of accounts when using public computers.",
                "Keep your software and antivirus updated regularly.",
                "Never click on suspicious links in emails or messages.",
                "Use a password manager to generate and store strong passwords."
            };

            Random random = new Random();
            int randomIndex = random.Next(tips.Length);
            AddBotMessage("Security Tip: " + tips[randomIndex]);
        }

        private void ScrollToBottom()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MessagesScrollViewer.ScrollToBottom();
            }));
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() => MessagesPanel.Children.Clear());
            AddBotMessage("Conversation cleared!");
            ShowMainMenu();
            AddToActivityLog("Conversation Cleared", "User cleared the conversation history");
        }

        // Button Click Handlers
        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string topic = button.Tag.ToString();
                ProcessTopicSelection(topic);
            }
        }

        private void ShowTasksButton_Click(object sender, RoutedEventArgs e)
        {
            string tasks = ShowAllTasks();
            AddBotMessage(tasks);
            AddToActivityLog("Tasks Viewed", "User requested to view tasks");
        }

        private void ShowRemindersButton_Click(object sender, RoutedEventArgs e)
        {
            string reminders = ShowAllReminders();
            AddBotMessage(reminders);
            AddToActivityLog("Reminders Viewed", "User requested to view reminders");
        }

        private void ShowLogButton_Click(object sender, RoutedEventArgs e)
        {
            ShowActivityLog();
        }
    }

    // Task Item Class (Task 3)
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    // Reminder Item Class (Task 3)
    public class ReminderItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ReminderDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    // Activity Log Entry Class (Task 4)
    public class ActivityLogEntry
    {
        public DateTime Timestamp { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
    }
}