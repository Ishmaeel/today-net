using System;

namespace Exiclick.Tools.Today
{
    internal class Logger
    {
        internal static void Write(string message = null)
        {
            Console.WriteLine(message);
        }
    }
}