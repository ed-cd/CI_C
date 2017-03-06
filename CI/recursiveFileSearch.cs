using System;
using System.IO;
using System.Linq;

namespace CI
{
    public class RecursiveFileSearch
    {
        public static string findFile(string fileName, string baseDirectory)
        {
            try
            {
                if (!Directory.Exists(baseDirectory)) return "";
                var files = Directory.EnumerateFiles(baseDirectory);               
                if (files.Any(file => Path.GetFileName(file)==fileName))
                {
                    return baseDirectory + Path.Combine(baseDirectory, fileName);
                }
                foreach (var dir in Directory.EnumerateDirectories(baseDirectory))
                {
                    var path = findFile(fileName, Path.Combine(baseDirectory, dir));
                    if (path.Length > 0)
                    {
                        return path;
                    }
                }
            } catch(UnauthorizedAccessException) { }
            return "";
        }
    }
}