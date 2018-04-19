using StatisticalAnalysis;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileProcessorTest
{
    [TestClass]
    public class FileProcessorTest
    {
        [TestMethod]
        public void FileProcessor_Happy_Path()
        {
            var dirParser = new DirParser("test-data");
            var files = dirParser.FileList;
            var fileProcessor = new FileProcessor(files);
            fileProcessor.ProcessFiles();
            var saver = new FileProcessor.ResultsSaver(ref fileProcessor);
            saver.SaveResults();
            var actualOutput = Extensions.FileLines("output.txt");
            var expectedOutput = new List<string>()
            {
                "БРЕСТ, 800",
                "МИНСК, 650"
            };

            Assert.IsTrue(expectedOutput.SequenceEqual(actualOutput));
        }
    }
}