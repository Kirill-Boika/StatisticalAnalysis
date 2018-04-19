using System.IO;
using StatisticalAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TempDirectoryTest
{
    [TestClass]
    public class TempDirectoryTest
    {
        private string dirName;

        [TestMethod]
        public void TempDirectory_Directory_Is_Created()
        {
            var tempDir = new TempDirectory();
            dirName = tempDir.Name;
            Assert.IsTrue(Directory.Exists(dirName));
        }

        [TestMethod]
        public void TempDirectory_Directory_Is_Deleted()
        {
            Assert.IsFalse(Directory.Exists(dirName));
        }
    }
}