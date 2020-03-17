using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class WarnNote : INote
    {
        private const int MAX_WARNING = 3;
        private const int MIN_WARNING = 1;
        private const int WARNING_LEVEL_SAVE_INDEX = 4;

        private const char WARNING_LEVEL_STRING_INDICATOR = '*';
        private const string TEXT_ICON = "/!\\";
        public const string ID = "WARNING";

        private int warningLevel;

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int WarningLevel
        {
            get => warningLevel;
            set
            {
                if (value >= MIN_WARNING && value <= MAX_WARNING)
                    warningLevel = value;
                else
                    Logger.PrintError("Wrong warning set (must be from range <1, 3>)");
            }
        }

        public void DisplayFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"## {Header} ## ({getWarningLevelAsString()})");
            Console.WriteLine($"Added {CreationDate.ToString(Constants.DATE_FORMAT)}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{Content}");
        }

        public void DisplayShortInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} {Header} ({getWarningLevelAsString()})");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private string getWarningLevelAsString()
        {
            return new string(WARNING_LEVEL_STRING_INDICATOR, WarningLevel);
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT), WarningLevel.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
