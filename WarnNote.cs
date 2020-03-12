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

        public int WarningLevel { get; set; }

        public override void Create(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
            WarningLevel = DEFAULT_WARNING;
        }

        public override void DisplayFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} WARNING:");
            Console.WriteLine($"{Header}");
            Console.Beep();
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
