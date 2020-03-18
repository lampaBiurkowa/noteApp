using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class RemindNote : INote
    {
        private const string TEXT_ICON = "(@)";
        public const string ID = "REMIND";

        public DateTime RemindDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Cyan;

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;

            Console.WriteLine($"Type remind date (format {Constants.DATE_FORMAT})");
            DateTime remindDate;
            DateTime.TryParse(Console.ReadLine(), out remindDate);
            RemindDate = remindDate;
        }

        public List<string> GetFullInfo()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {ID}");
            result.Add($"## {Header} ## ({RemindDate.ToString(Constants.DATE_FORMAT)})");
            result.Add($"Added {CreationDate.ToString(Constants.DATE_FORMAT)}");
            result.Add(Content);

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({RemindDate.ToString(Constants.DATE_FORMAT)})";
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT), RemindDate.ToString(Constants.DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
