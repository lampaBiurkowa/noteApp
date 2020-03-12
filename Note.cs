using System;

namespace NoteApp
{
    abstract class Note : INote
    {
        protected const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }

        public Note(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
        }

        public abstract void DisplayFullInfo();
        public abstract void DisplayShortInfo();
    }
}
