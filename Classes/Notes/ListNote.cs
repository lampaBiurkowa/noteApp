
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class ListNote : IListNote
    {
        public const string ID = "LIST";
        private const string TEXT_ICON = "=";

        public List<ListItem> Items { get; set; } = new List<ListItem>();
        public int HighlightedItemsCount => Items.Count(element => element.Checked);

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Yellow;

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;
            getItems();
        }

        private void getItems()
        {
            Console.WriteLine("Type count of items in list:");
            int count;
            int.TryParse(Console.ReadLine(), out count);
            for (int i = 0; i < count; i++)
                handleAddingItem();
        }

        private void handleAddingItem()
        {
            Console.WriteLine("Type item content");
            string content = Console.ReadLine();
            Console.WriteLine("Is checked? (Y/n)");
            bool isChecked = Console.ReadLine() == "n" ? false : true;
            ItemsModifier modifier = new ItemsModifier();
            modifier.TryAddToList(this, new ListItem(isChecked, content)); // hmm
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {ID}");
            result.Add($"## {Header} ## ({Items.Count} items, {HighlightedItemsCount} highlighted)");

            return result;
        }

        public List<string> GetAdditionalContent()
        {
            List<string> result = new List<string>();
            foreach (var item in Items)
                result.Add(item.Content);

            return result;
        }

        public string GetListItemContent(ListItem item)
        {
            return item.Checked ? $"- ** {item.Content} **" : $"- {item.Content}";
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({Items.Count} items, {HighlightedItemsCount} highlighted)";
        }

        public List<ListItem> GetSortedItems()
        {
            return Items.OrderBy(e => e.Content).ToList();
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
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
