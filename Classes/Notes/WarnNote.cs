using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class WarnNote : INote
    {
        private const int MAX_WARNING = 3;
        private const int MIN_WARNING = 1;

        private const char WARNING_LEVEL_STRING_INDICATOR = '*';
        private const string TEXT_ICON = "/!\\";
        public const string ID = "WARNING";

        private int warningLevel;

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Red;

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

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;

            Console.WriteLine("Type warning level (number from 1 to 3)");
            int warningLevel;
            int.TryParse(Console.ReadLine(), out warningLevel);
            WarningLevel = warningLevel;
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {ID}");
            result.Add($"## {Header} ## ({getWarningLevelAsString()})");

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({getWarningLevelAsString()})";
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
