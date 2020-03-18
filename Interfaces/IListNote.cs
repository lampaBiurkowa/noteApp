namespace NoteApp
{
    public interface IListNote : INote
    {
        bool TryAddToList(IListItem item);
        bool TryRemoveFromList(IListItem item);
    }
}
