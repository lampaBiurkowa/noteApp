using System;

namespace NoteApp
{
    public class CheckListNoteBuilder : INoteBuilder
    {
        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;

        public INote GetLoadedNote(string[] components)
        {
            CheckListNote note = new CheckListNote();
            note.Header = components[HEADER_SAVE_INDEX];
            note.Content = components[CONTENT_SAVE_INDEX];

            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;

            new ListItemBuilder().InitListItemsFromComponents(components, DATE_TIME_SAVE_INDEX, note);
            return note;
        }

        public int GetComponentsRequiredCount()
        {
            return DATE_TIME_SAVE_INDEX - 1;
        }
    }
}
