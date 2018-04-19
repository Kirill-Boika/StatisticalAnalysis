using System;
using System.IO;
using StatisticalAnalysis;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileDownloaderTest
{
    [TestClass]
    public class FileDownloaderTest
    {
        private TempDirectory dir = new TempDirectory();

        [TestMethod]
        public void FileDownloader_Happy_Path()
        {
            var remoteFiles = new List<string>()
            {
                "http://ipv4.download.thinkbroadband.com/5MB.zip"
            };
            var fileDownloader = new FileDownloader(remoteFiles);
            fileDownloader.DownloadToDirectory(dir.Name);
            var localFileName = Path.GetFileName(remoteFiles[0]);
            var localFileAddress = Path.Combine(dir.Name, localFileName);
            Assert.IsTrue(File.Exists(localFileAddress));
        }
    }
}
