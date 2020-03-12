using System;

namespace NoteApp
{
    class WarnNote : Note
    {
        private const int MAX_WARNING = 3;
        private const int MIN_WARNING = 1;
        private const int DEFAULT_WARNING = MIN_WARNING;
        private const char WARNING_LEVEL_STRING_INDICATOR = '*';
        private const string TEXT_ICON = "/!\\";

        private int warningLevel;

        public int WarningLevel
        {
            get => warningLevel;
            set
            {
                if (value >= MIN_WARNING && value <= MAX_WARNING)
                    warningLevel = WarningLevel;
                else
                    Logger.PrintError("Wrong warning set (must be from range <1, 3>)");
            }
        }

        public override void Create(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
            warningLevel = DEFAULT_WARNING;
        }

        public override void DisplayFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} WARNING:");
            Console.WriteLine($"{Header} ({getWarningLevelAsString()})");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Content}");
        }

        public override void DisplayShortInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} {Header} ({getWarningLevelAsString()})");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private string getWarningLevelAsString()
        {
            return new string(WARNING_LEVEL_STRING_INDICATOR, WarningLevel);
        }
    }
}
