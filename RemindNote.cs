using System;

namespace NoteApp
{
    class RemindNote : Note
    {
        private const string TEXT_ICON = "(@)";

        public DateTime RemindDate { get; private set; }

        public RemindNote(string header, string content, DateTime remindDate) : base(header, content)
        {
            RemindDate = remindDate;
        }

        public override void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} REMEMBER:");
            Console.WriteLine($"{Header} ({RemindDate.ToString(DATE_FORMAT)})");
            Console.WriteLine($"{Content}");
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header} ({RemindDate.ToString(DATE_FORMAT)})");
        }
    }
}
