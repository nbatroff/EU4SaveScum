using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.IO.Compression;

namespace EU4_Save_Scum
{
    class ArchiveHandler
    {
        public string currentDirectory = Directory.GetCurrentDirectory();
        public string saveDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\Paradox Interactive\\Europa Universalis IV\\save games\\";
        public void RenameFile(string path)
        {
            string tpath = "C:\\Users\\nbatroff\\Documents\\Paradox Interactive\\Europa Universalis IV\\save games\\Aztec.eu4";
            string pathNoExtension = Path.GetFileNameWithoutExtension(tpath);
            string newPath = saveDirectory + pathNoExtension + " " + getDate() + ".eu4";
            File.Copy(tpath, newPath);
        }
        public void ArchiveFile(string file)
        {
           
        }
        public string getDate()
        {
            DateTime currentDate = DateTime.Now;
            string modDate = currentDate.ToString("yyyy-MM-dd HHmm");
            return modDate;
        }
    }
}
