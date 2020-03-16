using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class RemindNote : Note
    {
        private const int REMIND_DATE_SAVE_INDEX = 4;

        private const string TEXT_ICON = "(@)";
        public const string ID = "REMIND";

        public DateTime RemindDate { get; private set; } = new DateTime();

        public RemindNote() : base()
        {
        }

        public RemindNote(string line) : base(line)
        {
        }

        public void Create(string header, string content, DateTime remindDate)
        {
            base.Create(header, content);
            RemindDate = remindDate;
        }

        public override void BuildFromLine(string line)
        {
            string[] components = line.Split(FileLoader.SEPARATOR);
            try
            {
                initStandardPropertiesFromComponents(components);
                initRemindDate(components);
            }
            catch (Exception e)
            {
                handleReadingError(components.Length, REMIND_DATE_SAVE_INDEX + 1);
                Console.WriteLine(e.Message);
            }
        }

        private void initRemindDate(string[] components)
        {
            RemindDate = DateTime.Parse(components[REMIND_DATE_SAVE_INDEX]);
        }

        public override void BuildFromInput(string header, string content)
        {
            Console.WriteLine($"Type remind date (format {DATE_FORMAT})");
            DateTime remindDate;
            DateTime.TryParse(Console.ReadLine(), out remindDate);
            Create(header, content, remindDate);
        }

        public override void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"## {Header} ## ({RemindDate.ToString(DATE_FORMAT)})");
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
