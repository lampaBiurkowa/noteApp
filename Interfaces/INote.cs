using System;

namespace NoteApp
{
    public interface INote
    {
        DateTime CreationDate { get; set; }
        string Content { get; set; }
        string Header { get; set; }

        void DisplayFullInfo();
        void DisplayShortInfo();
        string GetSaveEntry();
    }
}
