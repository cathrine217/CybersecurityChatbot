using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CybersecurityChatbotWPF
{
    public class ChatbotEngine
    {
        private Dictionary<string, List<string>> responseDatabase;
        private Dictionary<string, string> keywordMap;
        private Random random;
        private string lastTopic = "";

        private int Zero() => ConvertStringToInt("0");
        private int One() => ConvertStringToInt("1");
        private int ConvertStringToInt(string numberString) => int.Parse(numberString);

        public ChatbotEngine()
        {
            random = new Random();
            InitializeResponses();
            InitializeKeywordMap();
        }

        private void InitializeResponses()
        {
            responseDatabase = new Dictionary<string, List<string>>();

            // Password responses
            List<string> passwordResponses = new List<string>
            {
                "Use strong passwords with 12+ characters mixing uppercase, lowercase, numbers, and symbols!",
                "Never reuse passwords across multiple accounts - use a password manager!",
                "Avoid using personal info like birthdays or pet names in passwords.",
                "Enable Two-Factor Authentication whenever possible for extra security!"
            };
            responseDatabase.Add("password", passwordResponses);

            // Phishing responses
            List<string> phishingResponses = new List<string>
            {
                "Always check email sender addresses carefully - scammers use lookalike domains!",
                "Never click links in suspicious emails. Hover to see the actual URL first!",
                "Look for spelling errors and urgent language - common phishing tactics!",
                "Legitimate companies never ask for passwords via email!"
            };
            responseDatabase.Add("phishing", phishingResponses);

            // Privacy responses
            List<string> privacyResponses = new List<string>
            {
                "Review your social media privacy settings regularly!",
                "Limit what personal info you share publicly online.",
                "Use privacy-focused browsers and search engines.",
                "Check app permissions regularly!"
            };
            responseDatabase.Add("privacy", privacyResponses);

            // Malware responses
            List<string> malwareResponses = new List<string>
            {
                "Keep your antivirus software updated and run regular scans!",
                "Don't download software from untrusted websites.",
                "Be careful with USB drives from unknown sources.",
                "Enable automatic updates for your operating system!"
            };
            responseDatabase.Add("malware", malwareResponses);

            // Safe Browsing responses
            List<string> safeBrowsingResponses = new List<string>
            {
                "Look for HTTPS and the padlock icon before entering sensitive data!",
                "Avoid using public Wi-Fi for banking or sensitive transactions.",
                "Use a VPN when connecting to public networks.",
                "Clear your browser cookies and cache regularly."
            };
            responseDatabase.Add("safebrowsing", safeBrowsingResponses);

            // General Tips responses
            List<string> generalResponses = new List<string>
            {
                "Always backup your important data regularly!",
                "Keep all your software updated for security patches.",
                "Be careful what you share on social media!",
                "Use different passwords for different accounts."
            };
            responseDatabase.Add("general", generalResponses);
        }

        private void InitializeKeywordMap()
        {
            keywordMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            keywordMap.Add("password", "password");
            keywordMap.Add("passphrase", "password");
            keywordMap.Add("pass", "password");
            keywordMap.Add("phish", "phishing");
            keywordMap.Add("phishing", "phishing");
            keywordMap.Add("scam", "phishing");
            keywordMap.Add("fraud", "phishing");
            keywordMap.Add("privacy", "privacy");
            keywordMap.Add("private", "privacy");
            keywordMap.Add("malware", "malware");
            keywordMap.Add("virus", "malware");
            keywordMap.Add("ransomware", "malware");
            keywordMap.Add("browse", "safebrowsing");
            keywordMap.Add("internet", "safebrowsing");
            keywordMap.Add("website", "safebrowsing");
            keywordMap.Add("https", "safebrowsing");
            keywordMap.Add("wifi", "safebrowsing");
            keywordMap.Add("tip", "general");
            keywordMap.Add("advice", "general");
        }

        public string GetTopicResponse(string topic, string userName)
        {
            if (responseDatabase.ContainsKey(topic))
            {
                lastTopic = topic;
                List<string> responses = responseDatabase[topic];
                return responses[random.Next(responses.Count)];
            }
            return "I have information on that topic! Type a number 1-6 to see available topics.";
        }

        public async Task<string> GetResponseAsync(string userInput, string sentiment,
            Dictionary<string, string> memory, string userName)
        {
            await Task.Delay(OneHundred());

            string lowerInput = userInput.ToLower();

            // Check for follow-up requests
            if (ContainsAny(lowerInput, new[] { "another tip", "tell me more", "more" }))
            {
                if (!string.IsNullOrEmpty(lastTopic) && responseDatabase.ContainsKey(lastTopic))
                {
                    List<string> responses = responseDatabase[lastTopic];
                    return responses[random.Next(responses.Count)];
                }
            }

            // Check for memory - name recall
            if (memory.ContainsKey("name") && ContainsAny(lowerInput, new[] { "my name", "remember me" }))
            {
                return "I remember! You said your name is " + memory["name"] + "!";
            }

            // Check for memory - interest recall
            if (memory.ContainsKey("interest") && ContainsAny(lowerInput, new[] { "remember", "interested" }))
            {
                return "As someone interested in " + memory["interest"] + ", you might want to learn more about that!";
            }

            // Check for menu/help
            if (ContainsAny(lowerInput, new[] { "menu", "help", "options" }))
            {
                return GetHelpMessage();
            }

            // Greeting response
            if (ContainsAny(lowerInput, new[] { "hello", "hi", "hey", "greetings" }))
            {
                return "Hello " + userName + "! Type 'menu' to see all topics I can help you with!";
            }

            // Thank you response
            if (ContainsAny(lowerInput, new[] { "thank", "thanks" }))
            {
                return "You're welcome, " + userName + "! Stay safe online!";
            }

            // Keyword matching
            foreach (var kvp in keywordMap)
            {
                if (lowerInput.Contains(kvp.Key))
                {
                    lastTopic = kvp.Value;
                    List<string> responses = responseDatabase[kvp.Value];
                    return AdjustResponseForSentiment(responses[random.Next(responses.Count)], sentiment, userName);
                }
            }

            return "I'm not sure I understand. Try asking about passwords, phishing, or privacy! You can also say 'Add a task' or 'Remind me'.";
        }

        private int OneHundred()
        {
            return ConvertStringToInt("100");
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

        private string AdjustResponseForSentiment(string response, string sentiment, string userName)
        {
            if (sentiment == "worried")
            {
                return "It's completely normal to feel concerned, " + userName + ". " + response;
            }
            else if (sentiment == "frustrated")
            {
                return "I understand this can be frustrating. Let me simplify: " + response;
            }
            else if (sentiment == "curious")
            {
                return "Great question! I'm glad you're curious. " + response;
            }
            return response;
        }

        private string GetHelpMessage()
        {
            return "AVAILABLE TOPICS:\n" +
                   "1. PASSWORD SAFETY\n2. PHISHING AWARENESS\n3. SAFE BROWSING\n" +
                   "4. PRIVACY PROTECTION\n5. MALWARE PREVENTION\n6. GENERAL TIPS\n\n" +
                   "TASK FEATURES:\n- Add a task to...\n- Remind me to...\n- Show my tasks\n" +
                   "- Show activity log\n\nType a number 1-6 or ask me a question!";
        }
    }
}