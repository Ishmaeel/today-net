using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Exiclick.Tools.Today
{
    internal class Worker
    {
        private const string DATE_REGEX = @"\d{4}\.\d{2}\.\d{2}";

        internal static void Run(string[] args)
        {
            if (args.Length == 0)
                throw new InvalidOperationException("Hmm?");

            if (args.Length > 1)
                throw new InvalidOperationException("Whoa!");

            var sourcePath = Path.GetFullPath(args[0]);

            if (File.Exists(sourcePath))
                ProcessFile(sourcePath);

            if (Directory.Exists(sourcePath))
                RenameDirectory(sourcePath);
        }

        private static void ProcessFile(string sourceFilePath)
        {
            var name = Path.GetFileNameWithoutExtension(sourceFilePath);

            if (Regex.IsMatch(name, DATE_REGEX))
            {
                DuplicateFile(sourceFilePath);
            }
            else
            {
                RenameFile(sourceFilePath);
            }
        }

        private static void RenameFile(string sourceFilePath)
        {
            var name = Path.GetFileNameWithoutExtension(sourceFilePath);
            var today = GetToday();

            name = $"{name}.{today}";

            var targetFilePath = Path.Combine(Path.GetDirectoryName(sourceFilePath), name) + Path.GetExtension(sourceFilePath);

            if (File.Exists(targetFilePath))
                throw new InvalidOperationException("Nope!");

            File.Move(sourceFilePath, targetFilePath);
        }

        private static void DuplicateFile(string sourceFilePath)
        {
            var name = Path.GetFileNameWithoutExtension(sourceFilePath);
            var today = GetToday();

            name = Regex.Replace(name, DATE_REGEX, today);

            var targetFilePath = Path.Combine(Path.GetDirectoryName(sourceFilePath), name) + Path.GetExtension(sourceFilePath);

            if (File.Exists(targetFilePath))
                throw new InvalidOperationException("No!");

            File.Copy(sourceFilePath, targetFilePath, false);
        }

        private static void RenameDirectory(string directoryPath)
        {
            var today = GetToday();
            var path = Path.GetDirectoryName(directoryPath);
            var name = Path.GetFileName(directoryPath);

            var newName = $"{today} {name}";

            newName = newName.Replace("New folder", "").Trim();

            var newDirectoryPath = Path.Combine(path, newName);

            if (Directory.Exists(newDirectoryPath))
                throw new InvalidOperationException("Nope!");

            Directory.Move(directoryPath, newDirectoryPath);
        }

        private static string GetToday()
        {
            return DateTime.Today.ToString("yyyy.MM.dd");
        }
    }
}