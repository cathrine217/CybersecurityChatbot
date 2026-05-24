using System;
using System.Collections.Generic;
using System.Threading;

namespace CybersecurityChatbotConsole
{
    public class Chatbot
    {
        private string userName = "";
        private UIHelper ui;
        private Dictionary<string, string> responses;
        private string[] menuOptions;
        private static Random random;

        private int Zero() => ConvertStringToInt("0");
        private int One() => ConvertStringToInt("1");
        private int Two() => ConvertStringToInt("2");
        private int Three() => ConvertStringToInt("3");
        private int Four() => ConvertStringToInt("4");
        private int Five() => ConvertStringToInt("5");
        private int EightHundred() => ConvertStringToInt("800");

        private int ConvertStringToInt(string numberString) => int.Parse(numberString);
        private int GetLength(string text) => text.Length;
        private int Increment(int value) => value + One();

        public Chatbot()
        {
            ui = new UIHelper();
            InitializeMenuOptions();
            InitializeResponses();
            random = new Random();
        }

        private void InitializeMenuOptions()
        {
            menuOptions = new string[]
            {
                "Password Safety",
                "Phishing Awareness",
                "Safe Browsing",
                "General Cybersecurity Tips",
                "About This Bot"
            };
        }

        public void Start()
        {
            ui.DisplayLogo();
            GetUserName();
            ui.PrintWelcomeBanner(userName);
            DisplayWelcome();
            RunConversationLoop();
            ui.PrintGoodbye(userName);
        }

        private void GetUserName()
        {
            ui.PrintPrompt("Please enter your name: ");
            userName = Console.ReadLine();

            bool isEmpty = string.IsNullOrWhiteSpace(userName);

            while (isEmpty)
            {
                ui.PrintError("Name cannot be empty. Please try again.");
                ui.PrintPrompt("Please enter your name: ");
                userName = Console.ReadLine();
                isEmpty = string.IsNullOrWhiteSpace(userName);
            }

            int minimumLength = Two();
            bool isTooShort = GetLength(userName) < minimumLength;

            while (isTooShort)
            {
                ui.PrintWarning("Name must be at least 2 characters long.");
                ui.PrintPrompt("Please enter your name: ");
                userName = Console.ReadLine();
                isTooShort = GetLength(userName) < minimumLength;
            }

            ui.PrintSuccess("Welcome aboard, " + userName + "!");
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

            string[] quickTips = {
                "Never share your passwords with anyone!",
                "Always check email sender addresses carefully",
                "Look for HTTPS and padlock icon on websites"
            };

            ui.PrintTipBox("QUICK TIP", quickTips);
            ui.DisplayMenu(menuOptions);
        }

        private void RunConversationLoop()
        {
            bool running = true;
            int interactionCount = Zero();

            while (running)
            {
                string promptMessage = "\n" + userName + ", enter your question or topic number (1-5): ";
                ui.PrintPrompt(promptMessage);
                string input = Console.ReadLine();

                bool isEmpty = string.IsNullOrWhiteSpace(input);

                if (isEmpty)
                {
                    ui.PrintError("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                string cleanInput = input.ToLower().Trim();
                ui.ShowLoadingAnimation("Processing your request", EightHundred());

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

                string response = CheckMenuNumberSelection(cleanInput);

                if (response == null)
                {
                    response = ProcessInput(cleanInput);
                }

                ui.PrintUserMessage(input, userName);
                ui.PrintResponse(response);

                interactionCount = Increment(interactionCount);

                if (interactionCount % Three() == Zero())
                {
                    ShowRandomSecurityTip();
                }
            }
        }

        private string CheckMenuNumberSelection(string input)
        {
            if (input == One().ToString()) return GetPasswordSafetyResponse();
            if (input == Two().ToString()) return GetPhishingResponse();
            if (input == Three().ToString()) return GetSafeBrowsingResponse();
            if (input == Four().ToString()) return GetGeneralTipsResponse();
            if (input == Five().ToString()) return GetAboutResponse();
            return null;
        }

        private string GetPasswordSafetyResponse() => responses["password"];
        private string GetPhishingResponse() => responses["phishing"];
        private string GetSafeBrowsingResponse() => responses["safebrowsing"];
        private string GetGeneralTipsResponse() => responses["generaltips"];
        private string GetAboutResponse() => responses["about"].Replace("{userName}", userName);

        private string ProcessInput(string input)
        {
            if (ContainsAny(input, new string[] { "hello", "hi", "hey", "greetings" }))
                return "Hello " + userName + "! Great to see you! How can I help you stay safe online today?";

            if (ContainsAny(input, new string[] { "how are you", "how's it going" }))
                return "I'm operating at optimal security levels! Ready to help you navigate the digital world safely.";

            if (ContainsAny(input, new string[] { "purpose", "what can you do", "about", "who are you" }))
                return GetAboutResponse();

            if (ContainsAny(input, new string[] { "password", "passcode", "login", "strong password" }))
                return GetPasswordSafetyResponse();

            if (ContainsAny(input, new string[] { "phishing", "scam", "fake email", "fraud", "spam" }))
                return GetPhishingResponse();

            if (ContainsAny(input, new string[] { "browse", "internet", "website", "https", "browser" }))
                return GetSafeBrowsingResponse();

            if (ContainsAny(input, new string[] { "tip", "advice", "general", "best practice" }))
                return GetGeneralTipsResponse();

            if (ContainsAny(input, new string[] { "virus", "malware", "antivirus", "ransomware" }))
                return responses["malware"];

            if (ContainsAny(input, new string[] { "social engineering", "manipulate", "trick", "psychology" }))
                return responses["socialengineering"];

            if (ContainsAny(input, new string[] { "thank", "thanks" }))
                return "You're very welcome, " + userName + "! Staying safe online is a team effort. Is there anything else I can help you with?";

            return BuildDefaultResponse();
        }

        private bool ContainsAny(string input, string[] searchTerms)
        {
            foreach (string term in searchTerms)
            {
                if (input.ToLower().Contains(term.ToLower()))
                    return true;
            }
            return false;
        }

        private string BuildDefaultResponse()
        {
            return "I didn't quite understand that. Here's what you can ask me:\n\n" +
                   "Type a number (1-5) to select a topic:\n" +
                   "   1 - Password Safety\n" +
                   "   2 - Phishing Awareness\n" +
                   "   3 - Safe Browsing\n" +
                   "   4 - General Cybersecurity Tips\n" +
                   "   5 - About This Bot\n\n" +
                   "Or ask questions like:\n" +
                   "   - 'What is a strong password?'\n" +
                   "   - 'How to spot phishing?'\n" +
                   "   - 'Safe browsing tips'\n\n" +
                   "Type 'menu' to see the full menu again";
        }

        private void ShowRandomSecurityTip()
        {
            string[] tips = {
                "Remember: Banks will NEVER ask for your password via email!",
                "Tip: Use a unique password for each of your accounts.",
                "Tip: Enable two-factor authentication (2FA) for extra security.",
                "Tip: Always log out of accounts when using public computers.",
                "Tip: Keep your software and antivirus updated regularly.",
                "Tip: Never click on suspicious links in emails or messages.",
                "Tip: Use a password manager to generate and store strong passwords."
            };

            int randomIndex = random.Next(tips.Length);
            ui.PrintTipBox("SECURITY TIP", new string[] { tips[randomIndex] });
        }

        private void InitializeResponses()
        {
            responses = new Dictionary<string, string>();
            responses["password"] = BuildPasswordResponse();
            responses["phishing"] = BuildPhishingResponse();
            responses["safebrowsing"] = BuildSafeBrowsingResponse();
            responses["generaltips"] = BuildGeneralTipsResponse();
            responses["about"] = BuildAboutResponse();
            responses["malware"] = BuildMalwareResponse();
            responses["socialengineering"] = BuildSocialEngineeringResponse();
        }

        private string BuildPasswordResponse()
        {
            return "PASSWORD SAFETY - YOUR FIRST LINE OF DEFENSE\n\n" +
                   "DO's:\n" +
                   "   - Use at least 12-16 characters with a mix of uppercase, lowercase, numbers, and symbols\n" +
                   "   - Use a unique password for each account\n" +
                   "   - Use a reputable password manager\n" +
                   "   - Enable Two-Factor Authentication (2FA) on all important accounts\n" +
                   "   - Use passphrases - longer phrases are easier to remember\n\n" +
                   "DON'Ts:\n" +
                   "   - Never reuse passwords across different accounts\n" +
                   "   - Avoid using personal information in passwords\n" +
                   "   - Don't write passwords on sticky notes\n" +
                   "   - Never share passwords via email, text, or phone calls";
        }

        private string BuildPhishingResponse()
        {
            return "PHISHING AWARENESS - DON'T TAKE THE BAIT!\n\n" +
                   "RED FLAGS to watch for:\n" +
                   "   - Urgent or threatening language demanding immediate action\n" +
                   "   - Poor grammar, spelling errors, or unusual phrasing\n" +
                   "   - Suspicious sender email addresses\n" +
                   "   - Generic greetings like 'Dear Customer'\n" +
                   "   - Requests for passwords or personal information\n" +
                   "   - Unexpected attachments or links\n\n" +
                   "PROTECTION STEPS:\n" +
                   "   - Hover over links to see the actual URL before clicking\n" +
                   "   - Never click links in unsolicited emails\n" +
                   "   - Verify suspicious requests by calling the company directly\n" +
                   "   - Legitimate companies NEVER ask for passwords via email";
        }

        private string BuildSafeBrowsingResponse()
        {
            return "SAFE BROWSING PRACTICES - SURF SMART!\n\n" +
                   "SECURE BROWSING HABITS:\n" +
                   "   - Look for HTTPS and the padlock icon before entering sensitive data\n" +
                   "   - Keep your browser, OS, and antivirus software updated\n" +
                   "   - Use reputable antivirus and anti-malware software\n" +
                   "   - Avoid downloading files from untrusted websites\n" +
                   "   - Clear cookies and browsing data regularly\n\n" +
                   "PUBLIC WI-FI SAFETY:\n" +
                   "   - Avoid banking or entering passwords on public Wi-Fi\n" +
                   "   - Use a VPN (Virtual Private Network) on public networks\n" +
                   "   - Turn off file sharing when on public networks";
        }

        private string BuildGeneralTipsResponse()
        {
            return "GENERAL CYBERSECURITY TIPS - STAY PROTECTED!\n\n" +
                   "DEVICE SECURITY:\n" +
                   "   - Keep all software updated (automatic updates recommended)\n" +
                   "   - Use antivirus and firewall protection\n" +
                   "   - Lock your devices with PIN, password, or biometrics\n" +
                   "   - Regularly backup important data\n\n" +
                   "EMAIL AND COMMUNICATION:\n" +
                   "   - Think before you click! Verify unexpected emails\n" +
                   "   - Don't overshare on social media\n" +
                   "   - Use different email addresses for different purposes\n\n" +
                   "ACCOUNT PROTECTION:\n" +
                   "   - Enable 2FA everywhere possible\n" +
                   "   - Use a password manager\n" +
                   "   - Regularly review account activity";
        }

        private string BuildAboutResponse()
        {
            return "ABOUT ME - YOUR CYBERSECURITY ASSISTANT\n\n" +
                   "Hello! I'm {userName}'s personal cybersecurity awareness chatbot.\n\n" +
                   "MY PURPOSE:\n" +
                   "   - Educate about common cyber threats\n" +
                   "   - Provide practical security tips\n" +
                   "   - Help develop safe online habits\n" +
                   "   - Answer cybersecurity questions\n\n" +
                   "TOPICS I COVER:\n" +
                   "   1 - Password Safety\n" +
                   "   2 - Phishing Awareness\n" +
                   "   3 - Safe Browsing\n" +
                   "   4 - General Tips\n\n" +
                   "Remember: Cybersecurity is everyone's responsibility!";
        }

        private string BuildMalwareResponse()
        {
            return "MALWARE PROTECTION - KEEP YOUR DEVICES CLEAN!\n\n" +
                   "PREVENTION TIPS:\n" +
                   "   - Install reputable antivirus software and keep it updated\n" +
                   "   - Never download software from untrusted sources\n" +
                   "   - Be cautious of email attachments\n" +
                   "   - Keep your operating system updated\n" +
                   "   - Use a firewall to protect your network\n" +
                   "   - Backup important data regularly\n\n" +
                   "SIGNS YOUR DEVICE MAY BE INFECTED:\n" +
                   "   - Slow performance or frequent crashes\n" +
                   "   - Unexpected pop-ups or ads\n" +
                   "   - Programs starting or closing automatically\n" +
                   "   - Unusual network activity";
        }

        private string BuildSocialEngineeringResponse()
        {
            return "SOCIAL ENGINEERING - DON'T BE MANIPULATED!\n\n" +
                   "COMMON TACTICS:\n" +
                   "   - Pretexting - Creating fake scenarios to gain trust\n" +
                   "   - Baiting - Offering something enticing to steal information\n" +
                   "   - Quid pro quo - Offering a benefit for information\n\n" +
                   "PROTECTION STRATEGIES:\n" +
                   "   - Be skeptical of unsolicited contact\n" +
                   "   - Verify identities before sharing sensitive data\n" +
                   "   - Don't let urgency pressure you\n" +
                   "   - Never give out passwords or OTP codes to anyone\n" +
                   "   - Trust your instincts - if something feels wrong, it probably is!";
        }
    }
}