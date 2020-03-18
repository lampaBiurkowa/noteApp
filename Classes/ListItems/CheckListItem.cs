using System;

namespace NoteApp
{
    public class CheckListItem : IListItem, IEquatable<CheckListItem>
    {
        public const int SAVE_COMPONENTS_COUNT = 3;
        public const int CONTENT_SAVE_INDEX = 0;
        public const int HIGHLIGHTED_SAVE_INDEX = 1;
        public const int CHECKED_SAVE_INDEX = 2;

        public bool Checked { get; set; }
        public string Content { get; set; }
        public bool Highlighted { get; set; }

        public CheckListItem(bool isChecked, string content, bool highlighted)
        {
            Checked = isChecked;
            Content = content;
            Highlighted = highlighted;
        }

        public bool Equals(CheckListItem compared)
        {;
            return Checked == compared.Checked && Highlighted == compared.Highlighted && Content == compared.Content;
        }
    }
}
