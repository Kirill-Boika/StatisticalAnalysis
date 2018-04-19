using System;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace CityStats
{
    /// <summary>
    /// Class for processing files with statistical information.
    /// </summary>
    public class FileProcessor
    {
        /// <summary>
        /// Class for saving the results of FileProcessor
        /// </summary>
        public class ResultsSaver
        {
            private FileProcessor processor;
            
            public ResultsSaver(ref FileProcessor fileProcessor)
            {
                processor = fileProcessor;
            }
            
            public void SaveResults()
            {
                using (var file = new StreamWriter("output.txt"))
                {
                    foreach (var record in processor.stats)
                    {
                        file.WriteLine(record.Key + ", " + record.Value);
                    }
                }
            }
        }
        
        private readonly ConcurrentDictionary<string, int> stats = new ConcurrentDictionary<string, int>();
        private List<string> fileList;
        
        public FileProcessor(List<string> files)
        {
            fileList = files;
        }
        
        public void ProcessFiles()
        {
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Convert.ToInt32(ConfigurationManager.AppSettings["N"]);
            Parallel.ForEach(fileList, options, ProcessFile);
        }
        
        private void ProcessFile(string path)
        {
            using (var reader = File.OpenText(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var record = line.Split(',');

                    if (record.Length != 2)
                    {
                        Console.WriteLine("Warning: Wrong data format in line: '" + line + "', in file: " + path + ".");
                        continue;
                    }

                    var city = record[0].Trim().ToUpper();
                    var number = Convert.ToInt32(record[1]);

                    stats.TryAdd(city, 0);
                    stats[city] += number;
                }
            }
        }
    }
}
