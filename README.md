# Cybersecurity Awareness Chatbot

## A South African Initiative for Online Safety

## TABLE OF CONTENTS

1. [Project Overview](#project-overview)
2. [What This Chatbot Does](#what-this-chatbot-does)
3. [Part 1 vs Part 2 vs Part 3 Explained](#part-1-vs-part-2-vs-part-3-explained)
4. [Technical Requirements](#technical-requirements)
5. [How to Run the Program](#how-to-run-the-program)
6. [How to Use the Chatbot](#how-to-use-the-chatbot)
7. [Complete Code Structure](#complete-code-structure)
8. [String Manipulation Techniques](#string-manipulation-techniques)
9. [Common Problems and Solutions](#common-problems-and-solutions)
10. [Project Checklist](#project-checklist)

## PROJECT OVERVIEW

The Cybersecurity Awareness Chatbot is an educational application designed to help South African citizens learn about online safety. Cyber attacks are increasing in South Africa, targeting individuals, businesses, and government institutions. This chatbot teaches users how to:

- Create and manage strong passwords
- Recognize phishing emails and scams
- Browse the internet safely
- Protect personal privacy online
- Prevent malware and virus infections
- Develop good cybersecurity habits
- Manage tasks and set reminders (NEW - Task 3)
- View activity logs of all actions (NEW - Task 4)

The project is divided into FOUR parts as required by the PROG6221 POE assignment.

## WHAT THIS CHATBOT DOES

When you run the chatbot, it will:

1. Greet you with voice - Plays a recorded welcome message
2. Ask for your name - Personalizes the conversation
3. Show a menu of topics - Displays what you can learn about
4. Answer your questions - Responds to cybersecurity questions
5. Give different tips each time - Random responses keep it interesting
6. Remember what you say - Recalls your name and interests
7. Detect your mood - Responds differently if you're worried or curious
8. Suggest follow-up topics - Offers more information on your chosen topic
9. Add tasks using natural language - NEW in Task 3
10. Set reminders using natural language - NEW in Task 3
11. Show activity log of all actions - NEW in Task 4


## PART 1 VS PART 2 VS PART 3 EXPLAINED

| Feature | Part 1 (Console) | Part 2 (WPF) | Part 3 (NLP + Log) |
|---------|-----------------|--------------|---------------------|
| Interface | Text-based command window | Modern window with buttons | Modern window with buttons |
| Voice Greeting | Yes | Yes | Yes |
| ASCII Art Logo | Yes | Yes | Yes |
| Colored Text | Yes | Yes (colored bubbles) | Yes (colored bubbles) |
| Typing Effect | Yes | Yes | Yes |
| Keyword Recognition | Yes (basic) | Yes (advanced) | Yes (advanced) |
| Random Responses | No | Yes | Yes |
| Memory Feature | No | Yes | Yes |
| Sentiment Detection | No | Yes | Yes |
| Follow-up Options | No | Yes | Yes |
| Topic Buttons | No | Yes | Yes |
| Task Management (NLP) | No | No | Yes |
| Reminder System (NLP) | No | No | Yes |
| Activity Log | No | No | Yes |

### Part 1 - Console Application
- Runs in a black command window (like old DOS programs)
- User types commands like "help", "1", "exit"
- Focuses on core functionality

### Part 2 - WPF Application
- Runs in a modern window with buttons and chat bubbles
- User can click buttons OR type questions
- Includes ALL advanced features

### Part 3 - NLP and Activity Log (NEW)
- Natural Language Processing for task management
- Set reminders using everyday language
- Complete and delete tasks
- View activity log with timestamps
- Tracks all user actions

## TECHNICAL REQUIREMENTS

### What You Need Before Starting

| Requirement | Specification |
|-------------|---------------|
| Operating System | Windows 10 or Windows 11 |
| Visual Studio | 2022 Community Edition (free) |
| .NET Framework | Version 4.8 or higher |
| Git | For version control (optional but recommended) |
| Audio | Speakers or headphones for voice greeting |
| Storage | At least 100 MB free space |

## HOW TO RUN THE PROGRAM
Running the WPF Application (Part 3)
In Solution Explorer, right-click "CybersecurityChatbotWPF"
Click "Set as Startup Project" (makes it bold)
Press F5 (or click "Debug" then "Start Debugging")
The GUI window will open with the chatbot

##HOW TO USE THE CHATBOT

What You Will See When It Starts

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
|  +-----------------------------------------------------------------+  |
|  | Bot: I can now help you with TASKS and REMINDERS!               |  |
|  +-----------------------------------------------------------------+  |
|                                                                       |
|  [1.Password] [2.Phishing] [3.Safe Browsing] [4.Privacy]             |
|  [5.Malware] [6.General Tips] [Show Tasks] [Show Reminders]          |
|  [Show Activity Log]                                                 |
|                                                                       |
+-----------------------------------------------------------------------+
|  [ Type your message here...                               ] [SEND]  |
|                                                             [CLEAR]  |
+-----------------------------------------------------------------------+

#Commands You Can Type

Command Type	Examples
Topic Selection	"1", "2", "3", "4", "5", "6"
Ask Questions	"What is a strong password?"
Add Task	"Add a task to enable two-factor authentication"
Add Task	"Create task to review privacy settings"
Set Reminder	"Remind me to update my password tomorrow"
Set Reminder	"Set reminder to backup my files"
Show Tasks	"Show my tasks"
Show Reminders	"Show my reminders"
Complete Task	"Complete task 1"
Delete Task	"Delete task 2"
Activity Log	"Show activity log"
Activity Log	"What have you done for me?"
Help	"help", "menu"
Exit	Close window
Topic Buttons
Button	Description
1. Password Safety	Information about creating strong passwords
2. Phishing Awareness	How to recognize and avoid scams
3. Safe Browsing	Tips for secure internet browsing
4. Privacy Protection	How to protect personal information
5. Malware Prevention	Protecting against viruses and malware
6. General Tips	Overall cybersecurity best practices
Show My Tasks	Displays all your tasks
Show My Reminders	Displays all your reminders
Show Activity Log	Displays recent actions
TASK 3: NLP SIMULATION FEATURES
Natural Language Processing for Tasks
The chatbot uses basic string manipulation to understand natural language commands. Here's how it works:

User Says	Bot Understands	Bot Response
"Add a task to enable two-factor authentication"	Task addition	"Task added: 'enable two-factor authentication'"
"Create task to review privacy settings"	Task addition	"Task added: 'review privacy settings'"
"Remind me to update my password tomorrow"	Reminder with date	"Reminder set for 'update my password' on tomorrow's date"
"Set reminder to backup my files next week"	Reminder with date	"Reminder set for 'backup my files' on next week's date"
"Show my tasks"	Display tasks	Shows list of all tasks with status
"Show my reminders"	Display reminders	Shows list of all reminders
"Complete task 1"	Complete task	"Task marked as completed"
"Delete task 2"	Delete task	"Task deleted"
How NLP String Manipulation Works
The chatbot uses these string manipulation techniques for NLP:

String.Contains() - Detects keywords like "add task", "remind me"

String.ToLower() - Makes matching case-insensitive

String.IndexOf() - Finds position of keywords

String.Substring() - Extracts task descriptions

String.Trim() - Removes extra spaces

String.Split() - Parses complex commands

## COMPLETE CODE STRUCTURE

WPF Application Files

CybersecurityChatbotWPF/
│
├── MainWindow.xaml
│   ├── GUI layout and design using XAML
│   ├── ASCII art header
│   ├── ScrollViewer for chat area
│   ├── Message bubbles with styles
│   ├── 6 topic buttons
│   ├── Show Tasks button (NEW - Task 3)
│   ├── Show Reminders button (NEW - Task 3)
│   ├── Show Activity Log button (NEW - Task 4)
│   └── Send and Clear buttons
│
├── MainWindow.xaml.cs
│   ├── Code-behind for the GUI
│   ├── Voice greeting using MediaPlayer
│   ├── NLP processing for tasks and reminders (Task 3)
│   ├── Task and Reminder lists (Task 3)
│   ├── Activity Log with timestamps (Task 4)
│   ├── Sentiment detection
│   ├── Memory storage
│   ├── Typing effect
│   └── Button click handlers
│
├── ChatbotEngine.cs
│   ├── Response logic and keyword matching
│   ├── Response database with Lists
│   ├── Random response selection
│   └── Sentiment-based response adjustment
│
└── audio/
    └── greeting.wav (voice recording file)

## STRING MANIPULATION TECHNIQUES
This project demonstrates extensive string manipulation:

Technique	Example
String Concatenation	"Hello " + userName + "!"
StringBuilder	builder.Append("Welcome ").Append(userName)
String.Contains()	if (input.Contains("password"))
String.ToLower()	string cleanInput = input.ToLower()
String.IsNullOrWhiteSpace()	if (string.IsNullOrWhiteSpace(userName))
String.Replace()	response.Replace("{userName}", actualName)
String.Substring()	message.Substring(0, i)
String.IndexOf()	lowerInput.IndexOf(phrase)
String.Split()	input.Split(new[] { "interested in" })
String.Trim()	afterPhrase.Trim()
Path.Combine()	Path.Combine(baseDir, "audio", "greeting.wav")
No Hardcoded Numbers	ConvertStringToInt("100") instead of 100

## COMMON PROBLEMS AND SOLUTIONS

Problem	Cause	Solution
No voice greeting	Audio file missing	Check audio folder has greeting.wav
Wrong file format	Must be .wav, not .mp3
Copy setting wrong	Set "Copy to Output Directory" = "Copy if newer"
WPF won't build	Wrong project type	Must be ".NET Framework", not ".NET Core"
Tasks not saving	List not initialized	Ensure taskList = new List<TaskItem>() in constructor
Reminders not saving	List not initialized	Ensure reminderList = new List<ReminderItem>() in constructor
Activity log not showing	List not initialized	Ensure activityLog = new List<ActivityLogEntry>() in constructor
NLP not recognizing commands	Missing keywords	Check the keywords in ContainsAny method
Date extraction not working	Format mismatch	Check ExtractReminderDate method
Build errors	Missing using statements	Add using System.Text; using System.Collections.Generic;


## PROJECT CHECKLIST

# Part 1 Requirements

Requirement	Status	Location
Console application	Complete	Program.cs
Voice greeting with WAV	Complete	AudioService.cs
ASCII art display	Complete	UIHelper.cs
Colored text	Complete	UIHelper.cs
Typing effect	Complete	UIHelper.TypeWrite()
Input validation	Complete	Chatbot.GetUserName()
String manipulation	Complete	Throughout all files
No hardcoded numbers	Complete	ConvertStringToInt() methods
6+ GitHub commits	Complete	See commit history
CI workflow	Complete	.github/workflows/build.yml

# Part 2 Requirements

Requirement	Status	Location
WPF application	Complete	MainWindow.xaml
Voice in GUI	Complete	MainWindow.xaml.cs
ASCII art in GUI	Complete	MainWindow.xaml
Clean GUI design	Complete	XAML styles
Keyword recognition (3+)	Complete	ChatbotEngine.cs (6 topics)
Random responses	Complete	ChatbotEngine.cs
Conversation flow	Complete	Follow-up methods
Memory feature	Complete	userMemory Dictionary
Sentiment detection	Complete	DetectSentiment()
Error handling	Complete	Try-catch, null checks
Dictionary/Lists used	Complete	responseDatabase, keywordMap
2+ GitHub releases	Complete	v1.0.0, v2.0.0

# Part 3 (Task 3 & 4) Requirements

Requirement	Status	Location
NLP for task addition	Complete	MainWindow.xaml.cs
NLP for reminder setting	Complete	MainWindow.xaml.cs
Extract task descriptions	Complete	ExtractTaskDescription()
Extract reminder dates	Complete	ExtractReminderDate()
Show tasks command	Complete	ShowAllTasks()
Show reminders command	Complete	ShowAllReminders()
Complete task command	Complete	CompleteTaskFromNLP()
Delete task command	Complete	DeleteTaskFromNLP()
Activity log storage	Complete	activityLog List
Timestamps for actions	Complete	AddToActivityLog()
Last 10 actions only	Complete	activityLog.RemoveAt(Ten())
Show activity log command	Complete	ShowActivityLog()
3+ GitHub releases	Complete	v1.0.0, v2.0.0, v3.0.0

## CONTACT AND SUPPORT

Student Name: CATHRINE MATLALA LETSOALO

Student Number: ST10477325

Course: PROG6221 - Programming 2B

Institution: The Independent Institute of Education (IIE)

Year: 2026

Thank you for using the Cybersecurity Awareness Chatbot!

Stay safe online!

End of README.md
