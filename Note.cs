using System;

namespace NoteApp
{
    public abstract class Note : INote
    {
        protected const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;

        public DateTime DateTime { get; set; } = new DateTime();
        public string Content { get; set; }
        public string Header { get; set; }

        public Note(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
        }

        public Note(string line)
        {
            BuildFromLine(line);
        }

        public abstract void BuildFromLine(string line);
        public abstract void DisplayFullInfo();
        public abstract void DisplayShortInfo();
        public abstract string GetSaveEntry();

        protected void initStandardPropertiesFromComponents(string[] components)
        {
            Header = components[HEADER_SAVE_INDEX];
            Content = components[CONTENT_SAVE_INDEX];
            DateTime = DateTime.Parse(components[DATE_TIME_SAVE_INDEX]);
        }

        protected void handleReadingError(int componentsLength, int maxIndex)
        {
            if (componentsLength < maxIndex)
                Logger.PrintError("Invalid file data in line {line}");
            else
                Logger.PrintError("Failed to parse line {line}");
        }
    }
}
