using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class InfoNote : Note
    {
        private const string TEXT_ICON = "(i)";
        private const string ID = "INFO";

        public InfoNote(string header, string content) : base(header, content)
        {
        }

        public override void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"Added {DateTime.ToString(DATE_FORMAT)}");
            Console.WriteLine($"{Content}");
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header}");
        }

        public override string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, DateTime.ToString(DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
