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

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;
        }

        public void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"## {Header} ##");
            Console.WriteLine($"Added {CreationDate.ToString(Constants.DATE_FORMAT)}");
            Console.WriteLine($"{Content}");
        }

        public void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header}");
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
