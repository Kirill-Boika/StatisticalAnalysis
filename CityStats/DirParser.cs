using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CityStats
{
    /// <summary>
    /// Class for getting the list of files in directory.
    /// </summary>
    public class DirParser
    {
        private string directory;
        
        public DirParser(string dir)
        {
            directory = dir;
        }
        
        public List<string> FileList
        {
            get
            {
                return GetFileList(directory);
            }
        }
        
        private List<string> GetFileList(string dir)
        {
            var files = Directory.GetFiles(dir).ToList();
            var subDirs = Directory.GetDirectories(dir);

            foreach (var subDir in subDirs)
            {
                var subDirFiles = GetFileList(subDir);
                files.AddRange(subDirFiles);
            }

            return files;
        }
    }
}
