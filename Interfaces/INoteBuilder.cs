namespace NoteApp
{
    interface INoteBuilder
    {
        INote BuildFromInput(string header, string content);
        INote GetLoadedNote(string[] components);
        int GetComponentsRequiredCount();
    }
}
