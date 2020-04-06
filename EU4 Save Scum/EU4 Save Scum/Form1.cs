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
        public string saveDirectory = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Paradox Interactive\Europa Universalis IV\save games\");
        public string selectedSave;
        private string selectedSaveNoExt;
        public string initHash = "";
        private string fileExt = ".eu4";
        public Form1()
        {

            InitializeComponent();
            addSaves();
            
       
        }
        private void addSaves()
        {
            SaveHandler newHandler = new SaveHandler();
            newHandler.getSaves(saveDirectory);
            string[] fileNames = newHandler.getSaves(saveDirectory);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void saveBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedSaveNoExt = saveBox.Text;
            selectedSave = saveBox.Text + fileExt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string curHash;
            bool hashChanged;
            SaveHandler SaveTick = new SaveHandler();
            ArchiveHandler ArchiveTick = new ArchiveHandler();
            if (initHash == "")
            {
                initHash = SaveTick.HashSaves(selectedSave);
                label1.Text = initHash;
                ArchiveTick.ArchiveFile(selectedSaveNoExt);
            }
            else
            {
                hashChanged = SaveTick.compareHash(saveDirectory, selectedSave);
                if (hashChanged == true)
                {
                    ArchiveTick.ArchiveFile(selectedSaveNoExt);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void refreshSaves_Tick(object sender, EventArgs e)
        {
            addSaves();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addSaves();
        }
    }
}
