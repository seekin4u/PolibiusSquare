#define DEB

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PolibiusSquare
{
    public partial class MainForm : Form
    {
        String inputString = "";
        String outputString = "";

        public MainForm()
        {
            InitializeComponent();
            Debug.WriteLine("Init");
            
        }

        private void MainForm_Load(object sender , EventArgs e)
        {

        }

        private void encrytpButton_Click(object sender , EventArgs e)
        {
            inputString = Text;

            String bufferString = Text;



            outputString = bufferString;
        }
    }
}
