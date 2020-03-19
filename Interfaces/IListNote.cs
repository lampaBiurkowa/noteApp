using System.Collections.Generic;

namespace NoteApp
{
    public interface IListNote : INote
    {
        List<ListItem> Items { get; set; }
        int CheckedItemsCount { get; }

        List<string> GetAdditionalContent();
        string GetListItemContent(ListItem item);
        List<ListItem> GetSortedItems();
    }
}
