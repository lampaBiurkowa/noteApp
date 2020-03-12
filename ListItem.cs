using System;

namespace NoteApp
{
    class ListItem : IEquatable<ListItem>
    {
        public bool Highlighted { get; set; }
        public string Content { get; set; }

        public bool Equals(ListItem compared)
        {
            return Highlighted == Highlighted && compared.Content == compared.Content;
        }
    }
}
