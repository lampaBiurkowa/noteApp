using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class SessionData
    {
        List<INote> notes = new List<INote>();
        FileLoader fileLoader = new FileLoader();

        public SessionData()
        {
            notes = fileLoader.GetAllNotes();
        }

        public void AddNote(INote note)
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
