using System;
using System.Media;
using System.Threading;
using System.IO;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting on startup
            PlayVoiceGreeting();

            // Small delay to let audio start
            Thread.Sleep(500);

            // Create and start the chatbot
            Chatbot bot = new Chatbot();
            bot.Start();
        }

        static void PlayVoiceGreeting()
        {
            try
            {
                // Build the correct path to the WAV file in the Audio folder
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", "greeting.wav");

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("[Audio file not found: " + audioPath + "]");
                }
            }
            catch (Exception ex)
            {
                // Fallback if audio fails
                Console.WriteLine("[Audio greeting unavailable: " + ex.Message + "]");
            }
        }
    }
}