using System;

namespace NoteApp
{
    public class ListItem : IEquatable<ListItem>
    {
        public bool Highlighted { get; set; }
        public string Content { get; set; }

        public bool Equals(ListItem compared)
        {
            return compared.Highlighted == Highlighted && Content == compared.Content;
        }
    }
}
