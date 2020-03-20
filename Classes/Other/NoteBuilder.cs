using System;

namespace NoteApp
{
    public class NoteBuilder
    {
        private const int HEADER_SAVE_INDEX = 1;
        private const int ID_SAVE_INDEX = 2;
        private const int CONTENT_SAVE_INDEX = 3;
        private const int DATE_TIME_SAVE_INDEX = 4;

        public void BuildFromLine(string line, INote note)
        {
            string[] components = line.Split(FileLoader.SEPARATOR);
            try
            {
                loadCommonFeatures(components, note);
                note.LoadUniqueFeatures(components);
            }
            catch (Exception e)
            {
                handleReadingError(components.Length, DATE_TIME_SAVE_INDEX - 1);
                throw e;
            }
        }

        private void loadCommonFeatures(string[] components, INote note)
        {
            loadHeader(components, note);
            loadId(components, note);
            loadContent(components, note);
            loadCreationDate(components, note);
        }

        private void loadHeader(string[] components, INote note)
        {
            note.Header = components[HEADER_SAVE_INDEX];
        }

        private void loadId(string[] components, INote note)
        {
            int value;
            int.TryParse(components[ID_SAVE_INDEX], out value);
            note.Id = value;
        }

        private void loadContent(string[] components, INote note)
        {
            note.Content = components[CONTENT_SAVE_INDEX];
        }

        private void loadCreationDate(string[] components, INote note)
        {
            DateTime creationDate;
            DateTime.TryParse(components[DATE_TIME_SAVE_INDEX], out creationDate);
            note.CreationDate = creationDate;
        }

        private void handleReadingError(int componentsLength, int maxIndex)
        {
            if (componentsLength < maxIndex)
                Logger.PrintError($"Invalid file data");
            else
                Logger.PrintError($"Failed to parse");
        }
    }
}
