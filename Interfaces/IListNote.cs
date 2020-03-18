using System.Collections.Generic;

namespace NoteApp
{
    public interface IListNote : INote
    {
        List<IListItem> Items { get; set; }
        int HighlightedItemsCount { get; }
    }
}
