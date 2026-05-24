using System;
using System.Media;
using System.IO;

namespace CybersecurityChatbotConsole
{
    public class AudioService
    {
        private string audioFilePath;

        public AudioService()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "audio";
            string fileName = "greeting.wav";
            audioFilePath = Path.Combine(baseDirectory, folderName, fileName);
        }

        public void PlayGreeting()
        {
            try
            {
                bool fileExists = File.Exists(audioFilePath);

                if (fileExists)
                {
                    using (SoundPlayer player = new SoundPlayer(audioFilePath))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    string errorMessage = "[Audio file not found. Voice greeting skipped.]";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                string fullErrorMessage = "[Audio playback error: " + ex.Message + "]";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(fullErrorMessage);
                Console.ResetColor();
            }
        }
    }
}