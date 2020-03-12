using System;

namespace NoteApp
{
    public class ListItem : IEquatable<ListItem>
    {
        public const int SAVE_COMPONENTS_COUNT = 2;
        public const int CONTENT_SAVE_INDEX = 0;
        public const int HIGHLIGHTED_SAVE_INDEX = 1;

        public string Content { get; set; }
        public bool Highlighted { get; set; }

        public ListItem(string content, bool highlighted)
        {
            Content = content;
            Highlighted = highlighted;
        }

        public bool Equals(ListItem compared)
        {
            return Highlighted == compared.Highlighted && Content == compared.Content;
        }
    }
}
