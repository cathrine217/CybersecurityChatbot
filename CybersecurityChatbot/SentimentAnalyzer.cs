using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbotGUI.Services
{
    public class Sentiment
    {
        public string Type { get; set; }
        public double Confidence { get; set; }
        public string SuggestedResponse { get; set; }
    }

    public class SentimentAnalyzer
    {
        private Dictionary<string, List<string>> sentimentKeywords;
        private Dictionary<string, string> empatheticResponses;

        public SentimentAnalyzer()
        {
            InitializeKeywords();
            InitializeResponses();
        }

        private void InitializeKeywords()
        {
            sentimentKeywords = new Dictionary<string, List<string>>
            {
                ["worried"] = new List<string> {
                    "worried", "scared", "afraid", "concerned", "nervous", "anxious",
                    "fear", "unsafe", "vulnerable", "targeted", "threatened"
                },
                ["curious"] = new List<string> {
                    "curious", "interested", "wonder", "tell me", "explain", "learn",
                    "understand", "what is", "why", "how does"
                },
                ["frustrated"] = new List<string> {
                    "frustrated", "annoyed", "confused", "difficult", "hard", "complicated"
                },
                ["happy"] = new List<string> {
                    "happy", "great", "good", "thanks", "thank you", "awesome", "helpful"
                }
            };
        }

        private void InitializeResponses()
        {
            empatheticResponses = new Dictionary<string, string>
            {
                ["worried"] = "It is completely understandable to feel worried about online security. " +
                              "Let me share some practical steps to help you feel more secure.",

                ["curious"] = "That is excellent that you are curious about cybersecurity. " +
                              "Staying informed is the best defense against cyber threats.",

                ["frustrated"] = "I understand this can be frustrating. " +
                                 "Let us break it down into simple, manageable steps.",

                ["happy"] = "I am glad to hear that. " +
                            "Let me share some additional tips.",

                ["neutral"] = "That is a great question about cybersecurity. Let me help."
            };
        }

        public Sentiment Analyze(string userInput)
        {
            string inputLower = userInput.ToLower();
            var detectedSentiments = new Dictionary<string, int>();

            foreach (var sentiment in sentimentKeywords)
            {
                int matchCount = sentiment.Value.Count(keyword =>
                    inputLower.Contains(keyword));

                if (matchCount > 0)
                {
                    detectedSentiments[sentiment.Key] = matchCount;
                }
            }

            if (detectedSentiments.Count == 0)
            {
                return new Sentiment
                {
                    Type = "neutral",
                    Confidence = 0.5,
                    SuggestedResponse = empatheticResponses["neutral"]
                };
            }

            string primarySentiment = detectedSentiments.OrderByDescending(x => x.Value)
                                        .First().Key;

            return new Sentiment
            {
                Type = primarySentiment,
                Confidence = 0.8,
                SuggestedResponse = empatheticResponses[primarySentiment]
            };
        }

        public string GetSentimentText(string sentimentType)
        {
            return sentimentType switch
            {
                "worried" => "Worried",
                "curious" => "Curious",
                "frustrated" => "Frustrated",
                "happy" => "Happy",
                _ => "Neutral"
            };
        }
    }
}