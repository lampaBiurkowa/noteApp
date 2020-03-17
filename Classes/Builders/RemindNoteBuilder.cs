using System;

namespace NoteApp
{
    public class RemindNoteBuilder : INoteBuilder
    {
        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;
        protected const int REMIND_DATE_SAVE_INDEX = 4;

        public INote BuildFromInput(string header, string content)
        {
            RemindNote note = new RemindNote { Content = content, CreationDate = DateTime.Now, Header = header };

            Console.WriteLine($"Type remind date (format {Constants.DATE_FORMAT})");
            DateTime remindDate;
            DateTime.TryParse(Console.ReadLine(), out remindDate);
            note.RemindDate = remindDate;

            return note;
        }

        public INote GetLoadedNote(string[] components)
        {
            RemindNote note = new RemindNote();
            note.Header = components[HEADER_SAVE_INDEX];
            note.Content = components[CONTENT_SAVE_INDEX];

            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;

            DateTime remindDate;
            DateTime.TryParse(components[REMIND_DATE_SAVE_INDEX], out remindDate);
            note.RemindDate = remindDate;
            return note;
        }

        public int GetComponentsRequiredCount()
        {
            return REMIND_DATE_SAVE_INDEX - 1;
        }
    }
}
