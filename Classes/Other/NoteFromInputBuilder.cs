using System;
using System.Collections.Generic;

namespace NoteApp
{
    public class NoteFromInputBuilder
    {
        private SessionData sessionData;

        public void HandleAddingNoteFromUser(SessionData sessionData)
        {
            this.sessionData = sessionData;
            Dictionary<int, string> noteMap = getNoteMap();
            printNoteTypesInfo(noteMap);

            int type = tryGetNoteTypeFromUser(noteMap);
            string header = getHeaderFromUser();
            string content = getContentFromUser();
            submitNote(noteMap[type], header, content);
        }

        private Dictionary<int, string> getNoteMap()
        {
            Dictionary<int, string> noteMap = new Dictionary<int, string>();
            noteMap.Add(1, "info");
            noteMap.Add(2, "list");
            noteMap.Add(3, "remind");
            noteMap.Add(4, "warn");
            noteMap.Add(5, "check");

            return noteMap;
        }

        private void printNoteTypesInfo(Dictionary<int, string> noteMap)
        {
            Console.Write("Choose kind of the note ( ");
            foreach (var pair in noteMap)
                Console.Write($"{pair.Key} - {pair.Value} ");
            Console.WriteLine(")");
        }

        private int tryGetNoteTypeFromUser(Dictionary<int, string> noteMap)
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

        private string getHeaderFromUser()
        {
            Console.WriteLine("Type the title of the note");
            return Console.ReadLine();
        }

        private string getContentFromUser()
        {
            Console.WriteLine("Type-in the content of the note");
            return Console.ReadLine();
        }

        private void submitNote(string type, string header, string content)
        {
            sessionData.AddNote(getDeterminedNoteObject(type, header, content));
        }

        private INote getDeterminedNoteObject(string data, string header, string content)
        {
            INote note;
            switch (data)
            {
                case "check":
                    note = new CheckListNote();
                    break;
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
                    Logger.PrintError($"Unkonwn note {data}");
                    throw new Exception($"Unknown note {data}");
            }

            note.BuildFromInput(header, content);
            return note;
        }

        public void BuildListItems(IListNote note)
        {
            Console.WriteLine("Type count of items in list:");
            int count;
            int.TryParse(Console.ReadLine(), out count);
            for (int i = 0; i < count; i++)
                handleAddingItem(note);
        }

        private void handleAddingItem(IListNote note)
        {
            Console.WriteLine("Type item content");
            string content = Console.ReadLine();
            Console.WriteLine("Is checked? (Y/n)");
            bool isChecked = Console.ReadLine() == "n" ? false : true;
            ItemsModifier modifier = new ItemsModifier();
            modifier.TryAddToList(note, new ListItem(isChecked, content));
        }

        public void BuildGenericData(INote note, string header, string content)
        {
            note.Content = content;
            note.CreationDate = DateTime.Now;
            note.Header = header;
            note.Id = SessionData.GenerateId();
        }
    }
}
