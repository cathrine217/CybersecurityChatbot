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

        public ChatbotEngine()
        {
            random = new Random();
            InitializeResponses();
            InitializeKeywordMap();
        }

        private void InitializeResponses()
        {
            responseDatabase = new Dictionary<string, List<string>>();

            var passwordResponses = new List<string>
            {
                "Use strong passwords with 12+ characters mixing uppercase, lowercase, numbers, and symbols!",
                "Never reuse passwords across multiple accounts - use a password manager!",
                "Avoid using personal info like birthdays or pet names in passwords.",
                "Enable Two-Factor Authentication whenever possible for extra security!"
            };
            responseDatabase.Add("password", passwordResponses);

            var phishingResponses = new List<string>
            {
                "Always check email sender addresses carefully - scammers use lookalike domains!",
                "Never click links in suspicious emails. Hover to see the actual URL first!",
                "Look for spelling errors and urgent language - common phishing tactics!",
                "Legitimate companies never ask for passwords via email!"
            };
            responseDatabase.Add("phishing", phishingResponses);

            var privacyResponses = new List<string>
            {
                "Review your social media privacy settings regularly!",
                "Limit what personal info you share publicly online.",
                "Use privacy-focused browsers and search engines.",
                "Check app permissions regularly."
            };
            responseDatabase.Add("privacy", privacyResponses);

            var malwareResponses = new List<string>
            {
                "Keep your antivirus software updated and run regular scans!",
                "Don't download software from untrusted websites.",
                "Be careful with USB drives from unknown sources.",
                "Enable automatic updates for your operating system!"
            };
            responseDatabase.Add("malware", malwareResponses);

            var generalResponses = new List<string>
            {
                "Always backup your important data regularly!",
                "Keep all your software updated for security patches.",
                "Use a VPN when connecting to public Wi-Fi.",
                "Be careful what you share on social media!"
            };
            responseDatabase.Add("general", generalResponses);
        }

        private void InitializeKeywordMap()
        {
            keywordMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keywordMap.Add("password", "password");
            keywordMap.Add("passphrase", "password");
            keywordMap.Add("phish", "phishing");
            keywordMap.Add("phishing", "phishing");
            keywordMap.Add("privacy", "privacy");
            keywordMap.Add("malware", "malware");
            keywordMap.Add("virus", "malware");
            keywordMap.Add("scam", "phishing");
            keywordMap.Add("tip", "general");
            keywordMap.Add("advice", "general");
            keywordMap.Add("safe browsing", "general");
            keywordMap.Add("internet", "general");
        }

        public async Task<string> GetResponseAsync(string userInput, string sentiment,
            Dictionary<string, string> memory, string userName)
        {
            await Task.Delay(100);

            // Check for follow-up requests
            if (userInput.ToLower().Contains("another tip") ||
                userInput.ToLower().Contains("tell me more"))
            {
                if (!string.IsNullOrEmpty(lastTopic) && responseDatabase.ContainsKey(lastTopic))
                {
                    var responses = responseDatabase[lastTopic];
                    return responses[random.Next(responses.Count)] + " Would you like another tip?";
                }
            }

            // Check for memory usage
            if (memory.ContainsKey("name") && userInput.ToLower().Contains("my name"))
            {
                return "I remember! You said your name is " + memory["name"] +
                    ". How can I help you with cybersecurity?";
            }

            if (memory.ContainsKey("interest") && userInput.ToLower().Contains("remember"))
            {
                return "As someone interested in " + memory["interest"] +
                    ", you might want to learn more about keeping that aspect secure!";
            }

            // Keyword matching
            string matchedTopic = null;
            foreach (var kvp in keywordMap)
            {
                if (userInput.ToLower().Contains(kvp.Key))
                {
                    matchedTopic = kvp.Value;
                    lastTopic = matchedTopic;
                    break;
                }
            }

            // Response based on matched topic
            if (matchedTopic != null && responseDatabase.ContainsKey(matchedTopic))
            {
                var responses = responseDatabase[matchedTopic];
                string baseResponse = responses[random.Next(responses.Count)];
                return AdjustResponseForSentiment(baseResponse, sentiment, userName);
            }

            // Help response
            if (userInput.ToLower().Contains("help") || userInput.ToLower().Contains("menu"))
            {
                return GetHelpMessage();
            }

            // Greeting response
            if (ContainsAny(userInput, new[] { "hello", "hi", "hey" }))
            {
                return "Hello " + userName + "! How can I help you stay safe online today?";
            }

            // Thank you response
            if (ContainsAny(userInput, new[] { "thank", "thanks" }))
            {
                return "You're welcome, " + userName + "! Stay safe online!";
            }

            // Default response
            return "I'm not sure I understand. Can you try rephrasing? " +
                   "Ask about passwords, phishing, privacy, or malware protection!";
        }

        private bool ContainsAny(string input, string[] terms)
        {
            foreach (string term in terms)
            {
                if (input.ToLower().Contains(term))
                    return true;
            }
            return false;
        }

        private string AdjustResponseForSentiment(string response, string sentiment, string userName)
        {
            if (sentiment == "worried")
            {
                return "It's completely normal to feel concerned, " + userName +
                    ". " + response + " Remember, being aware is the first step to staying safe!";
            }
            else if (sentiment == "frustrated")
            {
                return "I understand cybersecurity can be frustrating, " + userName +
                    ". Let me simplify: " + response;
            }
            else if (sentiment == "curious")
            {
                return "Great question, " + userName +
                    "! I'm glad you're curious about staying safe online. " + response;
            }
            else if (sentiment == "positive")
            {
                return "I'm happy to help, " + userName + "! " + response;
            }

            return response;
        }

        private string GetHelpMessage()
        {
            return "I can help you with:\n" +
                   "- Password security (ask about passwords)\n" +
                   "- Phishing scams (ask about phishing)\n" +
                   "- Privacy protection (ask about privacy)\n" +
                   "- Malware prevention (ask about malware)\n" +
                   "- General cybersecurity tips (ask for tips)\n\n" +
                   "What would you like to learn about?";
        }
    }
}