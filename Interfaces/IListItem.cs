using System;

namespace NoteApp
{
    public interface IListItem : IEquatable<IListItem>
    {
        public string Content { get; set; }
        public bool Checked { get; set; }

        string GetDisplayableContent();
    }
}
