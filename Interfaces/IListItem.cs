namespace NoteApp
{
    public interface IListItem
    {
        public string Content { get; set; }
        public bool Checked { get; set; }

        string GetDisplayableContent();
    }
}
