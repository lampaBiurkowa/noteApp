using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    public class InfoNote : INote
    {
        private const string TEXT_ICON = "(i)";
        public const string NAME_ID = "INFO";

        public DateTime CreationDate { get; set; }
        public string Content { get; set; }
        public string Header { get; set; }
        public int Id { get; set; }
        public ConsoleColor ContentColor => ConsoleColor.White;
        public ConsoleColor HeaderColor => ConsoleColor.Blue;

        public void BuildFromInput(string header, string content)
        {
            new NoteFromInputBuilder().BuildGenericData(this, header, content);
        }

        public List<string> GetFullHeader()
        {
            List<string> result = new List<string>();
            result.Add($"{TEXT_ICON} {NAME_ID}");
            result.Add($"## {Header} ##");

            return result;
        }

        public string GetShortInfo()
        {
            return $"{TEXT_ICON} {Header}";
        }

        public string GetSaveEntry()
        {
            List<string> dataToSave = new List<string>() { NAME_ID, Id.ToString(), Header, Content, CreationDate.ToString(Constants.DATE_FORMAT) };
            return dataToSave.Aggregate((i, j) => i + FileLoader.SEPARATOR + j);
        }
    }
}
