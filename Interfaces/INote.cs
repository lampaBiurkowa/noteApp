using System;
using System.Collections.Generic;

namespace NoteApp
{
    public interface INote
    {
        DateTime CreationDate { get; set; }
        string Content { get; set; }
        string Header { get; set; }
        ConsoleColor HeaderColor { get; }
        ConsoleColor ContentColor { get; }

        void BuildFromInput(string header, string content);
        List<string> GetFullInfo();
        string GetShortInfo();
        string GetSaveEntry();
    }
}
