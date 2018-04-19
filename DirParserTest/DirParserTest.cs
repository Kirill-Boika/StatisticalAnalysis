using System.IO;
using StatisticalAnalysis;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirParserTest
{
    [TestClass]
    public class DirParserTest
    {
        private DirParser dirParser;

        [TestMethod]
        public void DirParser_Happy_Path()
        {
            var expectedFileNames = new List<string>()
            {
                "test-file.txt",
                "test-sub-dir-file.txt"
            };

            dirParser = new DirParser("test-dir");
            var files = dirParser.FileList;
            var actualFileNames = new List<string>();
            foreach (var file in files)
            {
                actualFileNames.Add(Path.GetFileName(file));
            }

            Assert.IsTrue(expectedFileNames.SequenceEqual(actualFileNames));
        }
    }
}
