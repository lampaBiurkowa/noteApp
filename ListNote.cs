using System;
using System.Collections.Generic;

namespace NoteApp
{
    class ListNote : Note, IListNote
    {
        private const string TEXT_ICON = "=";
        private List<ListItem> items = new List<ListItem>();
        private int highlightedItemsCount = 0;

        public ListNote(string header, string content) : base(header, content)
        {
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
            Console.WriteLine($"{TEXT_ICON} INFO:");
            Console.WriteLine($"{Header} ({items.Count} items, {highlightedItemsCount} highlighted)");
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

        public void AddToList(ListItem item)
        {
            if (items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) already exists");
                return;
            }

            items.Add(item);
            if (item.Highlighted)
                highlightedItemsCount++;
        }

        public void RemoveFromList(ListItem item)
        {
            if (!items.Contains(item))
            {
                Logger.PrintError($"Item: {item} (Content = {item.Content}, Highlighted = {item.Highlighted}) does not exist");
                return;
            }

            items.Remove(item);
            if (item.Highlighted)
                highlightedItemsCount--;
        }
    }
}
