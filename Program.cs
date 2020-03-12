namespace NoteApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WarnNote note = new WarnNote();
            note.Create("u", "jea");
            note.WarningLevel = 4;

            note.DisplayFullInfo();
            note.DisplayShortInfo();
        }
    }
}
