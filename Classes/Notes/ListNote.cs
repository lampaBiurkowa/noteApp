using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class ListNote : IListNote
    {
        public const string ID = "LIST";
        private const string TEXT_ICON = "=";

        private List<StandardListItem> items = new List<StandardListItem>();
        private int highlightedItemsCount = 0;

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Red;

        private int getHighlightedItemsCount()
        {
            int result = 0;
            foreach (var item in items)
                if (item.Highlighted)
                    result++;

            return result;
        }

        public void BuildFromInput(string header, string content)
        {
            Content = content;
            CreationDate = DateTime.Now;
            Header = header;
        }

        public List<string> GetFullInfo()
        {
            return (List<string>)getMainInfo().Concat(getItemsInfo());
        }

        private List<string> getMainInfo()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {ID}");
            result.Add($"## {Header} ## ({items.Count} items, {highlightedItemsCount} highlighted)");
            result.Add($"Added {CreationDate.ToString(Constants.DATE_FORMAT)}");
            result.Add(Content);

            return result;
        }

        private List<string> getItemsInfo()
        {
            List<string> result = new List<string>();
            foreach (var item in items)
                result.Add(item.Content);

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({items.Count} items, {highlightedItemsCount} highlighted)";
        }

        public bool TryAddToList(IListItem item)
        {
            if (items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) already exists");
                return false;
            }
            
            items.Add((StandardListItem)item);
            if (item.Highlighted)
                highlightedItemsCount++;

            return true;
        }

        public bool TryRemoveFromList(IListItem item)
        {
            if (!items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) does not exist");
                return false;
            }

            items.Remove((StandardListItem)item);
            if (item.Highlighted)
                highlightedItemsCount--;

            return true;
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            foreach (var item in items)
                dataToSave.Add(getItemSaveFragment(item));

            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }

        private string getItemSaveFragment(IListItem item)
        {
            List<string> dataToSave = new List<string>() { item.Content, item.Highlighted.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
