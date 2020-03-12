using System;
using System.Collections.Generic;

namespace NoteApp
{
    class ListNote : Note, IListNote
    {
        private const string TEXT_ICON = "=";
        private List<ListItem> items = new List<ListItem>();
        private int highlightedItemsCount = 0;

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
            Console.WriteLine($"{Header}");
            Console.WriteLine($"{Content}");
        }

        private void displayItemsInfo()
        {
            foreach (var item in items)
                DisplayItem(item);
        }

        public override void DisplayShortInfo()
        {
            Console.WriteLine($"{TEXT_ICON} {Header} ({items.Count} items)");
        }

        public void AddToList(ListItem item)
        {
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
