using System.Collections.Generic;

namespace NoteApp
{
    public class SessionData
    {
        List<Note> notes = new List<Note>();

        public SessionData()
        {

        }

        public void AddNote(Note note)
        {
            notes.Add(note);
            FileLoader.SaveAllNotes(notes);
        }
    }
}
