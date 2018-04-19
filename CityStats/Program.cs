using System;

namespace StatisticalAnalysis
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var cmdParser = new CmdParser(args);
                
                var mode = cmdParser.Mode;
                var address = cmdParser.Address;
                
                switch (mode)
                {
                    case ProgramMode.filesystem:
                        Extensions.ProcessFilesAndSaveResults(address);
                        break;
                        
                    case ProgramMode.http:
                        var remoteFiles = Extensions.FileLines(address);
                        var fileDownloader = new FileDownloader(remoteFiles);
                        var tempDir = new TempDirectory();
                        fileDownloader.DownloadToDirectory(tempDir.Name);
                        Extensions.ProcessFilesAndSaveResults(tempDir.Name);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + ".");
            }
        }
    }
}