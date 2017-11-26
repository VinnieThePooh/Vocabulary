using System;
using System.IO;

namespace Vocabulary.Core.Infrastructure.Helpers
{
    public static class InitializationHelper
    {
        private const string DataFolderName = "Data";

        public static void SetDataDirectoryFolder()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(path,DataFolderName));
        }


        public static void EnsureDataDirectoryExists()
        {
            var dirPath = (string)AppDomain.CurrentDomain.GetData("DataDirectory");
            if (string.IsNullOrEmpty(dirPath))
                 throw new ArgumentNullException("DataDirectory keyword is not set");
            
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
        }
    }
}
