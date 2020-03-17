using System;

namespace NoteApp
{
    public class NoteBuilder
    {
        public INote BuildFromLine(string line, INoteBuilder builder)
        {
            string[] components = line.Split(FileLoader.SEPARATOR);
            try
            {
                return builder.GetLoadedNote(components);
            }
            catch (Exception e)
            {
                handleReadingError(components.Length, builder.GetComponentsRequiredCount());
                throw e;
            }
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
