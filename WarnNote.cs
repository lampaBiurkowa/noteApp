﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class WarnNote : Note
    {
        private const int MAX_WARNING = 3;
        private const int MIN_WARNING = 1;
        private const int WARNING_LEVEL_SAVE_INDEX = 4;

        private const char WARNING_LEVEL_STRING_INDICATOR = '*';
        private const string TEXT_ICON = "/!\\";
        public const string ID = "WARNING";

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

        public WarnNote(string header, string content, int warningLevel) : base(header, content)
        {
            WarningLevel = warningLevel;
        }

        public WarnNote(string line) : base(line)
        {
        }

        public override void BuildFromLine(string line)
        {
            string[] components = line.Split(FileLoader.SEPARATOR);
            try
            {
                initStandardPropertiesFromComponents(components);
                initWarningLevel(components);
            }
            catch (Exception e)
            {
                handleReadingError(components.Length, WARNING_LEVEL_SAVE_INDEX + 1);
                Console.WriteLine(e.Message);
            }
        }

        private void initWarningLevel(string[] components)
        {
            WarningLevel = int.Parse(components[WARNING_LEVEL_SAVE_INDEX]);
        }

        public override void DisplayFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"{Header} ({getWarningLevelAsString()})");
            Console.WriteLine($"Added {DateTime.ToString(DATE_FORMAT)}");
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

        public override string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, DateTime.ToString(DATE_FORMAT), WarningLevel.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
