using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EU4_Save_Scum
{
    public partial class Form1 : Form
    {
        public string[] backupSaves;
        public string[] savesNoNulls;
        public Form1()
        {
            SaveHandler newHandler = new SaveHandler();
            newHandler.getSaves();
            InitializeComponent();
            string[] fileNames = newHandler.getSaves();
            for (int i = 0; i < fileNames.Length; i++)
            {
                // Need to check if value is null. Length will be longer since Backup files are removed.
                if (fileNames[i] == null)
                {
                    break;
                }
                else
                {
                    savesCheckBox.Items.Add(fileNames[i]);
                    saveBox.Items.Add(fileNames[i]);
                }
            } 
            label2.Text = newHandler.fileName;
            label1.Text = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Europa Universalis IV\\save games" + newHandler.selectedSave);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* SaveHandler hashHandler = new SaveHandler();
            hashHandler.selectedSave = hashHandler.saveDir + "\\tigerZ.eu4";
            string save = hashHandler.saveDir + "\\tigerZ.eu4";
            label2.Text = hashHandler.firstHash(save); */
            ArchiveHandler aHandlder = new ArchiveHandler();
            aHandlder.RenameFile("test");
        }
    }
}
