﻿using System;
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

        public void DisplayRecentNotsNote(DateTime borderDate)
        {
            NoteDisplayer displayer = new NoteDisplayer();
            bool displayed = false;

            foreach (var note in notes)
                if (note.CreationDate > borderDate)
                {
                    displayed = true;
                    displayer.DisplayFullInfo(note);
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
                displayer.DisplayFullInfo(note);
        }
    }
}
