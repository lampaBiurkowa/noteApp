using System;

namespace NoteApp
{
    abstract class Note : INote
    {
        private const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }

        public abstract void Create(string header, string content);
        public abstract void DisplayFullInfo();
        public abstract void DisplayShortInfo();
    }
}
