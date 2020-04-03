using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EU4_Save_Scum
{
    class ArchiveHandler
    {
        public void RenameFile(string path)
        {
            string tpath = "C:\\Users\\nbatroff\\Documents\\Paradox Interactive\\Europa Universalis IV\\save games\\Aztec.eu4";
            var date = DateTime.Now;
            string newPath = tpath + "suckit"; // date.ToString();
            File.Copy(tpath, newPath);
        }
    }
}
