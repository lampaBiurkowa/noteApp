using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class SessionData
    {
        static List<INote> notes = new List<INote>();
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

        public void DisplayRecentNotsNote(DateTime borderDate)
        {
            NoteDisplayer displayer = new NoteDisplayer();
            bool displayed = false;

            foreach (var note in notes)
                if (note.CreationDate > borderDate)
                {
                    displayed = true;
                    displayer.DisplayMainInfo(note);
                }

            if (!displayed)
                Console.WriteLine("No notes yet");
        }

        public void DisplayNotes()
        {
            if (notes.Count == 0)
                Console.WriteLine("No notes yet");

            NoteDisplayer displayer = new NoteDisplayer();
            foreach (var note in notes)
                displayer.DisplayMainInfo(note);
        }

        public void DisplayListNotes()
        {
            if (notes.Count == 0)
                Console.WriteLine("No list notes yet");

            NoteDisplayer displayer = new NoteDisplayer();
            foreach (var note in notes)
                if (note is IListNote)
                    displayer.DisplayFullList((IListNote)note);
        }

        public void TryRemoveNote(int id)
        {
            INote note = notes.Find(element => element.Id == id);
            if (note == null)
            {
                Console.WriteLine($"Note with id {id} not found");
                return;
            }

            notes.Remove(note);
            fileLoader.SaveAllNotes(notes);
        }

        public static int GenerateId()
        {
            return notes.Count;
        }
    }
}
