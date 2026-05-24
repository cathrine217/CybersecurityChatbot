using System;

namespace CybersecurityChatbotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot - Stay Safe Online";

            string widthString = "90";
            string heightString = "40";
            Console.WindowWidth = int.Parse(widthString);
            Console.WindowHeight = int.Parse(heightString);

            AudioService audio = new AudioService();
            audio.PlayGreeting();

            Chatbot chatbot = new Chatbot();
            chatbot.Start();
        }
    }
}