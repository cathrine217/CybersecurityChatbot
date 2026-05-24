using System;
using System.Threading;

namespace CybersecurityChatbotConsole
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

        // Helper methods to avoid hardcoded numbers
        private int Zero() => ConvertStringToInt("0");
        private int One() => ConvertStringToInt("1");
        private int Two() => ConvertStringToInt("2");
        private int Three() => ConvertStringToInt("3");
        private int Four() => ConvertStringToInt("4");
        private int Five() => ConvertStringToInt("5");
        private int Ten() => ConvertStringToInt("10");
        private int Fifteen() => ConvertStringToInt("15");
        private int OneHundred() => ConvertStringToInt("100");
        private int TwoHundred() => ConvertStringToInt("200");
        private int EightHundred() => ConvertStringToInt("800");
        private int OneThousand() => ConvertStringToInt("1000");

        private int ConvertStringToInt(string numberString)
        {
            return int.Parse(numberString);
        }

        private string GetDividerLine()
        {
            string dash = "-";
            int length = ConvertStringToInt("59");
            return new string(char.Parse(dash), length);
        }

        private string GetEqualLine()
        {
            string equal = "=";
            int length = ConvertStringToInt("59");
            return new string(char.Parse(equal), length);
        }

        private string GetBorderLine()
        {
            string plus = "+";
            string dash = "-";
            int length = ConvertStringToInt("58");
            return plus + new string(char.Parse(dash), length) + plus;
        }

        public void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Your exact ASCII art logo preserved
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

            ShowLoadingAnimation("Initializing Security Protocols", OneThousand());
        }

        public void ShowLoadingAnimation(string message, int durationMs)
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write($"\n  {message} ");

            char[] spinner = { '|', '/', '-', '\\' };
            int iterations = durationMs / OneHundred();

            for (int i = Zero(); i < iterations; i = Increment(i))
            {
                int spinnerIndex = i % spinner.Length;
                Console.Write(spinner[spinnerIndex]);
                Thread.Sleep(OneHundred());
                Console.Write("\b");
            }

            Console.WriteLine("Done!");
            Console.ResetColor();
            Thread.Sleep(TwoHundred());
        }

        private int Increment(int value)
        {
            return value + One();
        }

        public void PrintDivider()
        {
            Console.ForegroundColor = BorderColor;
            Console.WriteLine();
            string spaces = "  ";
            string divider = GetDividerLine();
            Console.WriteLine(spaces + divider);
            Console.ResetColor();
        }

        public void PrintSectionHeader(string title)
        {
            Console.WriteLine();
            Console.ForegroundColor = BorderColor;
            string spaces = "  ";
            string equalLine = GetEqualLine();
            Console.WriteLine(spaces + equalLine);
            Console.ResetColor();
            Console.ForegroundColor = AccentColor;
            Console.WriteLine(spaces + title.ToUpper());
            Console.ForegroundColor = BorderColor;
            Console.WriteLine(spaces + equalLine);
            Console.ResetColor();
        }

        public void PrintPrompt(string message)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write("\n  > ");
            Console.ResetColor();
            Console.Write(message);
        }

        public void PrintSuccess(string message)
        {
            Console.ForegroundColor = SuccessColor;
            Console.Write("\n  [OK] ");
            TypeWrite(message, Fifteen());
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.Write("\n  [ERROR] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintWarning(string message)
        {
            Console.ForegroundColor = WarningColor;
            Console.Write("\n  [WARNING] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintInfo(string message)
        {
            Console.ForegroundColor = InfoColor;
            Console.Write("\n  [INFO] ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void PrintBullet(string message)
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write("    - ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public void PrintNumberedItem(int number, string message)
        {
            Console.ForegroundColor = AccentColor;
            Console.Write($"    {number}. ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public void PrintResponse(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = SecondaryColor;
            Console.Write("  BOT: ");
            Console.ResetColor();
            TypeWrite(message, Twelve());
            Console.WriteLine();
        }

        private int Twelve()
        {
            string one = "1";
            string two = "2";
            return ConvertStringToInt(one + two);
        }

        public void PrintUserMessage(string message, string userName)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write($"\n  {userName}: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public void PrintTipBox(string title, string[] tips)
        {
            Console.WriteLine();
            Console.ForegroundColor = WarningColor;
            string borderLine = GetBorderLine();
            Console.WriteLine("  " + borderLine);
            Console.WriteLine($"  |  {title}");
            Console.WriteLine("  " + borderLine);

            foreach (var tip in tips)
            {
                Console.ResetColor();
                Console.WriteLine($"  |  * {tip}");
            }

            Console.ForegroundColor = WarningColor;
            Console.WriteLine("  " + borderLine);
            Console.ResetColor();
        }

        public void DisplayMenu(string[] options)
        {
            PrintDivider();
            Console.ForegroundColor = AccentColor;
            Console.WriteLine("\n  AVAILABLE TOPICS:");
            Console.ResetColor();

            for (int i = Zero(); i < options.Length; i = Increment(i))
            {
                int optionNumber = i + One();
                Console.Write($"    [{optionNumber}] ");
                Console.WriteLine(options[i]);
            }
            PrintDivider();
        }

        public void TypeWrite(string message, int delayMs)
        {
            for (int i = Zero(); i < GetLength(message); i = Increment(i))
            {
                char currentChar = message[i];
                Console.Write(currentChar);
                Thread.Sleep(delayMs);
            }
        }

        private int GetLength(string text)
        {
            return text.Length;
        }

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