using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class SessionData
    {
        List<Note> notes = new List<Note>();
        FileLoader fileLoader = new FileLoader();

        public SessionData()
        {
            notes = fileLoader.GetAllNotes();
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
            fileLoader.SaveAllNotes(notes);
        }

        public void DisplayNotes()
        {
            if (notes.Count == 0)
                Console.WriteLine("No notes yet");

            foreach (var note in notes)
                note.DisplayFullInfo();
        }
    }
}
