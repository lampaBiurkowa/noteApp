using System;
using System.Collections.Generic;

namespace NoteApp
{
    class Program
    {
        static SessionData sessionData = new SessionData();

        static void Main(string[] args)
        {
            while (true)
            {
                printMenuOptions();
                switch (Console.ReadLine())
                {
                    case "1":
                        sessionData.DisplayNotes();
                        break;
                    case "4":
                        handleAddingNoteFromUser();
                        break;
                }
            }
        }

        static void printMenuOptions()
        {
            Console.WriteLine("\n*** Diary Menu ***");
            Console.WriteLine("1 - display all notes");
            Console.WriteLine("2 - display recent notes (not implemented yet)");
            Console.WriteLine("3 - search for a phrase (not implemented yet)");
            Console.WriteLine("4 - add a note");
            Console.WriteLine("5 - remove a note (not implemented yet)");
        }

        static void handleAddingNoteFromUser()
        {
            Dictionary<int, string> noteMap = getNoteMap();
            printNoteTypesInfo(noteMap);

            int type = tryGetNoteTypeFromUser(noteMap);
            string header = getHeaderFromUser();
            string content = getContentFromUser();
            submitNote(noteMap[type], header, content);
        }

        static Dictionary<int, string> getNoteMap()
        {
            Dictionary<int, string> noteMap = new Dictionary<int, string>();
            noteMap.Add(1, "info");
            noteMap.Add(2, "list");
            noteMap.Add(3, "remind");
            noteMap.Add(4, "warn");

            return noteMap;
        }

        static void printNoteTypesInfo(Dictionary<int, string> noteMap)
        {
            Console.Write("Choose kind of the note ( ");
            foreach (var pair in noteMap)
                Console.Write($"{pair.Key} - {pair.Value} ");
            Console.WriteLine(")");
        }

        static int tryGetNoteTypeFromUser(Dictionary<int, string> noteMap)
        {
            int type;
            int.TryParse(Console.ReadLine(), out type);
            if (!noteMap.ContainsKey(type))
            {
                Logger.PrintError("Wrong note type specifed!");
                throw new Exception("Wrong note type specifed!");
            }

            return type;
        }

        static string getHeaderFromUser()
        {
            Console.WriteLine("Type the title of the note");
            return Console.ReadLine();
        }

        static string getContentFromUser()
        {
            Console.WriteLine("Type-in the content of the note");
            return Console.ReadLine();
        }

        static void submitNote(string type, string header, string content)
        {
            Note note = getDeterminedNoteObject(type);
            note.BuildFromInput(header, content);
            sessionData.AddNote(note);
        }

        static Note getDeterminedNoteObject(string data)
        {
            Note note;
            switch (data)
            {
                case "info":
                    note = new InfoNote();
                    break;
                case "list":
                    note = new ListNote();
                    break;
                case "remind":
                    note = new RemindNote();
                    break;
                case "warn":
                    note = new WarnNote();
                    break;
                default:
                    return null;
            }

            return note;
        }
    }
}
