using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace EU4_Save_Scum
{
    class SaveHandler
    {
        
        public string saveDir = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paradox Interactive\Europa Universalis IV\save games\");
        public string saveHash;
        public string[] saveFiles;
        public string fileName;
        // public string[] nameArray;
        private MD5 md5 = MD5.Create();
        public string[] getSaves(string saveDir)
        {
            saveFiles = Directory.GetFiles(saveDir, "*.eu4");
            string[] saveArray = new String[saveFiles.Length];
            Regex patternFinder = new Regex("(_Backup)");
            int x = 0;
            for (int i = 0; i < saveFiles.Length; i++)
            {
                
                fileName = Path.GetFileNameWithoutExtension(saveFiles[i]);
                bool j = patternFinder.IsMatch(fileName);
                if (j == false)
                {
                    saveArray[x] = fileName;
                    x++;
                }
            }  
            return saveArray;
        }
        public byte[] MD5Hash(string filename)
        {
            var path = Path.Combine(saveDir, filename);
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
        public static string bytesToString(byte[] bytes)
        {
            string results ="";
            foreach (byte b in bytes) results += b.ToString("x2");
            return results;
        }
        public bool compareHash(string saveDir, string selectedSave)
        {
            // TO DO: Needs to be written..
            string hashResults = bytesToString(MD5Hash(saveDir + selectedSave));
            if (saveHash == null)
            {
                saveHash = bytesToString(MD5Hash(saveDir + selectedSave));
            }
            if (hashResults == saveHash)
            {
                return true;
            }
            else { return false; }

        }
        public string HashSaves(string filename)
        {
            string initHash = bytesToString(MD5Hash(filename));
            return initHash;

        }
    }
}
