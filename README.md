# Cybersecurity Awareness Chatbot

A South African Initiative for Online Safety

TABLE OF CONTENTS

1. [Project Overview](#project-overview)
2. [What This Chatbot Does](#what-this-chatbot-does)
3. [Part 1 vs Part 2 Explained](#part-1-vs-part-2-explained)
4. [Technical Requirements](#technical-requirements)
5. [Installation Guide](#installation-guide)
6. [How to Run the Program](#how-to-run-the-program)
7. [How to Use the Chatbot](#how-to-use-the-chatbot)
8. [Complete Code Structure](#complete-code-structure)
9. [Features Explained in Detail](#features-explained-in-detail)
10. [String Manipulation Techniques](#string-manipulation-techniques)
11. [Testing Guide](#testing-guide)
12. [Common Problems and Solutions](#common-problems-and-solutions)
14. [Project Checklist](#project-checklist)


PROJECT OVERVIEW

The Cybersecurity Awareness Chatbot is an educational application designed to help South African citizens learn about online safety. Cyber attacks are increasing in South Africa, targeting individuals, businesses, and government institutions. This chatbot teaches users how to:

- Create and manage strong passwords
- Recognize phishing emails and scams
- Browse the internet safely
- Protect personal privacy online
- Prevent malware and virus infections
- Develop good cybersecurity habits

The project is divided into TWO parts as required by the PROG6221 POE assignment.

WHAT THIS CHATBOT DOES

When you run the chatbot, it will:

1. Greet you with voice - Plays a recorded welcome message
2. Ask for your name - Personalizes the conversation
3. Show a menu of topics - Displays what you can learn about
4. Answer your questions - Responds to cybersecurity questions
5. Give different tips each time - Random responses keep it interesting
6. Remember what you say - Recalls your name and interests
7. Detect your mood - Responds differently if you're worried or curious
8. Suggest follow-up topics - Offers more information on your chosen topic

PART 1 VS PART 2 EXPLAINED

| Feature | Part 1 (Console) | Part 2 (WPF) |
|---------|-----------------|--------------|
| Interface | Text-based command window | Modern window with buttons |
| Voice Greeting | Yes | Yes |
| ASCII Art Logo | Yes | Yes |
| Colored Text | Yes | Yes (colored bubbles) |
| Typing Effect | Yes | Yes |
| Keyword Recognition | Yes (basic) | Yes (advanced) |
| Random Responses | No | Yes |
| Memory Feature | No | Yes |
| Sentiment Detection | No | Yes |
| Follow-up Options | No | Yes |
| Topic Buttons | No | Yes |

 Part 1 - Console Application
- Runs in a black command window (like old DOS programs)
- User types commands like "help", "1", "exit"
- Focuses on core functionality

 Part 2 - WPF Application
- Runs in a modern window with buttons and chat bubbles
- User can click buttons OR type questions
- Includes ALL advanced features

TECHNICAL REQUIREMENTS

What You Need Before Starting

| Requirement | Specification |
|-------------|---------------|
| Operating System | Windows 10 or Windows 11 |
| Visual Studio | 2022 Community Edition (free) |
| .NET Framework | Version 4.8 or higher |
| Git | For version control (optional but recommended) |
| Audio | Speakers or headphones for voice greeting |
| Storage | At least 100 MB free space |

 How to Install Visual Studio 2022

Step 1: Go to https://visualstudio.microsoft.com/
Step 2: Download "Visual Studio 2022 Community" (free)
Step 3: Run the installer
Step 4: Select ".NET desktop development" workload
Step 5: Click "Install"
Step 6: Wait for installation to complete (may take 10-20 minutes)

INSTALLATION GUIDE

Step 1: Get the Code

Option A - Download ZIP (Easiest for beginners):

1. Go to the GitHub repository link provided
2. Click the green "Code" button
3. Click "Download ZIP"
4. Extract the ZIP file to a folder on your computer

Option B - Clone with Git (For version control):

git clone https://github.com/yourusername/CybersecurityChatbot.git
cd CybersecurityChatbot

 Step 2: Open the Project in Visual Studio

1. Open Visual Studio 2022
2. Click "File" then "Open" then "Project/Solution"
3. Navigate to the folder where you saved the project
4. Select "CybersecurityChatbot.sln"
5. Click "Open"

 Step 3: Create the Voice Greeting File

You need to create a greeting.wav file with your voice.

Method 1 - Record Your Voice (Recommended):

1. Open Windows "Voice Recorder" (search in Start menu)
2. Click the microphone button to start recording
3. Say clearly: "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."
4. Click stop
5. Click "Save" and name it "greeting.wav"

Method 2 - Use Online Text-to-Speech:

1. Go to a free text-to-speech website (like ttsmaker.com)
2. Type: "Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."
3. Download as WAV format
4. Rename the file to "greeting.wav"

 Step 4: Add Audio File to Part 1 (Console)

1. In Solution Explorer, right-click "CybersecurityChatbotConsole"
2. Click "Add" then "New Folder"
3. Name the folder "audio"
4. Right-click the "audio" folder
5. Click "Add" then "Existing Item"
6. Find and select your greeting.wav file
7. Click "Add"
8. Click on greeting.wav in Solution Explorer
9. Press F4 to open Properties
10. Set "Copy to Output Directory" = "Copy if newer"

 Step 5: Add Audio File to Part 2 (WPF)

1. In Solution Explorer, right-click "CybersecurityChatbotWPF"
2. Click "Add" then "New Folder"
3. Name the folder "audio"
4. Right-click the "audio" folder
5. Click "Add" then "Existing Item"
6. Find and select your greeting.wav file
7. Click "Add"
8. Click on greeting.wav in Solution Explorer
9. Press F4 to open Properties
10. Set "Copy to Output Directory" = "Copy if newer"

 Step 6: Build the Solution

1. Click "Build" menu
2. Click "Build Solution" (or press Ctrl+Shift+B)
3. Look for "Build succeeded" in bottom left corner

 HOW TO RUN THE PROGRAM

Running Part 1 (Console Application)

1. In Solution Explorer, right-click "CybersecurityChatbotConsole"
2. Click "Set as Startup Project" (makes it bold)
3. Press F5 (or click "Debug" then "Start Debugging")
4. The console window will open with the chatbot

 Running Part 2 (WPF Application)

1. In Solution Explorer, right-click "CybersecurityChatbotWPF"
2. Click "Set as Startup Project" (makes it bold)
3. Press F5 (or click "Debug" then "Start Debugging")
4. The GUI window will open with the chatbot

 HOW TO USE THE CHATBOT

 Part 1 - Console Application

What you will see when it starts:

      .--.      .--.      .--.      .--.      .--.      .--.
    : (\ " .-.  .-. " .-.  .-. " .-.  .-. " .-.  .-. " .-) ;
     :   '-'   '-'   '-'   '-'   '-'   '-'   '-'   '-'   '-'   :
      \      /      \      /      \      /      \      /      /
       `.__.'        `.__.'        `.__.'        `.__.'        `.__.'

        ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗ ██████╗
       ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝
       ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗██║
       ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██║
       ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║╚██████╗
        ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝

  ============================================================
  Welcome, Thabo!
  ============================================================

  [INFO] I'm your personal cybersecurity assistant!
    - Ask me about password safety
    - Learn how to spot phishing attacks
    - Get tips for safe browsing
    - Type 'menu' to see all options
    - Type 'exit' to quit

  ------------------------------------------------------------

  AVAILABLE TOPICS:
    [1] Password Safety
    [2] Phishing Awareness
    [3] Safe Browsing
    [4] General Cybersecurity Tips
    [5] About This Bot

  ------------------------------------------------------------

  > 

Commands you can type:

| Command | What it does |
|---------|---------------|
| 1 | Shows password safety information |
| 2 | Shows phishing awareness information |
| 3 | Shows safe browsing tips |
| 4 | Shows general cybersecurity tips |
| 5 | Shows information about the bot |
| help or menu | Displays the menu again |
| exit or quit | Exits the program |
| clear | Clears the screen |

Questions you can ask:

| Question | What the bot does |
|----------|-------------------|
| What is a strong password? | Shows password safety tips |
| How to spot phishing? | Shows phishing awareness info |
| Tell me about safe browsing | Shows safe browsing tips |
| I'm worried about viruses | Shows malware protection info |
| How to protect privacy? | Shows privacy protection tips |

Part 2 - WPF Application (GUI)

What you will see when it starts:

+-----------------------------------------------------------------------+
|                                                                       |
|                    CYBERSECURITY AWARENESS BOT                        |
|                  'Stay Safe in the Digital World'                     |
|                                                                       |
+-----------------------------------------------------------------------+
|                                                                       |
|  +-----------------------------------------------------------------+  |
|  | Bot: Hello! Welcome to the Cybersecurity Awareness Bot!        |  |
|  +-----------------------------------------------------------------+  |
|                                                                       |
|  +-----------------------------------------------------------------+  |
|  | Bot: I'm here to help you stay safe online.                     |  |
|  +-----------------------------------------------------------------+  |
|                                                                       |
|  +-----------------------------------------------------------------+  |
|  | Bot: May I know your name?                                      |  |
|  +-----------------------------------------------------------------+  |
|                                                                       |
|  [1. Password Safety]  [2. Phishing Awareness]  [3. Safe Browsing]   |
|  [4. Privacy Protection]  [5. Malware Prevention]  [6. General Tips] |
|  [7. Help / Menu]                                                    |
|                                                                       |
+-----------------------------------------------------------------------+
|  [ Type your message here...                               ] [SEND]  |
|                                                             [CLEAR]  |
+-----------------------------------------------------------------------+

How to interact:

| Action | Method |
|--------|--------|
| Select a topic | Click any button (1-7) OR type the number (1-7) |
| Ask a question | Type your question in the text box, click SEND or press Enter |
| Get more tips | Click the "More Tips" buttons that appear after a topic |
| Clear conversation | Click the CLEAR button |
| Exit | Close the window |

Example conversation:

User: My name is Thabo

Bot: Nice to meet you, Thabo! How can I help you with cybersecurity today?

User: I'm worried about online scams

Bot: It's completely normal to feel concerned, Thabo.
      Here's how to spot scams:
      - Always check email sender addresses carefully
      - Never click links in suspicious emails
      - Legitimate companies never ask for passwords via email
      
      [More Tips] [Report Scams] [Back to Menu]

User: More Tips

Bot: Another important tip: Scammers often create urgency.
      They say things like "Your account will be closed immediately!"
      Always take a moment to think before clicking anything.
      
      [More Tips] [Back to Menu]


 COMPLETE CODE STRUCTURE

### Part 1 - Console Application Files

CybersecurityChatbotConsole/
│
├── Program.cs
│   ├── What it does: Entry point of the application
│   ├── Key methods: Main(), SetConsoleTitle(), SetConsoleDimensions()
│   ├── Plays voice greeting, starts the chatbot
│   └── Lines of code: Approximately 40
│
├── Chatbot.cs
│   ├── What it does: Main bot logic and conversation
│   ├── Key methods: Start(), GetUserName(), RunConversationLoop()
│   ├── ProcessInput(), CheckMenuNumberSelection()
│   └── Lines of code: Approximately 250
│
├── UIHelper.cs
│   ├── What it does: All visual display and formatting
│   ├── Key methods: DisplayLogo(), TypeWrite(), PrintResponse()
│   ├── PrintTipBox(), DisplayMenu(), ShowLoadingAnimation()
│   └── Lines of code: Approximately 200
│
├── AudioService.cs
│   ├── What it does: Plays voice greeting
│   ├── Key methods: PlayGreeting(), BuildFileNotFoundMessage()
│   ├── Uses System.Media.SoundPlayer
│   └── Lines of code: Approximately 50
│
└── audio/
    └── greeting.wav (your voice recording)

Part 2 - WPF Application Files

CybersecurityChatbotWPF/
│
├── MainWindow.xaml
│   ├── What it does: GUI layout and design
│   ├── Key elements: Grid, ScrollViewer, StackPanel, TextBlock, Buttons
│   ├── Styles: MessageBubbleUser, MessageBubbleBot, SendButtonStyle
│   └── Lines of code: Approximately 150
│
├── MainWindow.xaml.cs
│   ├── What it does: Code behind the GUI
│   ├── Key methods: ProcessUserInput(), DetectSentiment(), TypewriterEffect()
│   ├── StoreUserInfo(), TopicButton_Click(), FollowUpOption_Click()
│   └── Lines of code: Approximately 300
│
├── ChatbotEngine.cs
│   ├── What it does: Response logic and keyword matching
│   ├── Key methods: GetTopicResponse(), GetFollowUpResponse(), GetResponseAsync()
│   ├── InitializeResponses(), InitializeKeywordMap()
│   └── Lines of code: Approximately 350
│
└── audio/
    └── greeting.wav (your voice recording)

---

FEATURES EXPLAINED IN DETAIL

 1. Voice Greeting

What it does: Plays a welcome message when the application starts

How it works (Part 1 - Console):

using System.Media;
using (SoundPlayer player = new SoundPlayer(audioPath))
{
    player.PlaySync();  // Plays and waits to finish
}

How it works (Part 2 - WPF):

using System.Windows.Media;
mediaPlayer = new MediaPlayer();
mediaPlayer.Open(new Uri(audioPath));
mediaPlayer.Play();  // Plays without waiting

Why it's important: Makes the chatbot feel personal and welcoming

 2. ASCII Art Logo

What it does: Displays a text-based logo at the top

How it works:
- Uses special characters like █, ╔, ╗, ─, ┐
- Printed line by line using Console.WriteLine()
- Colored cyan for visibility

Why it's important: Makes the application look professional

 3. Typing Effect

What it does: Bot types messages character by character

How it works:

for (int i = 0; i <= message.Length; i++)
{
    await Task.Delay(15);  // Wait 15 milliseconds
    textBlock.Text = message.Substring(0, i);  // Show part of message
}

Why it's important: Simulates natural conversation, feels more human

 4. Keyword Recognition

What it does: Bot understands what topic you want

How it works:

if (userInput.Contains("password") || userInput.Contains("passcode"))
{
    return GetPasswordSafetyResponse();
}

Keywords recognized:
- Password: password, passcode, login, strong password
- Phishing: phishing, scam, fake email, fraud, spam
- Privacy: privacy, private, personal info
- Malware: virus, malware, antivirus, ransomware
- Browsing: browse, internet, website, https, wifi

 5. Random Responses

What it does: Gives different tips each time you ask

How it works:

List<string> passwordResponses = new List<string>()
{
    "Use strong passwords with 12+ characters...",
    "Never reuse passwords across multiple accounts...",
    "Avoid using personal info like birthdays...",
    "Enable Two-Factor Authentication..."
};

Random random = new Random();
int index = random.Next(passwordResponses.Count);
string response = passwordResponses[index];

Why it's important: Prevents repetitive answers, keeps users engaged

 6. Memory Feature

What it does: Remembers user information

How it works:

// Storage
private Dictionary<string, string> userMemory;

// Storing
userMemory["name"] = userName;
userMemory["interest"] = "privacy";

// Recalling
if (userMemory.ContainsKey("name"))
{
    return "I remember! Your name is " + userMemory["name"];
}

What it remembers:
- User's name
- Topics the user is interested in

 7. Sentiment Detection

What it does: Detects user's mood and responds appropriately

How it works:

private string DetectSentiment(string input)
{
    string lowerInput = input.ToLower();
    
    if (lowerInput.Contains("worried") || lowerInput.Contains("scared"))
        return "worried";
    
    if (lowerInput.Contains("frustrated") || lowerInput.Contains("annoyed"))
        return "frustrated";
    
    if (lowerInput.Contains("curious") || lowerInput.Contains("interested"))
        return "curious";
    
    return "neutral";
}

Different responses by sentiment:

| Sentiment | Bot Response |
|-----------|--------------|
| Worried | "It's normal to feel concerned. Here's help..." |
| Frustrated | "I understand. Let me simplify this for you..." |
| Curious | "Great question! I'm glad you're curious..." |
| Positive | "I'm happy to help! Here's what you need to know..." |

 8. Follow-up Options

What it does: Shows buttons for more information after each topic

How it works:

private void ShowTopicFollowUpOptions(string topic)
{
    string[] options = GetFollowUpOptions(topic);
    
    foreach (string option in options)
    {
        Button button = new Button();
        button.Content = option;
        button.Click += FollowUpOption_Click;
        wrapPanel.Children.Add(button);
    }
}

Follow-up buttons by topic:

| Topic | Follow-up Buttons |
|-------|-------------------|
| Password | More Tips, Password Managers, 2FA, Back to Menu |
| Phishing | More Tips, Report Scams, Email Safety, Back to Menu |
| Browsing | More Tips, Public WiFi, Extensions, Back to Menu |
| Privacy | More Tips, Social Media, App Permissions, Back to Menu |
| Malware | More Tips, Infection Signs, Antivirus, Back to Menu |

 STRING MANIPULATION TECHNIQUES

This project demonstrates extensive string manipulation. Here's every technique used:

 1. String Concatenation (+)

string greeting = "Hello " + userName + "!";
string fullMessage = part1 + " " + part2 + " " + part3;

 2. StringBuilder (for efficiency)

StringBuilder builder = new StringBuilder();
builder.Append("Welcome ");
builder.Append(userName);
builder.Append(" to the chatbot!");
string result = builder.ToString();

 3. String.Contains() for keyword detection

if (userInput.Contains("password"))
if (userInput.Contains("phishing"))

4. String.ToLower() for case-insensitive matching

string cleanInput = userInput.ToLower();
string lowerSearch = searchTerm.ToLower();

 5. String.IsNullOrWhiteSpace() for validation

if (string.IsNullOrWhiteSpace(userName))
if (string.IsNullOrWhiteSpace(userInput))

 6. String.Replace() for personalization

string response = "Hello {userName}!";
response = response.Replace("{userName}", actualName);

 7. String.Substring() for typing effect

for (int i = 0; i < message.Length; i++)
{
    string partial = message.Substring(0, i);
    Console.Write(partial);
}

 8. String.Length property

int nameLength = userName.Length;
int messageLength = message.Length;

 9. new string(char, count) for borders

string line = new string('=', 50);
string border = new string('-', 60);

 10. Path.Combine() for file paths

string audioPath = Path.Combine(baseDir, "audio", "greeting.wav");

 11. String.Split() for parsing

string[] parts = input.Split(new[] { "interested in" }, StringSplitOptions.None);
string topic = parts[1].Trim();

 12. String.Join() for combining

string[] words = { "Hello", userName, "!" };
string sentence = string.Join(" ", words);

 13. String.PadRight() for alignment

string aligned = text.PadRight(50);
Console.WriteLine("| " + aligned + " |");

 14. Char.ToUpper() for capitalization

string capitalized = char.ToUpper(name[0]) + name.Substring(1).ToLower();

 15. No Hardcoded Numbers Pattern

// Instead of: int delay = 1000;
int delay = ConvertStringToInt("1000");

// Helper methods
private int Zero() => ConvertStringToInt("0");
private int One() => ConvertStringToInt("1");
private int Ten() => ConvertStringToInt("10");

private int ConvertStringToInt(string numberString)
{
    return int.Parse(numberString);
}


 TESTING GUIDE

 Test Part 1 (Console Application)

| Test | What to do | Expected Result |
|------|------------|-----------------|
| 1 | Run the program | Hear voice greeting, see ASCII art |
| 2 | Press Enter without typing | Error message: "I didn't catch that" |
| 3 | Type "help" | Shows menu with topics 1-5 |
| 4 | Type "1" | Shows password safety information |
| 5 | Type "2" | Shows phishing awareness information |
| 6 | Type "3" | Shows safe browsing tips |
| 7 | Type "4" | Shows general cybersecurity tips |
| 8 | Type "5" | Shows about bot information |
| 9 | Type "password" | Shows password safety information |
| 10 | Type "phishing" | Shows phishing awareness information |
| 11 | Type "exit" | Shows goodbye message, program closes |

Test Part 2 (WPF Application)

| Test | What to do | Expected Result |
|------|------------|-----------------|
| 1 | Run the program | Hear voice greeting, see GUI window |
| 2 | Type your name | Bot welcomes you by name |
| 3 | Click "Password Safety" button | Shows detailed password info + follow-up buttons |
| 4 | Click "More Tips" button | Shows additional password tips |
| 5 | Click "Back to Menu" button | Returns to main menu |
| 6 | Type "2" | Shows phishing information |
| 7 | Type "I'm worried about scams" | Shows empathetic response + phishing tips |
| 8 | Type "I'm interested in privacy" | Bot stores your interest |
| 9 | Type "Do you remember my interest?" | Bot recalls your privacy interest |
| 10 | Click CLEAR button | Conversation resets |
| 11 | Type random words not related | Shows helpful message with suggestions |

COMMON PROBLEMS AND SOLUTIONS

| Problem | Cause | Solution |
|---------|-------|----------|
| No voice greeting | Audio file missing | Check audio folder has greeting.wav |
| | Wrong file format | Must be .wav, not .mp3 |
| | Copy setting wrong | Set "Copy to Output Directory" = "Copy if newer" |
| WPF won't build | Wrong project type | Must be ".NET Framework", not ".NET Core" |
| | Missing reference | Add System.Windows.Forms reference |
| Console closes immediately | No pause | Run with Ctrl+F5 instead of F5 |
| Colors not showing | Old Command Prompt | Use Windows Terminal |
| ASCII art looks wrong | Wrong font | Set console font to Consolas or Courier New |
| GitHub Actions fails | YAML syntax error | Check indentation, must be spaces not tabs |
| | Solution file missing | Ensure .sln file is in repository |
| Bot doesn't understand | Typo in input | Use suggested keywords |
| | Keyword not in list | Add keyword to keywordMap |
| Audio file not found in WPF | Wrong path | Use absolute path with BaseDirectory |
| Dictionary key error | Key doesn't exist | Check with ContainsKey() before accessing |

 PROJECT CHECKLIST

 Part 1 Requirements

| Requirement | Status | Location |
|-------------|--------|----------|
| Console application | Complete | Program.cs |
| Voice greeting with WAV | Complete | AudioService.cs |
| ASCII art display | Complete | UIHelper.cs |
| Colored text | Complete | UIHelper.cs |
| Typing effect | Complete | UIHelper.TypeWrite() |
| Input validation | Complete | Chatbot.GetUserName() |
| String manipulation | Complete | Throughout all files |
| No hardcoded numbers | Complete | ConvertStringToInt() methods |
| 6+ GitHub commits | Complete | See commit history |
| CI workflow | Complete | .github/workflows/build.yml |

Part 2 Requirements

| Requirement | Status | Location |
|-------------|--------|----------|
| WPF application | Complete | MainWindow.xaml |
| Voice in GUI | Complete | MainWindow.xaml.cs |
| ASCII art in GUI | Complete | MainWindow.xaml |
| Clean GUI design | Complete | XAML styles |
| Keyword recognition (3+) | Complete | ChatbotEngine.cs (6 topics) |
| Random responses | Complete | ChatbotEngine.cs |
| Conversation flow | Complete | Follow-up methods |
| Memory feature | Complete | userMemory Dictionary |
| Sentiment detection | Complete | DetectSentiment() |
| Error handling | Complete | Try-catch, null checks |
| Dictionary/Lists used | Complete | responseDatabase, keywordMap |
| 2+ GitHub releases | Complete | v1.0.0, v2.0.0 |


 CONTACT AND SUPPORT

Student Name: CATHRINE MATLALA LETSOALO

Student Number: ST10477325

Course: PROG6221 - Programming 2B

Institution: The Independent Institute of Education (IIE)

Year: 2026

Thank you for using the Cybersecurity Awareness Chatbot!

Stay safe online!

End of README.md
