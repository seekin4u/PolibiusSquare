using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace PolibiusSquare
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле, содержащее изначальный вариант входного текста.
        /// </summary>
        private static String inputString = "";

        /// <summary>
        /// Поле, содержащее окончательный вариант выходного текста.
        /// </summary>
        private static String outputString = "";

        /// <summary>
        /// Массив, содержащий в себе символы алфавита, который будет тешифроваться
        /// </summary>
        private static Char[,] Alphabet = {
                            {'A', 'B', 'C', 'D', 'E'},
                            {'F', 'G', 'H', 'I', 'K'}, //i is the same as j so we can skeep this leter
                            {'L', 'M', 'N', 'O', 'P'},
                            {'Q', 'R', 'S', 'T', 'U'},
                            {'V', 'W', 'X', 'Y', 'Z'}
                           };

        public MainForm()
        {
            InitializeComponent();
            Debug.WriteLine("Init");
            
        }

        private void pencypt(String incomingMessage)//polibius encrypt
        {
            Debug.WriteLine("Entered pencrypt");
        }


        private void MainForm_Load(object sender , EventArgs e)
        {
            //TODO
        }

        private void encrytpButton_Click(object sender , EventArgs e)
        {
            Debug.WriteLine("entered encryptButton_Click");
            inputString = inputTextBox.Text;

            String bufferString = inputTextBox.Text;
            bufferString = bufferString.Replace(" " , string.Empty);//Clearing spaces
            bufferString = bufferString.ToUpper();
            Debug.WriteLine("uppercased string without spaces :" + bufferString);

            outputString = bufferString;
        }
    }
}
