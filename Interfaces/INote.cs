using System;
using System.Collections.Generic;

namespace NoteApp
{
    public interface INote
    {
        DateTime CreationDate { get; set; }
        string Content { get; set; }
        string Header { get; set; }
        int Id { get; set; }
        ConsoleColor HeaderColor { get; }
        ConsoleColor ContentColor { get; }

        void BuildFromInput(string header, string content);
        void LoadUniqueFeatures(string[] componetns);
        List<string> GetFullHeader();
        string GetShortInfo();
        string GetSaveEntry();
    }
}
