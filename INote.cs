namespace NoteApp
{
    public interface INote
    {
        void BuildFromLine(string line);
        void BuildFromInput(string header, string content);
        void Create(string header, string content);
        void DisplayFullInfo();
        void DisplayShortInfo();
        string GetSaveEntry();
    }
}
