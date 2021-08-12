using System;

namespace Exiclick.Tools.Today
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Worker.Run(args);
                Logger.Write();
                Logger.Write("Done.");
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);

                Logger.Write();
                Logger.Write("Sorry.");
            }
        }
    }
}