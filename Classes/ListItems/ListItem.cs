using System;

namespace NoteApp
{
    public class ListItem : IEquatable<ListItem>
    {
        public const int SAVE_COMPONENTS_COUNT = 2;
        public const int CONTENT_SAVE_INDEX = 0;
        public const int HIGHLIGHTED_SAVE_INDEX = 1;

        public string Content { get; set; }
        public bool Checked { get; set; }

        public ListItem(bool isChecked, string content)
        {
            Content = content;
            Checked = isChecked;
        }

        public bool Equals(ListItem compared)
        {
            return Checked == compared.Checked && Content == compared.Content;
        }
    }
}
