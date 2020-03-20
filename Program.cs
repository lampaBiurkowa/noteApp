using System;

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
                        sessionData.DisplayListNotes();
                        break;
                    case "3":
                        handleDisplayingRecentNotes();
                        break;
                    case "5":
                        handleAddingNoteFromUser();
                        break;
                    case "6":
                        handleRemovingNoteFromUser();
                        break;
                    case "7":
                        return;
                }
            }
        }

        static void printMenuOptions()
        {
            Console.WriteLine("\n*** Diary Menu ***");
            Console.WriteLine("1 - display all notes");
            Console.WriteLine("2 - display unwrapped list notes");
            Console.WriteLine("3 - display recent notes");
            Console.WriteLine("4 - search for a phrase (not implemented yet)");
            Console.WriteLine("5 - add a note");
            Console.WriteLine("6 - remove a note");
            Console.WriteLine("7 - quit");
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
            NoteFromInputBuilder builder = new NoteFromInputBuilder();
            builder.HandleAddingNoteFromUser(sessionData);
        }

        static void handleRemovingNoteFromUser()
        {
            const int DISCARD_ID = -1;
            Console.WriteLine("Type id of note to remove (-1 to discard)");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            if (id == DISCARD_ID)
                return;

            sessionData.TryRemoveNote(id);
        }
    }
}
