using System;

namespace NoteApp
{
    abstract class Note
    {
        private const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
    }
}
