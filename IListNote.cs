namespace NoteApp
{
    interface IListNote
    {
        void AddToList(ListItem item);
        void DisplayItem(ListItem item);
        void RemoveFromList(ListItem item);
    }
}
