using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class UIHelper
    {
        // Console colors
        private ConsoleColor PrimaryColor = ConsoleColor.Cyan;
        private ConsoleColor SecondaryColor = ConsoleColor.DarkCyan;
        private ConsoleColor SuccessColor = ConsoleColor.Green;
        private ConsoleColor ErrorColor = ConsoleColor.Red;
        private ConsoleColor WarningColor = ConsoleColor.Yellow;
        private ConsoleColor InfoColor = ConsoleColor.White;
        private ConsoleColor AccentColor = ConsoleColor.Magenta;
        private ConsoleColor BorderColor = ConsoleColor.Blue;

        /// <summary>
        /// Displays the ASCII art logo
        /// </summary>
        public void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            string asciiArt = @"
      .--.      .--.      .--.      .--.      .--.      .--.
    : (\ "" .-.  .-. "" .-.  .-. "" .-.  .-. "" .-.  .-. "" .-) ;
     :   '-'   '-'   '-'   '-'   '-'   '-'   '-'   '-'   '-'   :
      \      /      \      /      \      /      \      /      /
       `.__.'        `.__.'        `.__.'        `.__.'        `.__.'
    
        ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗ ██████╗
       ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝
       ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗██║     
       ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██║     
       ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║╚██████╗
        ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝
         
                     ███████╗ █████╗ ███████╗███████╗████████╗██╗   ██╗
                     ██╔════╝██╔══██╗██╔════╝██╔════╝╚══██╔══╝╚██╗ ██╔╝
                     ███████╗███████║█████╗  █████╗     ██║    ╚████╔╝ 
                     ╚════██║██╔══██║██╔══╝  ██╔══╝     ██║     ╚██╔╝  
                     ███████║██║  ██║██║     ███████╗   ██║      ██║   
                     ╚══════╝╚═╝  ╚═╝╚═╝     ╚══════╝   ╚═╝      ╚═╝   
            ";

            Console.WriteLine(asciiArt);
            Console.ResetColor();

            ShowLoadingAnimation("Initializing Security Protocols", 1000);
        }

        /// <summary>
        /// Displays a loading animation
        /// </summary>
        public void ShowLoadingAnimation(string message, int durationMs)
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write($"\n  {message} ");

            char[] spinner = { '|', '/', '-', '\\' };
            int iterations = durationMs / 100;

            for (int i = 0; i < iterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
            }

            Console.WriteLine("Done!");
            Console.ResetColor();
            Thread.Sleep(200);
        }

        /// <summary>
        /// Prints a simple divider line
        /// </summary>
        public void PrintDivider()
        {
            Console.ForegroundColor = BorderColor;
            Console.WriteLine();
            Console.WriteLine("  ------------------------------------------------------------");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a section header with title
        /// </summary>
        public void PrintSectionHeader(string title)
        {
            Console.WriteLine();
            Console.ForegroundColor = BorderColor;
            Console.WriteLine("  ============================================================");
            Console.ResetColor();
            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"  {title.ToUpper()}");
            Console.ForegroundColor = BorderColor;
            Console.WriteLine("  ============================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a prompt message
        /// </summary>
        public void PrintPrompt(string message)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write("\n  > ");
            Console.ResetColor();
            Console.Write(message);
        }

        /// <summary>
        /// Prints a success message
        /// </summary>
        public void PrintSuccess(string message)
        {
            Console.ForegroundColor = SuccessColor;
            Console.Write("\n  [OK] ");
            TypeWrite(message, 15);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Prints an error message
        /// </summary>
        public void PrintError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.Write("\n  [ERROR] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a warning message
        /// </summary>
        public void PrintWarning(string message)
        {
            Console.ForegroundColor = WarningColor;
            Console.Write("\n  [WARNING] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints an info message
        /// </summary>
        public void PrintInfo(string message)
        {
            Console.ForegroundColor = InfoColor;
            Console.Write("\n  [INFO] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a bullet point item
        /// </summary>
        public void PrintBullet(string message)
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write("    - ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints a numbered item
        /// </summary>
        public void PrintNumberedItem(int number, string message)
        {
            Console.ForegroundColor = AccentColor;
            Console.Write($"    {number}. ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints the chatbot response with typing effect
        /// </summary>
        public void PrintResponse(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = SecondaryColor;
            Console.Write("  BOT: ");
            Console.ResetColor();
            TypeWrite(message, 12);
            Console.WriteLine();
        }

        /// <summary>
        /// Prints user message
        /// </summary>
        public void PrintUserMessage(string message, string userName)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write($"\n  {userName}: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints a tip box
        /// </summary>
        public void PrintTipBox(string title, string[] tips)
        {
            Console.WriteLine();
            Console.ForegroundColor = WarningColor;
            Console.WriteLine("  +----------------------------------------------------------+");
            Console.WriteLine($"  |  {title}");
            Console.WriteLine("  +----------------------------------------------------------+");

            foreach (var tip in tips)
            {
                Console.ResetColor();
                Console.WriteLine($"  |  * {tip}");
            }

            Console.ForegroundColor = WarningColor;
            Console.WriteLine("  +----------------------------------------------------------+");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the main menu options
        /// </summary>
        public void DisplayMenu(string[] options)
        {
            PrintDivider();
            Console.ForegroundColor = AccentColor;
            Console.WriteLine("\n  AVAILABLE TOPICS:");
            Console.ResetColor();

            for (int i = 0; i < options.Length; i++)
            {
                Console.Write($"    [{i + 1}] ");
                Console.WriteLine(options[i]);
            }
            PrintDivider();
        }

        /// <summary>
        /// Typing effect - simulates typing character by character
        /// </summary>
        public void TypeWrite(string message, int delayMs)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
        }

        /// <summary>
        /// Prints a welcome banner for the user
        /// </summary>
        public void PrintWelcomeBanner(string userName)
        {
            PrintDivider();
            Console.ForegroundColor = SuccessColor;
            Console.WriteLine();
            Console.WriteLine($"  Welcome, {userName}!");
            Console.ResetColor();
            Console.WriteLine("  Your cybersecurity assistant is ready.");
            PrintDivider();
        }

        /// <summary>
        /// Prints goodbye message
        /// </summary>
        public void PrintGoodbye(string userName)
        {
            Console.WriteLine();
            PrintDivider();
            Console.ForegroundColor = PrimaryColor;
            Console.WriteLine();
            Console.WriteLine($"  Goodbye, {userName}!");
            Console.WriteLine("  Stay safe online!");
            Console.WriteLine();
            Console.ForegroundColor = SecondaryColor;
            Console.WriteLine("  PROG6221POE - 2026");
            PrintDivider();
            Console.ResetColor();
        }
    }
}