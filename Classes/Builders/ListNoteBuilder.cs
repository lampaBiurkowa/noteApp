using System;

namespace NoteApp
{
    public class ListNoteBuilder : INoteBuilder
    {
        protected const int HEADER_SAVE_INDEX = 1;
        protected const int CONTENT_SAVE_INDEX = 2;
        protected const int DATE_TIME_SAVE_INDEX = 3;

        public INote GetLoadedNote(string[] components)
        {
            ListNote note = new ListNote();
            note.Header = components[HEADER_SAVE_INDEX];
            note.Content = components[CONTENT_SAVE_INDEX];

            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;

            note = initListItemsFromComponents(components, note);
            return note;
        }

        private ListNote initListItemsFromComponents(string[] components, ListNote source)
        {
            for (int i = DATE_TIME_SAVE_INDEX + 1; i < components.Length; i += ListItem.SAVE_COMPONENTS_COUNT)
                try
                {
                    source = initSingleListItemFromComponent(components, source);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            return source;
        }

        private ListNote initSingleListItemFromComponent(string[] components, ListNote note)
        {
            string content = components[0];
            bool highlighted = bool.Parse(components[1]);
            ItemsModifier modifier = new ItemsModifier();
            modifier.TryAddToList(note, new ListItem(highlighted, content));
            return note;
        }

        public int GetComponentsRequiredCount()
        {
            return DATE_TIME_SAVE_INDEX - 1;
        }
    }
}
