using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class RemindNote : Note
    {
        private const string TEXT_ICON = "(@)";
        private const string ID = "REMIND";

        public DateTime RemindDate { get; private set; }

        public RemindNote(string header, string content, DateTime remindDate) : base(header, content)
        {
            RemindDate = remindDate;
        }

        public override void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"{Header} ({RemindDate.ToString(DATE_FORMAT)})");
            Console.WriteLine($"Added {DateTime.ToString(DATE_FORMAT)}");
            Console.WriteLine($"{Content}");
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header} ({RemindDate.ToString(DATE_FORMAT)})");
        }

        public override string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, DateTime.ToString(DATE_FORMAT), RemindDate.ToString(DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
