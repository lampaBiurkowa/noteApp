using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class ListNote : IListNote
    {
        public const string NAME_ID = "LIST";
        private const string TEXT_ICON = "===";

        public List<ListItem> Items { get; set; } = new List<ListItem>();
        public int CheckedItemsCount => Items.Count(element => element.Checked);

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int Id { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Yellow;

        public void BuildFromInput(string header, string content)
        {
            NoteFromInputBuilder builder = new NoteFromInputBuilder();
            builder.BuildGenericData(this, header, content);
            builder.BuildListItems(this);
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {NAME_ID}");
            result.Add($"## {Header} ## ({Items.Count} items, {CheckedItemsCount} highlighted)");

            return result;
        }

        public List<string> GetAdditionalContent()
        {
            List<string> result = new List<string>();
            foreach (var item in Items)
                result.Add(GetListItemContent(item));

            return result;
        }

        public string GetListItemContent(ListItem item)
        {
            return item.Checked ? $"- ** {item.Content} **" : $"- {item.Content}";
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({Items.Count} items, {CheckedItemsCount} highlighted)";
        }

        public List<ListItem> GetSortedItems()
        {
            return Items.OrderBy(e => e.Content).ToList();
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { NAME_ID, Id.ToString(), Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            foreach (var item in Items)
                dataToSave.Add(getItemSaveFragment(item));

            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }

        private string getItemSaveFragment(ListItem item)
        {
            List<string> dataToSave = new List<string>() { item.Content, item.Checked.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
