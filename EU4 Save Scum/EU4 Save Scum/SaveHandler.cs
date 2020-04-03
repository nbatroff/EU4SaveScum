using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EU4_Save_Scum
{
    class SaveHandler
    {
        private string saveDir = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Europa Universalis IV\\save games");
        public string selectedSave;
        public string saveHash;
        public string[] saveFiles;
        public string[] getSaves()
        {
            string[] saveFiles = Directory.GetFiles(saveDir, "*.eu4");
            return saveFiles;
        }
        public void hashSaves()
        {
         
        }
    }
}
