namespace NoteApp
{
    public interface INoteBuilder
    {
        INote GetLoadedNote(string[] components);
        int GetComponentsRequiredCount();
    }
}
