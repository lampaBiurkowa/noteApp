using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class InfoNote : INote
    {
        private const string TEXT_ICON = "(i)";
        public const string ID = "INFO";

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Blue;

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;
        }

        public List<string> GetFullInfo()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {ID}");
            result.Add($"## {Header} ##");
            result.Add($"Added {CreationDate.ToString(Constants.DATE_FORMAT)}");
            result.Add(Content);

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header}";
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
