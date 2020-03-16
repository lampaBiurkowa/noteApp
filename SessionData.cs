using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class SessionData
    {
        static List<Note> notes = new List<Note>();

        public SessionData()
        {
            if (notes.Count > 0)
                notes = FileLoader.GetAllNotes();
            else
                Console.WriteLine("No notes yet");
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
            FileLoader.SaveAllNotes(notes);
        }

        public void DisplayNotes()
        {
            foreach (var note in notes)
                note.DisplayFullInfo();
        }
    }
}
