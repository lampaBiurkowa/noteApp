using System;

namespace NoteApp
{
    class ListItemBuilder
    {
        public void InitListItemsFromComponents(string[] components, int lastStandardIndex, IListNote source)
        {
            for (int i = lastStandardIndex + 1; i < components.Length; i += ListItem.SAVE_COMPONENTS_COUNT)
                try
                {
                    initSingleListItemFromComponent(components, source);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
        }

        private void initSingleListItemFromComponent(string[] components, IListNote note)
        {
            string content = components[0];
            bool highlighted = bool.Parse(components[1]);
            ItemsModifier modifier = new ItemsModifier();
            modifier.TryAddToList(note, new ListItem(highlighted, content));
        }
    }
}
