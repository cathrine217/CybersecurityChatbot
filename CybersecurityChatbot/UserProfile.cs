using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CybersecurityChatbotGUI.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string FavoriteTopic { get; set; }
        public List<string> TopicsDiscussed { get; set; } = new List<string>();
        public Dictionary<string, int> TopicInterest { get; set; } = new Dictionary<string, int>();
        public int InteractionCount { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime FirstSeen { get; set; }

        public UserProfile()
        {
            FirstSeen = DateTime.Now;
            LastActive = DateTime.Now;
        }

        public void SaveProfile()
        {
            try
            {
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "CybersecurityChatbot");

                if (!Directory.Exists(appDataPath))
                    Directory.CreateDirectory(appDataPath);

                string filePath = Path.Combine(appDataPath, "user_profile.json");
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving profile: {ex.Message}");
            }
        }

        public static UserProfile LoadProfile()
        {
            try
            {
                string appDataPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "CybersecurityChatbot");

                string filePath = Path.Combine(appDataPath, "user_profile.json");

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<UserProfile>(json) ?? new UserProfile();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading profile: {ex.Message}");
            }
            return new UserProfile();
        }

        public void UpdateInterest(string topic)
        {
            topic = topic.ToLower();

            if (TopicInterest.ContainsKey(topic))
                TopicInterest[topic]++;
            else
                TopicInterest[topic] = 1;

            if (TopicInterest.Count > 0)
            {
                string mostInterested = null;
                int highestCount = 0;
                foreach (var t in TopicInterest)
                {
                    if (t.Value > highestCount)
                    {
                        highestCount = t.Value;
                        mostInterested = t.Key;
                    }
                }

                if (mostInterested != null)
                {
                    FavoriteTopic = char.ToUpper(mostInterested[0]) + mostInterested.Substring(1);
                }
            }

            if (!TopicsDiscussed.Contains(topic))
                TopicsDiscussed.Add(topic);

            InteractionCount++;
            LastActive = DateTime.Now;
            SaveProfile();
        }

        public string GetPersonalizedGreeting()
        {
            string greeting = "";

            if (!string.IsNullOrEmpty(Name))
            {
                greeting = $"Welcome back, {Name}. ";

                if (InteractionCount > 5)
                {
                    greeting += $"This is our {InteractionCount}th conversation. ";
                }

                if (!string.IsNullOrEmpty(FavoriteTopic))
                {
                    greeting += $"I remember you are interested in {FavoriteTopic}. ";
                }
            }

            return greeting;
        }

        public string RecallInterest()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
            {
                return $"Since you are interested in {FavoriteTopic}, here is a specialized tip: ";
            }
            return "";
        }
    }
}