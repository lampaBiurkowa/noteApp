namespace NoteApp
{
    public interface INote
    {
        void BuildFromLine(string line);
        INote BuildFromInput(string header, string content);
        void DisplayFullInfo();
        void DisplayShortInfo();
        string GetSaveEntry();
    }
}
