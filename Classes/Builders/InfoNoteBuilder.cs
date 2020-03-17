using System;

namespace NoteApp
{
    public class InfoNoteBuilder : INoteBuilder
    {
        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;

        public INote BuildFromInput(string header, string content)
        {
            return new InfoNote { Content = content, CreationDate = DateTime.Now, Header = header };
        }

        public INote GetLoadedNote(string[] components)
        {
            InfoNote note = new InfoNote();
            note.Header = components[HEADER_SAVE_INDEX];
            note.Content = components[CONTENT_SAVE_INDEX];

            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;

            return note;
        }

        public int GetComponentsRequiredCount()
        {
            return DATE_TIME_SAVE_INDEX - 1;
        }
    }
}
