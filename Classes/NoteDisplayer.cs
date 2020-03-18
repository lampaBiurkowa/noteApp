using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class NoteDisplayer
    {
        private const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
        private const int HEADER_LINES_COUNT = 2;

        public void DisplayFullInfo(INote note)
        {
            displayFullInfoHeader(note);
            displayFullInfoContent(note);

            Console.ForegroundColor = DEFAULT_COLOR;
        }

        private void displayFullInfoHeader(INote note)
        {
            List<string> noteFullInfo = note.GetFullInfo();
            Console.ForegroundColor = note.HeaderColor;
            for (int i = 0; i < HEADER_LINES_COUNT; i++)
                Console.WriteLine(noteFullInfo[i]);
        }

        private void displayFullInfoContent(INote note)
        {
            List<string> noteFullInfo = note.GetFullInfo();
            Console.ForegroundColor = note.ContentColor;
            for (int i = HEADER_LINES_COUNT; i < noteFullInfo.Count; i++)
                Console.WriteLine(noteFullInfo[i]);
        }

        public void DisplayShortInfo(INote note)
        {
            Console.ForegroundColor = note.HeaderColor;
            Console.WriteLine(note.GetShortInfo());
            Console.ForegroundColor = DEFAULT_COLOR;
        }
    }
}
