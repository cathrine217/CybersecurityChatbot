using CybersecurityChatbot;  // YOUR OLD NAMESPACE
using CybersecurityChatbotGUI.Models;
using CybersecurityChatbotGUI.Services;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Form
    {
        // YOUR OLD CHATBOT (Reused!)
        private Chatbot originalChatbot;

        // NEW services
        private SentimentAnalyzer sentimentAnalyzer;
        private UserProfile userProfile;

        // UI Controls
        private RichTextBox chatDisplay;
        private TextBox messageInput;
        private Button sendButton;
        private Button clearButton;
        private Label userLabel;
        private Label sentimentLabel;
        private Panel sidebarPanel;
        private Button setNameButton;
        private Button voiceButton;
        private FlowLayoutPanel topicPanel;

        public MainWindow()
        {
            InitializeComponent();
            InitializeServices();
            SetupUI();
            LoadUserPreferences();
            PlayVoiceGreeting();
            ShowWelcomeMessage();
        }

        private void InitializeComponent()
        {
            this.Text = "Cybersecurity Awareness Chatbot";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 25, 35);
            this.MinimumSize = new Size(800, 500);
        }

        private void InitializeServices()
        {
            // Initialize YOUR original chatbot
            originalChatbot = new Chatbot();

            // Initialize new services
            sentimentAnalyzer = new SentimentAnalyzer();
            userProfile = UserProfile.LoadProfile();

            // If user profile has a name, set it in your original chatbot
            if (!string.IsNullOrEmpty(userProfile.Name))
            {
                originalChatbot.SetUserName(userProfile.Name);
            }
        }

        private void SetupUI()
        {
            // Sidebar Panel
            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                BackColor = Color.FromArgb(25, 35, 45),
                Padding = new Padding(10)
            };

            // User Label
            userLabel = new Label
            {
                Text = string.IsNullOrEmpty(userProfile.Name) ? "Guest User" : $"Welcome, {userProfile.Name}",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Set Name Button
            setNameButton = new Button
            {
                Text = "Set Your Name",
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 35,
                Dock = DockStyle.Top,
                Margin = new Padding(0, 5, 0, 10)
            };
            setNameButton.Click += SetNameButton_Click;

            // Sentiment Label
            Label sentimentTitle = new Label
            {
                Text = "Current Mood",
                ForeColor = Color.FromArgb(0, 180, 255),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            sentimentLabel = new Label
            {
                Text = "Neutral",
                ForeColor = Color.FromArgb(150, 200, 255),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Topics Label
            Label topicsTitle = new Label
            {
                Text = "Quick Topics",
                ForeColor = Color.FromArgb(0, 180, 255),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 10, 0, 0)
            };

            // Topic Buttons Panel
            topicPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(5)
            };

            string[] topics = { "Password Safety", "Phishing Awareness", "Safe Browsing", "General Tips" };
            foreach (string topic in topics)
            {
                Button btn = new Button
                {
                    Text = topic,
                    BackColor = Color.FromArgb(40, 50, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 40,
                    Width = 210,
                    Margin = new Padding(5, 5, 5, 5),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = topic
                };
                btn.Click += (s, e) => SendTopic(topic);
                topicPanel.Controls.Add(btn);
            }

            // Voice Button
            voiceButton = new Button
            {
                Text = "Play Voice Greeting",
                BackColor = Color.FromArgb(60, 70, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 35,
                Dock = DockStyle.Bottom,
                Margin = new Padding(0, 10, 0, 0)
            };
            voiceButton.Click += VoiceButton_Click;

            // Assemble sidebar
            sidebarPanel.Controls.Add(voiceButton);
            sidebarPanel.Controls.Add(topicPanel);
            sidebarPanel.Controls.Add(topicsTitle);
            sidebarPanel.Controls.Add(sentimentLabel);
            sidebarPanel.Controls.Add(sentimentTitle);
            sidebarPanel.Controls.Add(setNameButton);
            sidebarPanel.Controls.Add(userLabel);

            // Chat Display
            chatDisplay = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 40, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                ReadOnly = true,
                BorderStyle = BorderStyle.None
            };

            // Input Panel
            Panel inputPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(25, 35, 45),
                Padding = new Padding(10)
            };

            messageInput = new TextBox
            {
                Location = new Point(10, 8),
                Size = new Size(this.Width - 190, 34),
                BackColor = Color.FromArgb(40, 50, 60),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10)
            };
            messageInput.KeyPress += MessageInput_KeyPress;

            sendButton = new Button
            {
                Text = "Send",
                Location = new Point(this.Width - 170, 8),
                Size = new Size(75, 34),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            sendButton.Click += SendButton_Click;

            clearButton = new Button
            {
                Text = "Clear",
                Location = new Point(this.Width - 90, 8),
                Size = new Size(75, 34),
                BackColor = Color.FromArgb(80, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            clearButton.Click += (s, e) => chatDisplay.Clear();

            inputPanel.Controls.Add(messageInput);
            inputPanel.Controls.Add(sendButton);
            inputPanel.Controls.Add(clearButton);

            // Add to form
            this.Controls.Add(chatDisplay);
            this.Controls.Add(inputPanel);
            this.Controls.Add(sidebarPanel);
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            await ProcessUserInput();
        }

        private async void MessageInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                await ProcessUserInput();
            }
        }

        private async Task ProcessUserInput()
        {
            string userInput = messageInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                AppendMessage("System", "Please enter a message.", "error");
                return;
            }

            AppendMessage("You", userInput, "user");
            messageInput.Clear();

            SetInputEnabled(false);

            await Task.Delay(300);

            // Analyze sentiment (NEW feature)
            var sentiment = sentimentAnalyzer.Analyze(userInput);
            UpdateSentimentDisplay(sentiment);

            // Get response from YOUR original chatbot
            string response = GetResponseFromOriginalChatbot(userInput, sentiment);

            // Save to profile (NEW feature)
            userProfile.UpdateInterest(DetectTopicFromInput(userInput));
            userProfile.SaveProfile();

            AppendMessage("Assistant", response, "bot");

            SetInputEnabled(true);
            messageInput.Focus();
        }

        private string GetResponseFromOriginalChatbot(string userInput, Sentiment sentiment)
        {
            string inputLower = userInput.ToLower();

            // Call YOUR original chatbot's response methods
            if (inputLower.Contains("password") || inputLower.Contains("passcode"))
            {
                string sentimentPrefix = sentiment.SuggestedResponse + "\n\n";
                return sentimentPrefix + originalChatbot.GetPasswordSafetyResponse();
            }
            else if (inputLower.Contains("phish") || inputLower.Contains("scam"))
            {
                return originalChatbot.GetPhishingResponse();
            }
            else if (inputLower.Contains("browse") || inputLower.Contains("internet"))
            {
                return originalChatbot.GetSafeBrowsingResponse();
            }
            else if (inputLower.Contains("tip") || inputLower.Contains("general"))
            {
                return originalChatbot.GetGeneralTipsResponse();
            }
            else if (inputLower.Contains("about") || inputLower.Contains("who are you"))
            {
                return originalChatbot.GetAboutResponse();
            }
            else if (sentiment.Type == "worried")
            {
                return "It is understandable to feel that way. " +
                       "Trust your instincts and never share personal information unless you initiated contact.\n\n" +
                       originalChatbot.GetGeneralTipsResponse();
            }
            else if (inputLower.Contains("hello") || inputLower.Contains("hi"))
            {
                string name = string.IsNullOrEmpty(userProfile.Name) ? "" : $" {userProfile.Name}";
                return $"Hello{name}! I am your cybersecurity assistant.\n\n" +
                       originalChatbot.GetGeneralTipsResponse();
            }
            else if (inputLower.Contains("thank"))
            {
                return "You are very welcome! Staying safe online is a team effort.";
            }
            else
            {
                // Default response using your original chatbot's ProcessInput logic
                return "I am not sure I understand. You can ask me about:\n" +
                       "- Password safety\n" +
                       "- Phishing scams\n" +
                       "- Safe browsing\n" +
                       "- General tips\n\n" +
                       "Type 'help' for more options.";
            }
        }

        private string DetectTopicFromInput(string input)
        {
            string inputLower = input.ToLower();
            if (inputLower.Contains("password")) return "password";
            if (inputLower.Contains("phish")) return "phishing";
            if (inputLower.Contains("browse")) return "browsing";
            if (inputLower.Contains("privacy")) return "privacy";
            return null;
        }

        private void SendTopic(string topic)
        {
            string topicCommand = topic.ToLower();
            if (topicCommand.Contains("password"))
                messageInput.Text = "Tell me about password safety";
            else if (topicCommand.Contains("phishing"))
                messageInput.Text = "How to spot phishing scams";
            else if (topicCommand.Contains("browsing"))
                messageInput.Text = "Safe browsing tips";
            else
                messageInput.Text = "Give me general cybersecurity tips";

            _ = ProcessUserInput();
        }

        private void SetNameButton_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Please enter your name:",
                "User Profile",
                userProfile.Name ?? "");

            if (!string.IsNullOrWhiteSpace(name) && name.Length >= 2)
            {
                userProfile.Name = name;
                userProfile.SaveProfile();

                // Also set name in YOUR original chatbot
                originalChatbot.SetUserName(name);

                userLabel.Text = $"Welcome, {name}!";
                AppendMessage("System", $"Nice to meet you, {name}! I will remember your name.", "bot");
            }
        }

        private void VoiceButton_Click(object sender, EventArgs e)
        {
            PlayVoiceGreeting();
            AppendMessage("System", "Playing voice greeting...", "info");
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = Path.Combine(Application.StartupPath, "Resources", "Audio", "greeting.wav");
                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.Play();
                    }
                }
            }
            catch (Exception ex)
            {
                AppendMessage("System", $"Audio unavailable: {ex.Message}", "error");
            }
        }

        private void UpdateSentimentDisplay(Sentiment sentiment)
        {
            string sentimentText = sentiment.Type switch
            {
                "worried" => "Worried",
                "curious" => "Curious",
                "frustrated" => "Frustrated",
                "happy" => "Happy",
                _ => "Neutral"
            };

            sentimentLabel.Text = sentimentText;

            sentimentLabel.ForeColor = sentiment.Type switch
            {
                "worried" => Color.Orange,
                "frustrated" => Color.Red,
                "happy" => Color.LightGreen,
                "curious" => Color.Cyan,
                _ => Color.FromArgb(150, 200, 255)
            };
        }

        private void SetInputEnabled(bool enabled)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetInputEnabled(enabled)));
                return;
            }

            messageInput.Enabled = enabled;
            sendButton.Enabled = enabled;
            clearButton.Enabled = enabled;
            voiceButton.Enabled = enabled;
            setNameButton.Enabled = enabled;
        }

        private void AppendMessage(string sender, string message, string type)
        {
            if (chatDisplay.InvokeRequired)
            {
                chatDisplay.Invoke(new Action(() => AppendMessage(sender, message, type)));
                return;
            }

            DateTime now = DateTime.Now;
            string timeStamp = now.ToString("HH:mm:ss");

            // Clean message (remove emojis if needed for display)
            string cleanMessage = message;

            string formattedMessage = type switch
            {
                "user" => $"\n[{timeStamp}] {sender}: {cleanMessage}\n",
                "bot" => $"\n[{timeStamp}] {sender}: {cleanMessage}\n" + new string('-', 50) + "\n",
                "error" => $"\n[{timeStamp}] ERROR: {cleanMessage}\n",
                "info" => $"\n[{timeStamp}] INFO: {cleanMessage}\n",
                _ => $"\n[{timeStamp}] {sender}: {cleanMessage}\n"
            };

            chatDisplay.AppendText(formattedMessage);
            chatDisplay.ScrollToCaret();
        }

        private void LoadUserPreferences()
        {
            if (!string.IsNullOrEmpty(userProfile.Name))
            {
                userLabel.Text = $"Welcome, {userProfile.Name}!";
                AppendMessage("System", $"Welcome back, {userProfile.Name}!", "info");
            }

            if (!string.IsNullOrEmpty(userProfile.FavoriteTopic))
            {
                AppendMessage("System", $"I remember you are interested in {userProfile.FavoriteTopic}.", "info");
            }
        }

        private void ShowWelcomeMessage()
        {
            string welcomeMessage = "WELCOME TO YOUR CYBERSECURITY ASSISTANT\n\n" +
                                   "I am here to help you stay safe online.\n\n" +
                                   "You can:\n" +
                                   "- Ask about password safety, phishing, and more\n" +
                                   "- Click topic buttons for quick tips\n" +
                                   "- Tell me your name for personalized conversations\n\n" +
                                   "What would you like to learn about today?";

            AppendMessage("Assistant", welcomeMessage, "bot");
        }
    }
}