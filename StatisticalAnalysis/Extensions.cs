using System.IO;
using System.Collections.Generic;

namespace StatisticalAnalysis
{
    public class Extensions
    {
        public static List<string> FileLines(string path)
        {
            var fileLines = new List<string>();
            
            using (var reader = File.OpenText(path))
            {
                 while (!reader.EndOfStream)
                 {
                     var line = reader.ReadLine();
                     fileLines.Add(line);
                 }
            }
            
            return fileLines;
        }
        
        public static string GetRandomTempDirName()
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }
        
        public static void ProcessFilesAndSaveResults(string dir)
        {
            var dirParser = new DirParser(dir);
            var files = dirParser.FileList;
            var fileProcessor = new FileProcessor(files);
            fileProcessor.ProcessFiles();
            var saver = new FileProcessor.ResultsSaver(ref fileProcessor);
            saver.SaveResults();
        }
    }
}
