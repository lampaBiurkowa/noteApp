using System;

namespace NoteApp
{
    class WarnNoteBuilder : INoteBuilder
    {
        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;
        protected const int WARNING_LEVEL_SAVE_INDEX = 4;

        public INote BuildFromInput(string header, string content)
        {
            WarnNote note = new WarnNote { Content = content, CreationDate = DateTime.Now, Header = header };

            Console.WriteLine("Type warning level (number from 1 to 3)");
            int warningLevel;
            int.TryParse(Console.ReadLine(), out warningLevel);
            note.WarningLevel = warningLevel;

            return note;
        }

        public INote GetLoadedNote(string[] components)
        {
            WarnNote note = new WarnNote();
            note.Header = components[HEADER_SAVE_INDEX];
            note.Content = components[CONTENT_SAVE_INDEX];

            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;

            int warningLevel;
            int.TryParse(components[WARNING_LEVEL_SAVE_INDEX], out warningLevel);
            note.WarningLevel = warningLevel;
            return note;
        }

        public int GetComponentsRequiredCount()
        {
            return WARNING_LEVEL_SAVE_INDEX - 1;
        }
    }
}
