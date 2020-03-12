using System;
using System.IO;

namespace NoteApp
{
    public static class Logger
    {
        private const string LOG_FILE_PATH = "errors.log";
        public static void PrintError(string content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.WriteLine($"ERR: {content}");
            Console.ForegroundColor = ConsoleColor.White;
            File.AppendAllText(LOG_FILE_PATH, $"#{DateTime.Now}: {content}\n");
        }
    }
}
