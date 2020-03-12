using System;

namespace NoteApp
{
    class RemindNote : Note
    {
        public override void Create(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
        }

        public override void DisplayFullInfo()
        {

        }

        public override void DisplayShortInfo()
        {

        }
    }
}
