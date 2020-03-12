using System;

namespace NoteApp
{
    class ListNote : Note, IListNote
    {
        public override void Create(string header, string content)
        {
            Header = header;
            Content = content;
            DateTime = DateTime.Now;
        }

        public override void DisplayFullInfo()
        {

        }

        public override void DisplayShortInfo()
        {

        }

        public void AddToList(ListItem item)
        {

        }

        public void RemoveFromList(ListItem item)
        {

        }
    }
}
