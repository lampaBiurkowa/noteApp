namespace NoteApp
{
    interface INote
    {
        void Create(string header, string content);
        void DisplayFullInfo();
        void DisplayShortInfo();
    }
}
