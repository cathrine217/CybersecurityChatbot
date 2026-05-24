using System;
using System.Collections.Generic;
using System.Media;
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
        private SoundPlayer greetingPlayer;
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();
            InitializeChatbot();
            PlayVoiceGreeting();
            AddBotMessage("Hello! Welcome to the Cybersecurity Awareness Bot.");
            AddBotMessage("I'm here to help you stay safe online.");
            AddSuggestedTopics();
            AskForName();
        }

        private void InitializeChatbot()
        {
            chatbot = new ChatbotEngine();
            userMemory = new Dictionary<string, string>();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "audio", "greeting.wav");

                if (System.IO.File.Exists(audioPath))
                {
                    greetingPlayer = new SoundPlayer(audioPath);
                    greetingPlayer.Play();
                }
            }
            catch (Exception)
            {
                AddSystemMessage("Voice greeting unavailable");
            }
        }

        private void AskForName()
        {
            AddBotMessage("May I know your name?");
        }

        private void AddSuggestedTopics()
        {
            string[] topics = { "Password Safety", "Phishing Awareness",
                               "Safe Browsing", "General Tips" };

            Dispatcher.Invoke(() =>
            {
                var wrapPanel = new WrapPanel { Margin = new Thickness(10) };

                foreach (string topic in topics)
                {
                    var button = new Button
                    {
                        Content = topic,
                        Background = new SolidColorBrush(Color.FromRgb(78, 205, 196)),
                        Foreground = Brushes.White,
                        FontSize = 12,
                        Padding = new Thickness(10, 5, 10, 5),
                        Margin = new Thickness(5),
                        Cursor = System.Windows.Input.Cursors.Hand
                    };
                    button.Click += (s, e) => InputTextBox.Text = topic;
                    wrapPanel.Children.Add(button);
                }

                MessagesPanel.Children.Add(wrapPanel);
                ScrollToBottom();
            });
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
                userName = userInput;
                userMemory["name"] = userName;
                AddBotMessage("Nice to meet you, " + userName +
                    "! How can I help you with cybersecurity today?");
                ScrollToBottom();
                return;
            }

            string sentiment = DetectSentiment(userInput);
            StoreUserInfo(userInput);
            string response = await chatbot.GetResponseAsync(userInput, sentiment, userMemory, userName);

            await TypewriterEffect(response);
            ScrollToBottom();
        }

        private string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") || input.Contains("scared") ||
                input.Contains("nervous") || input.Contains("concerned"))
                return "worried";

            if (input.Contains("frustrated") || input.Contains("annoyed"))
                return "frustrated";

            if (input.Contains("curious") || input.Contains("interested"))
                return "curious";

            if (input.Contains("thank") || input.Contains("great"))
                return "positive";

            return "neutral";
        }

        private void StoreUserInfo(string input)
        {
            if (input.ToLower().Contains("interested in"))
            {
                string[] parts = input.Split(new[] { "interested in" },
                    StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    string topic = parts[1].Trim();
                    userMemory["interest"] = topic;
                }
            }
        }

        private async Task TypewriterEffect(string message)
        {
            var textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                Foreground = Brushes.White,
                FontSize = 13
            };

            var border = new Border
            {
                Style = (Style)FindResource("MessageBubbleBot"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));

            for (int i = 0; i <= message.Length; i++)
            {
                await Task.Delay(15);
                textBlock.Text = message.Substring(0, i);
                ScrollToBottom();
            }
        }

        private void AddUserMessage(string message)
        {
            var textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 13
            };

            var border = new Border
            {
                Style = (Style)FindResource("MessageBubbleUser"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            var textBlock = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 13
            };

            var border = new Border
            {
                Style = (Style)FindResource("MessageBubbleBot"),
                Child = textBlock
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(border));
            ScrollToBottom();
        }

        private void AddSystemMessage(string message)
        {
            var textBlock = new TextBlock
            {
                Text = message,
                Foreground = Brushes.Yellow,
                FontSize = 11,
                FontStyle = FontStyles.Italic,
                TextAlignment = TextAlignment.Center
            };

            Dispatcher.Invoke(() => MessagesPanel.Children.Add(textBlock));
            ScrollToBottom();
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
            AddBotMessage("Conversation cleared! How can I help you?");
        }
    }
}