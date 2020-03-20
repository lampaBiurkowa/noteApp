using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class CheckListNote : IListNote
    {
        private const int LAST_COMMON_INDEX = 4;
        public const string NAME_ID = "CHECKLIST";
        private const string TEXT_ICON = "=v=";

        public List<ListItem> Items { get; set; } = new List<ListItem>();
        public int CheckedItemsCount => Items.Count(element => element.Checked);

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int Id { get; set; }
        public ConsoleColor ContentColor => getColorForPercentage(getPercentage());
        public ConsoleColor HeaderColor => ConsoleColor.DarkBlue;

        public void BuildFromInput(string header, string content)
        {
            NoteFromInputBuilder builder = new NoteFromInputBuilder();
            builder.BuildGenericData(this, header, content);
            builder.BuildListItems(this);
        }

        public void LoadUniqueFeatures(string[] components)
        {
            new ListItemBuilder().InitListItemsFromComponents(components, LAST_COMMON_INDEX, this);
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {NAME_ID}");
            result.Add($"## {Header} ## ({Items.Count} items, {CheckedItemsCount} checked)");

            return result;
        }

        public List<string> GetAdditionalContent()
        {
            List<string> result = new List<string>();
            foreach (var item in Items)
                result.Add(GetListItemContent(item));

            result.Add($"{getPercentage()}% done");
            return result;
        }

        public string GetListItemContent(ListItem item)
        {
            return item.Checked ? $"- (v) {item.Content}" : $"- (x) {item.Content}";
        }

        private float getPercentage()
        {
            return Items.Count == 0 ? 0 : ((float)CheckedItemsCount / Items.Count) * 100;
        }

        private ConsoleColor getColorForPercentage(float percantage)
        {
            Dictionary<int, ConsoleColor> thresholds = new Dictionary<int, ConsoleColor>()
            {
                { 0, ConsoleColor.Red },
                { 40, ConsoleColor.Yellow },
                { 80, ConsoleColor.Blue },
                { 100, ConsoleColor.Green }
            };

            var bigger = thresholds.Where(element => element.Key <= percantage);
            return bigger.Any() ? bigger.Aggregate((e1, e2) => e1.Key > e2.Key ? e1 : e2).Value : ConsoleColor.Red;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header} ({Items.Count} items, {CheckedItemsCount} checked ({getPercentage()}% done))";
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
