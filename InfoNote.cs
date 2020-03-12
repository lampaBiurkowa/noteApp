using System;

namespace NoteApp
{
    class InfoNote : Note
    {
        private const string TEXT_ICON = "(i)";

        public override void DisplayFullInfo()
        {
            Console.WriteLine($"{TEXT_ICON} INFO:");
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Content}");
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header}");
        }
    }
}
