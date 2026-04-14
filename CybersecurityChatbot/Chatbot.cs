using System;
using System.Collections.Generic;
using System.Threading;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private string userName = "";
        private UIHelper ui;
        private Dictionary<string, string> responses;
        private string[] menuOptions = {
            "Password Safety",
            "Phishing Awareness",
            "Safe Browsing",
            "General Cybersecurity Tips",
            "About This Bot"
        };

        public Chatbot()
        {
            ui = new UIHelper();
            InitializeResponses();
        }

        public void Start()
        {
            // Display ASCII art logo with animation
            ui.DisplayLogo();

            // Get user's name with validation
            GetUserName();

            // Display personalized welcome
            ui.PrintWelcomeBanner(userName);

            // Show available topics
            DisplayWelcome();

            // Main conversation loop
            RunConversationLoop();

            // Goodbye message
            ui.PrintGoodbye(userName);
        }

        private void GetUserName()
        {
            ui.PrintPrompt("Please enter your name: ");
            userName = Console.ReadLine();

            // Validate name input
            while (string.IsNullOrWhiteSpace(userName))
            {
                ui.PrintError("Name cannot be empty. Please try again.");
                ui.PrintPrompt("Please enter your name: ");
                userName = Console.ReadLine();
            }

            // Validate name length
            while (userName.Length < 2)
            {
                ui.PrintWarning("Name must be at least 2 characters long.");
                ui.PrintPrompt("Please enter your name: ");
                userName = Console.ReadLine();
            }

            ui.PrintSuccess($"Welcome aboard, {userName}!");
        }

        private void DisplayWelcome()
        {
            ui.PrintSectionHeader("How Can I Help You Today?");

            ui.PrintInfo("I'm your personal cybersecurity assistant!");
            ui.PrintBullet("Ask me about password safety");
            ui.PrintBullet("Learn how to spot phishing attacks");
            ui.PrintBullet("Get tips for safe browsing");
            ui.PrintBullet("Type 'menu' to see all options");
            ui.PrintBullet("Type 'exit' to quit");

            ui.PrintTipBox("QUICK TIP", new string[] {
                "Never share your passwords with anyone!",
                "Always check email sender addresses carefully",
                "Look for HTTPS and padlock icon on websites"
            });

            ui.DisplayMenu(menuOptions);
        }

        private void RunConversationLoop()
        {
            bool running = true;

            while (running)
            {
                ui.PrintPrompt($"\n{userName}, enter your question or topic number (1-5): ");
                string input = Console.ReadLine();

                // Validate input
                if (string.IsNullOrWhiteSpace(input))
                {
                    ui.PrintError("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                string cleanInput = input.ToLower().Trim();

                // Show progress for processing
                ui.ShowLoadingAnimation("Processing your request", 800);

                // Check for special commands
                if (cleanInput == "exit" || cleanInput == "quit" || cleanInput == "bye")
                {
                    running = false;
                    break;
                }

                if (cleanInput == "menu" || cleanInput == "help")
                {
                    ui.DisplayMenu(menuOptions);
                    continue;
                }

                if (cleanInput == "clear")
                {
                    Console.Clear();
                    ui.DisplayLogo();
                    continue;
                }

                // Check if user entered a menu number (1-5)
                string response = CheckMenuNumberSelection(cleanInput);

                // If not a menu number, process as text input
                if (response == null)
                {
                    response = ProcessInput(cleanInput);
                }

                // Display user message and bot response
                ui.PrintUserMessage(input, userName);
                ui.PrintResponse(response);

                // Show security tip after every 3 interactions
                ShowRandomSecurityTip();
            }
        }

        private string CheckMenuNumberSelection(string input)
        {
            switch (input)
            {
                case "1":
                    return GetPasswordSafetyResponse();
                case "2":
                    return GetPhishingResponse();
                case "3":
                    return GetSafeBrowsingResponse();
                case "4":
                    return GetGeneralTipsResponse();
                case "5":
                    return GetAboutResponse();
                default:
                    return null;
            }
        }

        private string GetPasswordSafetyResponse()
        {
            return responses["password"];
        }

        private string GetPhishingResponse()
        {
            return responses["phishing"];
        }

        private string GetSafeBrowsingResponse()
        {
            return responses["safebrowsing"];
        }

        private string GetGeneralTipsResponse()
        {
            return responses["generaltips"];
        }

        private string GetAboutResponse()
        {
            // FIXED: Now uses the stored userName (already set by GetUserName)
            string aboutResponse = responses["about"];
            return aboutResponse.Replace("{userName}", userName);
        }

        private string ProcessInput(string input)
        {
            // Check for greetings
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey") || input.Contains("greetings"))
            {
                return $"Hello {userName}! Great to see you! How can I help you stay safe online today?\n\n" +
                       $"💡 Tip: Type 'menu' to see all topics or enter a number 1-5 to select directly!";
            }

            // Check for 'how are you'
            if (input.Contains("how are you") || input.Contains("how's it going"))
            {
                return "I'm operating at optimal security levels! Ready to help you navigate the digital world safely.";
            }

            // Check for purpose/about
            if (input.Contains("purpose") || input.Contains("what can you do") || input.Contains("about") || input.Contains("who are you"))
            {
                return GetAboutResponse();
            }

            // Check for password-related queries
            if (input.Contains("password") || input.Contains("passcode") || input.Contains("login") || input.Contains("strong password"))
            {
                return GetPasswordSafetyResponse();
            }

            // Check for phishing-related queries
            if (input.Contains("phishing") || input.Contains("scam") || input.Contains("fake email") || input.Contains("fraud") || input.Contains("spam"))
            {
                return GetPhishingResponse();
            }

            // Check for safe browsing queries
            if (input.Contains("browse") || input.Contains("internet") || input.Contains("website") || input.Contains("https") || input.Contains("browser"))
            {
                return GetSafeBrowsingResponse();
            }

            // Check for general tips
            if (input.Contains("tip") || input.Contains("advice") || input.Contains("general") || input.Contains("best practice"))
            {
                return GetGeneralTipsResponse();
            }

            // Check for malware/virus
            if (input.Contains("virus") || input.Contains("malware") || input.Contains("antivirus") || input.Contains("ransomware"))
            {
                return responses["malware"];
            }

            // Check for social engineering
            if (input.Contains("social engineering") || input.Contains("manipulate") || input.Contains("trick") || input.Contains("psychology"))
            {
                return responses["socialengineering"];
            }

            // Check for thank you
            if (input.Contains("thank") || input.Contains("thanks"))
            {
                return $"You're very welcome, {userName}! Staying safe online is a team effort. " +
                       $"Is there anything else I can help you with? Type 'menu' to see all topics!";
            }

            // Default response with helpful suggestions
            return "I didn't quite understand that. Here's what you can ask me:\n\n" +
                   "📌 Type a number (1-5) to select a topic:\n" +
                   "   1 - Password Safety\n" +
                   "   2 - Phishing Awareness\n" +
                   "   3 - Safe Browsing\n" +
                   "   4 - General Cybersecurity Tips\n" +
                   "   5 - About This Bot\n\n" +
                   "📌 Or ask questions like:\n" +
                   "   - 'What is a strong password?'\n" +
                   "   - 'How to spot phishing?'\n" +
                   "   - 'Safe browsing tips'\n\n" +
                   "📌 Type 'menu' to see the full menu again";
        }

        private static Random rand = new Random();

        private void ShowRandomSecurityTip()
        {
            string[] tips = {
                "Remember: Banks will NEVER ask for your password via email!",
                "Tip: Use a unique password for each of your accounts.",
                "Tip: Enable two-factor authentication (2FA) for extra security.",
                "Tip: Always log out of accounts when using public computers.",
                "Tip: Keep your software and antivirus updated regularly.",
                "Tip: Never click on suspicious links in emails or messages.",
                "Tip: Use a password manager to generate and store strong passwords.",
                "Tip: Regularly check your bank statements for unauthorized transactions.",
                "Tip: Be careful what you post on social media - oversharing is risky!",
                "Tip: Update your devices as soon as security patches are available."
            };

            string randomTip = tips[rand.Next(tips.Length)];
            ui.PrintTipBox("🔒 DID YOU KNOW?", new string[] { randomTip });
        }

        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>();

            responses["password"] = "🔐 PASSWORD SAFETY - YOUR FIRST LINE OF DEFENSE 🔐\n\n" +
                "✅ DO's:\n" +
                "   • Use at least 12-16 characters with a mix of uppercase, lowercase, numbers, and symbols\n" +
                "   • Use a unique password for each account\n" +
                "   • Use a reputable password manager (Bitwarden, LastPass, or 1Password)\n" +
                "   • Enable Two-Factor Authentication (2FA) on all important accounts\n" +
                "   • Use passphrases - longer phrases are easier to remember and harder to crack\n" +
                "   • Change passwords immediately if you suspect any account compromise\n\n" +
                "❌ DON'Ts:\n" +
                "   • Never reuse passwords across different accounts\n" +
                "   • Avoid using personal information (birthdays, names, pet names) in passwords\n" +
                "   • Don't write passwords on sticky notes or store them in plain text files\n" +
                "   • Never share passwords via email, text, or phone calls\n\n" +
                "💡 Example of a strong password: BlueCoffee$42Mountain!Tree\n" +
                "💡 Example of a passphrase: Correct-Horse-Battery-Staple";

            responses["phishing"] = "🎣 PHISHING AWARENESS - DON'T TAKE THE BAIT! 🎣\n\n" +
                "⚠️ RED FLAGS to watch for:\n" +
                "   • Urgent or threatening language demanding immediate action\n" +
                "   • Poor grammar, spelling errors, or unusual phrasing\n" +
                "   • Suspicious sender email addresses (slight misspellings of real companies)\n" +
                "   • Generic greetings like 'Dear Customer' instead of your name\n" +
                "   • Requests for passwords, PINs, or personal information\n" +
                "   • Unexpected attachments or links\n\n" +
                "✅ PROTECTION STEPS:\n" +
                "   • Hover over links to see the actual URL before clicking\n" +
                "   • Never click links in unsolicited emails - type the URL directly\n" +
                "   • Verify suspicious requests by calling the company directly\n" +
                "   • Legitimate companies NEVER ask for passwords via email\n" +
                "   • Report phishing attempts to the legitimate company\n" +
                "   • When in doubt, delete the email\n\n" +
                "📧 Example of phishing: 'Your account will be closed! Click here to verify NOW!'";

            responses["safebrowsing"] = "🌐 SAFE BROWSING PRACTICES - SURF SMART! 🌐\n\n" +
                "✅ SECURE BROWSING HABITS:\n" +
                "   • Look for HTTPS and the padlock icon 🔒 before entering sensitive data\n" +
                "   • Keep your browser, OS, and antivirus software updated\n" +
                "   • Use reputable antivirus and anti-malware software\n" +
                "   • Avoid downloading files from untrusted websites\n" +
                "   • Be cautious of pop-ups and unexpected download prompts\n" +
                "   • Use privacy-focused browsers or enable privacy modes\n" +
                "   • Clear cookies and browsing data regularly\n\n" +
                "⚠️ PUBLIC WI-FI SAFETY:\n" +
                "   • Avoid banking or entering passwords on public Wi-Fi\n" +
                "   • Use a VPN (Virtual Private Network) on public networks\n" +
                "   • Turn off file sharing when on public networks\n" +
                "   • Verify the correct Wi-Fi network name before connecting\n\n" +
                "🛡️ BROWSER EXTENSIONS to consider:\n" +
                "   • uBlock Origin (blocks ads and trackers)\n" +
                "   • HTTPS Everywhere (forces secure connections)\n" +
                "   • Password manager extension";

            responses["generaltips"] = "🛡️ GENERAL CYBERSECURITY TIPS - STAY PROTECTED! 🛡️\n\n" +
                "📱 DEVICE SECURITY:\n" +
                "   • Keep all software updated (automatic updates recommended)\n" +
                "   • Use antivirus and firewall protection\n" +
                "   • Lock your devices with PIN, password, or biometrics\n" +
                "   • Encrypt sensitive files and your hard drive\n" +
                "   • Regularly backup important data to external drive or cloud\n\n" +
                "📧 EMAIL & COMMUNICATION:\n" +
                "   • Think before you click! Verify unexpected emails\n" +
                "   • Don't overshare on social media\n" +
                "   • Be careful what you post - it can be used for social engineering\n" +
                "   • Use different email addresses for different purposes\n\n" +
                "💳 ONLINE SHOPPING:\n" +
                "   • Use credit cards instead of debit cards for better fraud protection\n" +
                "   • Look for trust seals and read reviews before buying\n" +
                "   • Check statements regularly for unauthorized charges\n" +
                "   • Avoid saving payment information on shopping sites\n\n" +
                "🔑 ACCOUNT PROTECTION:\n" +
                "   • Enable 2FA everywhere possible\n" +
                "   • Use a password manager\n" +
                "   • Regularly review account activity and connected devices\n" +
                "   • Remove unused accounts and apps";

            responses["about"] = "🤖 ABOUT ME - YOUR CYBERSECURITY ASSISTANT 🤖\n\n" +
                $"Hello! I'm {{userName}}'s personal cybersecurity awareness chatbot.\n\n" +
                "🎯 MY PURPOSE:\n" +
                "   • Educate about common cyber threats\n" +
                "   • Provide practical security tips\n" +
                "   • Help develop safe online habits\n" +
                "   • Answer cybersecurity questions\n\n" +
                "📚 TOPICS I COVER:\n" +
                "   1️⃣ Password Safety - Create and manage strong passwords\n" +
                "   2️⃣ Phishing Awareness - Recognize and avoid scams\n" +
                "   3️⃣ Safe Browsing - Navigate the web securely\n" +
                "   4️⃣ General Tips - Overall cybersecurity best practices\n\n" +
                "💡 HOW TO USE ME:\n" +
                "   • Type numbers 1-5 to select topics directly\n" +
                "   • Ask questions in plain English\n" +
                "   • Type 'menu' to see all options\n" +
                "   • Type 'exit' to quit\n\n" +
                "🆓 I'm completely free and here to help South African citizens stay safe online!\n" +
                "Remember: Cybersecurity is everyone's responsibility!";

            responses["malware"] = "🦠 MALWARE PROTECTION - KEEP YOUR DEVICES CLEAN! 🦠\n\n" +
                "✅ PREVENTION TIPS:\n" +
                "   • Install reputable antivirus software and keep it updated\n" +
                "   • Never download software from untrusted sources\n" +
                "   • Be cautious of email attachments, even from known contacts\n" +
                "   • Keep your operating system and all applications updated\n" +
                "   • Use a firewall to protect your network\n" +
                "   • Regularly scan your device for malware\n" +
                "   • Backup important data regularly to protect against ransomware\n\n" +
                "⚠️ SIGNS YOUR DEVICE MAY BE INFECTED:\n" +
                "   • Slow performance or frequent crashes\n" +
                "   • Unexpected pop-ups or ads\n" +
                "   • Programs starting or closing automatically\n" +
                "   • Changes to your browser homepage\n" +
                "   • Unusual network activity\n\n" +
                "🛠️ IF INFECTED:\n" +
                "   • Run a full antivirus scan immediately\n" +
                "   • Disconnect from the internet\n" +
                "   • Boot into Safe Mode\n" +
                "   • Seek professional help if needed";

            responses["socialengineering"] = "🧠 SOCIAL ENGINEERING - DON'T BE MANIPULATED! 🧠\n\n" +
                "⚠️ COMMON TACTICS:\n" +
                "   • Pretexting - Creating fake scenarios to gain trust\n" +
                "   • Baiting - Offering something enticing to steal information\n" +
                "   • Tailgating - Following someone into restricted areas\n" +
                "   • Quid pro quo - Offering a benefit for information\n\n" +
                "✅ PROTECTION STRATEGIES:\n" +
                "   • Be skeptical of unsolicited contact requesting personal information\n" +
                "   • Verify identities before sharing sensitive data\n" +
                "   • Don't let urgency pressure you into making hasty decisions\n" +
                "   • Be careful what you share on social media - scammers research targets\n" +
                "   • Never give out passwords, PINs, or OTP codes to anyone\n" +
                "   • When in doubt, verify through official channels\n" +
                "   • Trust your instincts - if something feels wrong, it probably is!";
        }
    }
}