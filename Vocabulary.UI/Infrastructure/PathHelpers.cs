using System;
using System.IO;

namespace Vocabulary.Infrastructure
{
    public static class PathHelpers
    {
        public const string DbDirectory = "Data";
        public const string DataDirectoryVariable = "DataDirectory";

        public static string EnsureDataDirectory()
        {
            var data = AppDomain.CurrentDomain.BaseDirectory;
            var targetPath = Path.Combine(data, DbDirectory);

            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            SetDataDirectoryVariable(targetPath);
            return targetPath;
        }

        public static void SetDataDirectoryVariable(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException(nameof(path));

            var domain = AppDomain.CurrentDomain;

            if (domain.GetData(DataDirectoryVariable) == null)
                  domain.SetData(DataDirectoryVariable,path);
        }
    }
}