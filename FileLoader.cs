using System;
using System.Collections.Generic;
using System.IO;

namespace NoteApp
{
    public static class FileLoader
    {
        public const char SEPARATOR = '#';
        public const string SAVE_FILE_PATH = "Save.txt";

        public static List<Note> GetAllNotes()
        {
            List<Note> result = new List<Note>();
            var lines = File.ReadAllLines(SAVE_FILE_PATH);
            foreach (var line in lines)
                result.Add(getNoteFromId(line));

            return result;
        }

        private static Note getNoteFromId(string line)
        {
            if (line.StartsWith(InfoNote.ID))
                return new InfoNote(line);
            else if (line.StartsWith(ListNote.ID))
                return new ListNote(line);
            else if (line.StartsWith(RemindNote.ID))
                return new RemindNote(line);
            else if (line.StartsWith(WarnNote.ID))
                return new WarnNote(line);
            else
            {
                handleUnrecognizedNoteError(line);
                throw new Exception($"Unrecognized note type in line {line}");
            }
        }

        private static void handleUnrecognizedNoteError(string line)
        {
            Logger.PrintError($"Unrecognized note type in line {line}");
        }
        public static void SaveAllNotes(List<Note> notes)
        {
            File.WriteAllText(SAVE_FILE_PATH, "");
            foreach (var note in notes)
                File.AppendAllText(SAVE_FILE_PATH, $"{note.GetSaveEntry()}\n");
        }
    }
}
