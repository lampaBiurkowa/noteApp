using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class ListNote : Note, IListNote
    {
        private const string ID = "LIST";
        private const string TEXT_ICON = "=";

        private List<ListItem> items = new List<ListItem>();
        private int highlightedItemsCount = 0;

        public ListNote(string header, string content) : base(header, content)
        {
            highlightedItemsCount = getHighlightedItemsCount();
        }

        private int getHighlightedItemsCount()
        {
            int result = 0;
            foreach (var item in items)
                if (item.Highlighted)
                    result++;

            return result;
        }

        public void DisplayItem(ListItem item)
        {
            if (item.Highlighted)
                Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"{item.Content}");

            if (item.Highlighted)
                Console.ForegroundColor = ConsoleColor.White;
        }

        public override void DisplayFullInfo()
        {
            displayMainInfo();
            displayItemsInfo();
        }

        private void displayMainInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {ID}:");
            Console.WriteLine($"{Header} ({items.Count} items, {highlightedItemsCount} highlighted)");
            Console.WriteLine($"Added {DateTime.ToString(DATE_FORMAT)}");
            Console.WriteLine($"{Content}");
        }

        private void displayItemsInfo()
        {
            foreach (var item in items)
                DisplayItem(item);
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header} ({items.Count} items, {highlightedItemsCount} highlighted)");
        }

        public bool TryAddToList(ListItem item)
        {
            if (items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) already exists");
                return false;
            }

            items.Add(item);
            if (item.Highlighted)
                highlightedItemsCount++;

            return true;
        }

        public bool TryRemoveFromList(ListItem item)
        {
            if (!items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) does not exist");
                return false;
            }

            items.Remove(item);
            if (item.Highlighted)
                highlightedItemsCount--;

            return true;
        }

        public override string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { ID, Header, Content, DateTime.ToString(DATE_FORMAT) };
            foreach (var item in items)
                dataToSave.Add(getItemSaveFragment(item));

            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }

        private string getItemSaveFragment(ListItem item)
        {
            List<string> dataToSave = new List<string>() { item.Content, item.Highlighted.ToString() };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
