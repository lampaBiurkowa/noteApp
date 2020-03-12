using System.IO;

namespace NoteApp
{
    public class SessionData
    {
        public SessionData()
        {

        }

        public void AddNote(string entry)
        {
            File.AppendAllText(FileLoader.SAVE_FILE_PATH, $"{entry}\n");
        }
    }
}
