using System.IO;

namespace CityStats
{
    /// <summary>
    /// RAII class representing a new directory.
    /// </summary>
    public class TempDirectory
    {
        private readonly string name;
        
        public TempDirectory()
        {
            name = Extensions.GetRandomTempDirName();
            Directory.CreateDirectory(name);
        }
        
        public string Name
        {
            get
            {
                return name;
            }
        }
        
        ~TempDirectory()
        {
            Directory.Delete(name, true);
        }
    }
}
