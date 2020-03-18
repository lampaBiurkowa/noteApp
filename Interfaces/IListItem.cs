using System;

namespace NoteApp
{
    public interface IListItem
    {
        public string Content { get; set; }
        public bool Highlighted { get; set; }
    }
}
