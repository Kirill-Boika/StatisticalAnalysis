using System;
using System.IO;

namespace StatisticalAnalysis
{
    /// <summary>
    /// Class for parsing command line arguments
    /// </summary>
    public class CmdParser
    {
        private readonly string[] arguments;
        private bool argumetsParsed = false;
        private ProgramMode mode;
        private string address;
        
        public CmdParser(string[] args)
        {
            arguments = args;
        }
        
        private void ParseArguments()
        {
            if (arguments.Length != 2)
            {
                throw new Exception("Incorrect number of arguments");
            }
            
            var inputMode = arguments[0].ToLower();
            var inputAddress = arguments[1];
            
            if (inputMode == "filesystem")
            {
                if (!Directory.Exists(inputAddress))
                {
                    throw new Exception("Directory does not exist or you do not have access rights: " + inputAddress);
                }
                
                mode = ProgramMode.filesystem;
                address = inputAddress;
            } 
            else if (inputMode == "http")
            {
                if (!File.Exists(inputAddress))
                {
                    throw new Exception("File does not exist or you do not have access rights: " + inputAddress);
                }
                
                mode = ProgramMode.http;
                address = inputAddress;
            }
            else
            {
                throw new Exception("Incorrect input mode");
            }
        }
        
        public ProgramMode Mode
        {
            get
            {
                if (!argumetsParsed)
                {
                    ParseArguments();
                    argumetsParsed = true;
                }
                return mode;
            }
        }
        
        public string Address
        {
            get
            {
                if (!argumetsParsed)
                {
                    ParseArguments();
                    argumetsParsed = true;
                }
                return address;
            }
        }
    }
}
