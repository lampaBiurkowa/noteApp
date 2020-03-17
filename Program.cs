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
                    case "2":
                        handleDisplayingRecentNotes();
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
            Console.WriteLine("2 - display recent notes");
            Console.WriteLine("3 - search for a phrase (not implemented yet)");
            Console.WriteLine("4 - add a note");
            Console.WriteLine("5 - remove a note (not implemented yet)");
        }

        static void handleDisplayingRecentNotes()
        {
            Console.WriteLine("Choose peroid: 1 - last hour, 2 - last day, 3 - last week");
            switch (Console.ReadLine())
            {
                case "1":
                    sessionData.DisplayRecentNotsNote(DateTime.Now.AddHours(-1));
                    break;
                case "2":
                    sessionData.DisplayRecentNotsNote(DateTime.Now.AddDays(-1));
                    break;
                case "3":
                    sessionData.DisplayRecentNotsNote(DateTime.Now.AddDays(-7));
                    break;
            }
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
            sessionData.AddNote(getDeterminedNoteObject(type, header, content));
        }

        static INote getDeterminedNoteObject(string data, string header, string content)
        {
            INote note;
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

            note.BuildFromInput(header, content);
            return note;
        }
    }
}
