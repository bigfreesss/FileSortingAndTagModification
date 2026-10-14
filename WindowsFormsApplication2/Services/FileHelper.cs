using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApplication2.Services
{
    public static class FileHelper
    {
        public static List<FileInfo> GetFilesRecursively(string path, string extNames)
        {
            var result = new List<FileInfo>();
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                return result;

            // 在 .NET Framework 4.8 中不保证有 ToHashSet()，改为 HashSet 构造
            var extFilterList = (extNames ?? "")
                                .Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => s.Trim().ToLower())
                                .Where(s => !string.IsNullOrEmpty(s))
                                .ToList();
            var extFilter = new HashSet<string>(extFilterList);

            void scan(string p)
            {
                DirectoryInfo di = new DirectoryInfo(p);
                foreach (var f in di.GetFiles())
                {
                    if (extFilter.Count == 0)
                        result.Add(f);
                    else
                    {
                        var ext = f.Extension.TrimStart('.').ToLower();
                        if (extFilter.Contains(ext))
                            result.Add(f);
                    }
                }
                foreach (var d in di.GetDirectories())
                    scan(d.FullName);
            }

            scan(path);
            return result;
        }

        public static FileInfo[] GetFilesInDirectory(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) return new FileInfo[0];
            DirectoryInfo di = new DirectoryInfo(path);
            return di.GetFiles();
        }

        public static string EnsureTrailingSeparator(string directory)
        {
            if (string.IsNullOrEmpty(directory)) return directory;
            if (!directory.EndsWith(Path.DirectorySeparatorChar.ToString()))
                return directory + Path.DirectorySeparatorChar;
            return directory;
        }

        public static string SafeRelativePath(string fullPath, string rootPath)
        {
            rootPath = EnsureTrailingSeparator(Path.GetFullPath(rootPath));
            fullPath = Path.GetFullPath(fullPath);
            if (fullPath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
                return fullPath.Substring(rootPath.Length).TrimStart(Path.DirectorySeparatorChar);
            return Path.GetFileName(fullPath);
        }
    }
}