namespace NoteApp
{
    interface INote
    {
        void BuildFromLine(string line);
        void DisplayFullInfo();
        void DisplayShortInfo();
        string GetSaveEntry();
    }
}
