namespace NoteApp
{
    public class ItemsModifier
    {
        public bool TryAddToList(IListNote note, ListItem item)
        {
            if (note.Items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Checked}) already exists");
                return false;
            }

            note.Items.Add(item);
            return true;
        }

        public bool TryRemoveFromList(IListNote note, ListItem item)
        {
            if (!note.Items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Checked}) does not exist");
                return false;
            }

            note.Items.Remove(item);
            return true;
        }
    }
}
