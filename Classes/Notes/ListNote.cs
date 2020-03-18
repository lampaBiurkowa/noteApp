using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class ListNote : IListNote
    {
        public const string ID = "LIST";
        private const string TEXT_ICON = "=";

        public List<IListItem> Items { get; set; }
        public int HighlightedItemsCount { get; private set; } = 0;

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Red;

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;
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
                result.Add(item.GetDisplayableContent());

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({Items.Count} items, {HighlightedItemsCount} highlighted)";
        }

        public bool TryAddToList(IListItem item)
        {
            if (Items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Checked}) already exists");
                return false;
            }

            Items.Add(item);
            if (item.Checked)
                HighlightedItemsCount++;

            return true;
        }

        public bool TryRemoveFromList(IListItem item)
        {
            if (!Items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Checked}) does not exist");
                return false;
            }

            Items.Remove(item);
            if (item.Checked)
                HighlightedItemsCount--;

            return true;
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            foreach (var item in Items)
                dataToSave.Add(getItemSaveFragment(item));

            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }

        private string getItemSaveFragment(IListItem item)
        {
            List<string> dataToSave = new List<string>() { item.Content, item.Checked.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
