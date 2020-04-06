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
        private string fileExt = ".eu4";
        public string saveDirectory = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\Paradox Interactive\\Europa Universalis IV\\save games\\";
        public void ArchiveFile(string file)
        {
            handleDirectory(file);
            string pathNoExtension = saveDirectory + file + fileExt;
            string newFolder = $"\\{file}\\";
            string newPath = saveDirectory + newFolder + file + getDate() + fileExt;
            try
            {
                File.Copy(pathNoExtension, newPath);
            }
            catch
            {

            }

        }
        public string getDate()
        {
            DateTime currentDate = DateTime.Now;
            string modDate = currentDate.ToString(" yyyy-MM-dd HHmm");
            return modDate;
        }
        public void handleDirectory(string saveName)
        {
            string archiveDir = saveDirectory + "\\" + saveName;
            if (Directory.Exists(archiveDir) == false)
            {
                Directory.CreateDirectory(archiveDir);
            }
        }

    }
}
