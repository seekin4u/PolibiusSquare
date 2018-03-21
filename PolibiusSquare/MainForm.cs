using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace PolibiusSquare
{
    public partial class MainForm : Form
    {
        private static String inputString = "";

        private static String outputString = "";

        private static Char[,] Alphabet = {
                            {'A', 'B', 'C', 'D', 'E'},
                            {'F', 'G', 'H', 'I', 'K'}, //i is the same as j so we can skeep this leter
                            {'L', 'M', 'N', 'O', 'P'},
                            {'Q', 'R', 'S', 'T', 'U'},
                            {'V', 'W', 'X', 'Y', 'Z'}
                           };
        private bool isWrongSymbols = false;

        public MainForm()
        {
            InitializeComponent();
            Debug.WriteLine("Init");
            
        }


        private String Pdecrypt(String incommingMessage)
        {




            return "";
        }

        private void ParseStringBy2()
        {

        }
        private String Pencypt(String incomingMessage)//polibius encrypt
        {
            String bufferString = "";
            Debug.WriteLine("Entered pencrypt");
            foreach(char ch in incomingMessage)
            {
                bufferString += SearchIndexes(ch).ToString() + " ";
                Debug.Write(" " + SearchIndexes(ch).ToString());
            }
            return bufferString;
        }
 
        private int SearchIndexes(char inputChar)
        {
            int indexI, indexJ;
            int totalResult = 0;

            bool timeToStop = false;
            for(int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= 5; j++)
                {
                    if(inputChar == Alphabet[i - 1 , j - 1])
                    {
                        indexI = i;//Trust me
                        indexJ = j;//trust me2
                        totalResult = ConcatNumbers(indexJ , indexI);//trust me again, column and then is row
                        timeToStop = true;
                        
                    } else//didn't found any matchcasing - another symbols is WRONG
                    {

                    }
                    if (timeToStop)
                        break;

                }
                if (timeToStop)
                    break;
            }

            return totalResult;
        }

        private int ConcatNumbers(int firstInt, int secondInt)
        {
            String resultString = "error";
            int resultNumber = 0;
            String firstNumber = firstInt.ToString();
            String secondNumber = secondInt.ToString();

            resultString = firstNumber;
            resultString += secondNumber;
            resultNumber = Int32.Parse(resultString);
            /*if (resultNumber < 0)
            {
                Debug.WriteLine("char get fucked in ConcatNumbers!");
                return 0;
            }*/

            return resultNumber;
        }

        private void MainForm_Load(object sender , EventArgs e)
        {
            //TODO
        }

        private void encrytpButton_Click(object sender , EventArgs e)
        {
            Debug.WriteLine("entered encryptButton_Click");
            inputString = inputTextBox.Text;
            if (encryptCheckBox.Checked)//encrypting
            {
                String bufferString = inputTextBox.Text;
                bufferString = bufferString.Replace(" " , string.Empty);//Clearing spaces
                bufferString = bufferString.ToUpper();
                Debug.WriteLine("uppercased string without spaces :" + bufferString);

                outputString = Pencypt(bufferString);
                if (!isWrongSymbols)
                    outputTextBox.Text = outputString;
                else
                    outputTextBox.Text = "Wrong characters has been found in input string!";
                outputString = "";
            }
            else//decrypting
            {

            }
        }
    }
}
