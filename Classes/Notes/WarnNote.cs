﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class WarnNote : INote
    {
        private const int WARNING_LEVEL_SAVE_INDEX = 5;

        private const int MAX_WARNING = 3;
        private const int MIN_WARNING = 1;

        private const char WARNING_LEVEL_STRING_INDICATOR = '*';
        private const string TEXT_ICON = "/!\\";
        public const string NAME_ID = "WARNING";

        private int warningLevel;

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int Id { get; set; }
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
            new NoteFromInputBuilder().BuildGenericData(this, header, content);
            Console.WriteLine("Type warning level (number from 1 to 3)");
            int warningLevel;
            int.TryParse(Console.ReadLine(), out warningLevel);
            WarningLevel = warningLevel;
        }

        public void LoadUniqueFeatures(string[] components)
        {
            int warningLevel;
            int.TryParse(components[WARNING_LEVEL_SAVE_INDEX], out warningLevel);
            WarningLevel = warningLevel;
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {NAME_ID}");
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
            List<string> dataToSave = new List<string>() { NAME_ID, Id.ToString(), Header, Content, CreationDate.ToString(Constants.DATE_FORMAT), WarningLevel.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
