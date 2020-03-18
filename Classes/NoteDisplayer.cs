using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class NoteDisplayer
    {
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;

        public void DisplayFullInfo(INote note)
        {
            displayFullInfoHeader(note);
            displayFullInfoContent(note);
            displayAdditionalInfoContent(note);

            Console.ForegroundColor = DEFAULT_COLOR;
        }

        private void displayFullInfoHeader(INote note)
        {
            List<string> noteFullHeader = note.GetFullHeader();
            Console.ForegroundColor = note.HeaderColor;
            for (int i = 0; i < noteFullHeader.Count; i++)
                Console.WriteLine(noteFullHeader[i]);
        }

        private void displayFullInfoContent(INote note)
        {
            Console.ForegroundColor = note.ContentColor;
            Console.WriteLine($"Added {note.CreationDate.ToString(Constants.DATE_FORMAT)}");
            Console.WriteLine(note.Content);
        }

        private void displayAdditionalInfoContent(INote note)
        {
            List<string> noteAdditionlContent = note.GetAdditionalContent();
            for (int i = 0; i < noteAdditionlContent.Count; i++)
                Console.WriteLine(noteAdditionlContent[i]);
        }

        public void DisplayShortInfo(INote note)
        {
            Console.ForegroundColor = note.HeaderColor;
            Console.WriteLine(note.GetShortInfo());
            Console.ForegroundColor = DEFAULT_COLOR;
        }
    }
}
