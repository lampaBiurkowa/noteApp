using System;

namespace NoteApp
{
    public interface INote
    {
        DateTime CreationDate { get; set; }
        string Content { get; set; }
        string Header { get; set; }

        void BuildFromInput(string header, string content);
        void DisplayFullInfo();
        void DisplayShortInfo();
        string GetSaveEntry();
    }
}
