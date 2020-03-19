using System.Collections.Generic;

namespace NoteApp
{
    public interface IListNote : INote
    {
        List<ListItem> Items { get; set; }
        int HighlightedItemsCount { get; }

        string GetListItemContent(ListItem item);
    }
}
