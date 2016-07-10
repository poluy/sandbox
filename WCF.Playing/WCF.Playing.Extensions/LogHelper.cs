using System;

namespace WCF.Playing.Extensions
{
    internal static class LogHelper
    {
        internal static void LogSoap(string title, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            
        }
    }
}
