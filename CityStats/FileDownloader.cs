using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace CityStats
{
    /// <summary>
    /// Class for downloading of remote files.
    /// </summary>
    public class FileDownloader
    {
        private readonly List<string> files;
        
        public FileDownloader(List<string> remoteFiles)
        {
            files = remoteFiles;
        }
        
        public void DownloadToDirectory(string destDir)
        {
            using (var client = new WebClient())
            {
                foreach (var remoteFileAddress in files)
                {
                    var fileName = Path.GetFileName(remoteFileAddress);
                    var localFileAddress = Path.Combine(destDir, fileName);
                    
                    try
                    {
                        client.DownloadFile(remoteFileAddress, localFileAddress);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Warning: Failed downloading remote file '" + remoteFileAddress + "'.");
                    }
                }
            }
        }
    }
}
