using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class InfoNote : Note
    {
        private const string TEXT_ICON = "(i)";
        public const string ID = "INFO";

        public InfoNote()
        {
        }

        public InfoNote(string header, string content) : base(header, content)
        {
        }

        public InfoNote(string line) : base(line)
        {
        }

        public override void BuildFromLine(string line)
        {
            string[] components = line.Split(FileLoader.SEPARATOR);
            try
            {
                initStandardPropertiesFromComponents(components);
            }
            catch (Exception e)
            {
                handleReadingError(components.Length, DATE_TIME_SAVE_INDEX + 1);
                Console.WriteLine(e.Message);
            }
        }

        public override INote BuildFromInput(string header, string content)
        {
            return new InfoNote(header, content);
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
            Console.WriteLine(Header);
            Console.WriteLine(Content);
            Console.WriteLine(DateTime.ToString(DATE_FORMAT));
            List<string> dataToSave = new List<string>() { ID, Header, Content, DateTime.ToString(DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
