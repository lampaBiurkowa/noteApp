﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class RemindNote : INote
    {
        private const int REMIND_DATE_SAVE_INDEX = 5;

        private const string TEXT_ICON = "(@)";
        public const string NAME_ID = "REMIND";

        public DateTime RemindDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int Id { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Cyan;

        public void BuildFromInput(string header, string content)
        {
            new NoteFromInputBuilder().BuildGenericData(this, header, content);
            Console.WriteLine($"Type remind date (format {Constants.DATE_FORMAT})");
            DateTime remindDate;
            DateTime.TryParse(Console.ReadLine(), out remindDate);
            RemindDate = remindDate;
        }

        public void LoadUniqueFeatures(string[] components)
        {
            DateTime remindDate;
            DateTime.TryParse(components[REMIND_DATE_SAVE_INDEX], out remindDate);
            RemindDate = remindDate;
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {NAME_ID}");
            result.Add($"## {Header} ## ({RemindDate.ToString(Constants.DATE_FORMAT)})");

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({RemindDate.ToString(Constants.DATE_FORMAT)})";
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { NAME_ID, Id.ToString(), Header, Content, CreationDate.ToString(Constants.DATE_FORMAT), RemindDate.ToString(Constants.DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
