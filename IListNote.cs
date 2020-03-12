namespace NoteApp
{
    interface IListNote
    {
        bool TryAddToList(ListItem item);
        void DisplayItem(ListItem item);
        bool TryRemoveFromList(ListItem item);
    }
}
