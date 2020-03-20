using System;
using System.Collections.Generic;
using System.IO;

namespace NoteApp
{
    public class FileLoader
    {
        public const char SEPARATOR = '#';
        public const string SAVE_FILE_PATH = "Save.txt";

        public List<INote> GetAllNotes()
        {
            createFileIfDoesntExist();
            List<INote> result = new List<INote>();
            var lines = File.ReadAllLines(SAVE_FILE_PATH);
            foreach (var line in lines)
                result.Add(getNoteFromId(line));

            return result;
        }

        void createFileIfDoesntExist()
        {
            if (!File.Exists(SAVE_FILE_PATH))
                File.WriteAllText(SAVE_FILE_PATH, "");
        }

        private INote getNoteFromId(string line)
        {
            if (line.StartsWith(CheckListNote.NAME_ID))
                return new NoteBuilder().BuildFromLine(line, new CheckListNoteBuilder());
            else if (line.StartsWith(InfoNote.NAME_ID))
                return new NoteBuilder().BuildFromLine(line, new InfoNoteBuilder());
            else if (line.StartsWith(ListNote.NAME_ID))
                return new NoteBuilder().BuildFromLine(line, new ListNoteBuilder());
            else if (line.StartsWith(RemindNote.NAME_ID))
                return new NoteBuilder().BuildFromLine(line, new RemindNoteBuilder());
            else if (line.StartsWith(WarnNote.NAME_ID))
                return new NoteBuilder().BuildFromLine(line, new WarnNoteBuilder());
            else
            {
                handleUnrecognizedNoteError(line);
                throw new Exception($"Unrecognized note type in line {line}");
            }
        }

        private void handleUnrecognizedNoteError(string line)
        {
            Logger.PrintError($"Unrecognized note type in line {line}");
        }

        public void SaveAllNotes(List<INote> notes)
        {
            File.WriteAllText(SAVE_FILE_PATH, "");
            foreach (var note in notes)
                File.AppendAllText(SAVE_FILE_PATH, $"{note.GetSaveEntry()}\n");
        }
    }
}
