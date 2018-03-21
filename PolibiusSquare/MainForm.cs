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
            if (!(incommingMessage.Length % 2 == 0))
                return "Input must be correct! Invalid numbers count!";
            String parsedString = ParseStringBy2(incommingMessage);



            return parsedString;
        }

        private String ParseStringBy2(String StringToParse)
        {
            String bufferPair = "";
            String outputString = "";
            bool characterSkipped = false;
            for(int i = 1; i <= StringToParse.Length; i++)
            {
                bufferPair += StringToParse[i - 1];
                if(i%2 == 0)//means i = 2, i = 4, etc - we've read 2 symbols
                {
                    outputString += DeconcatString(bufferPair) + " ";
                    characterSkipped = true;
                }
                if (characterSkipped)
                {
                    bufferPair = "";//this is REAL buffer
                    characterSkipped = false;
                }
            }


            return outputString;
        }
        
        /// <summary>
        /// Принимает двухсимвольную строку.
        /// </summary>
        /// <param name="inputString">Двухсимвольная строка из простых чисел.</param>
        /// <returns>Возвращает асоциированный к этим двем числам символ из Aplhabet</returns>
        private String DeconcatString(String inputString)
        {//eg 32 is O, 23 is P
            if (inputString.Length != 2)
                return "_error_";

            Char outputChar;

            int first = Int32.Parse(inputString[1].ToString());
            int second = Int32.Parse(inputString[0].ToString());

            outputChar = Alphabet[first - 1, second - 1];

            Debug.WriteLine(" " + outputChar);
            return outputChar.ToString();
        }
        private String Pencypt(String incomingMessage)//polibius encrypt
        {
            String bufferString = "";
            Debug.WriteLine("Encrypt!");
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
                    if (inputChar == Alphabet[i - 1 , j - 1])
                    {
                        indexI = i;//Trust me
                        indexJ = j;//trust me2
                        totalResult = ConcatNumbers(indexJ , indexI);//trust me again, column and then is row
                        timeToStop = true;
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

            return resultNumber;
        }



        private void MainForm_Load(object sender , EventArgs e)
        {
            //TODO
        }

        private void encrytpButton_Click(object sender , EventArgs e) { 
      
            inputString = inputTextBox.Text;
            String bufferString = inputTextBox.Text;
            bufferString = bufferString.Replace(" " , string.Empty);//Clearing spaces in both variants
            Debug.WriteLine("bufferString : " + bufferString);

            if (encryptCheckBox.Checked)//encrypting
            {
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
                Debug.WriteLine("Decrypting;");
                outputString = Pdecrypt(bufferString);
                outputTextBox.Text = outputString;
                outputString = "";

            }
        }
    }
}
