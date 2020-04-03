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
        public Form1()
        {
            InitializeComponent();
           
            label1.Text = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Paradox Interactive\\Europa Universalis IV\\save games");
        }
    }
}
