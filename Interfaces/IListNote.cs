using System.Collections.Generic;

namespace NoteApp
{
    public interface IListNote : INote
    {
        int HighlightedItemsCount { get; }

        bool TryAddToList(IListItem item);
        bool TryRemoveFromList(IListItem item);
    }
}
