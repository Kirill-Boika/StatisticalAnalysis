using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatisticalAnalysis;

namespace CmdParserTest
{
    [TestClass]
    public class CmdParserTest
    {
        private CmdParser parser;

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CmdParser_Exception_In_Case_Of_Empty_Args()
        {
            var emptyArgs = new string[0];
            parser = new CmdParser(emptyArgs);
            var dummy = parser.Mode;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CmdParser_Exception_In_Case_Of_Wrong_Mode()
        {
            var args = new string[2] { "not-supported-mode", "test-dir"};
            parser = new CmdParser(args);
            var dummy = parser.Mode;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CmdParser_Exception_In_Case_Of_Non_Existent_Dir_For_Filesystem_Mode()
        {
            var args = new string[2] { "filesystem", "non-existent-dir" };
            parser = new CmdParser(args);
            var dummy = parser.Mode;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CmdParser_Exception_In_Case_Of_Non_Existent_File_For_Http_Mode()
        {
            var args = new string[2] { "http", "test-dir/non-existent-file.txt" };
            parser = new CmdParser(args);
            var dummy = parser.Mode;
        }

        [TestMethod]
        public void CmdParser_Happy_Path_For_Filesystem_Mode()
        {
            var args = new string[2] { "filesystem", "test-dir" };
            parser = new CmdParser(args);
            var dummy = parser.Mode;
        }

        [TestMethod]
        public void CmdParser_Happy_Path_For_Http_Mode()
        {
            var args = new string[2] { "http", "test-dir/remoteFiles.txt" };
            parser = new CmdParser(args);
            var dummy = parser.Mode;
        }
    }
}
