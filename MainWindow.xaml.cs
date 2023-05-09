using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wordle
{
    public partial class MainWindow : Window
    {
        // array of letters a-z used to validate input
        string[] letters = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        TextBox[] txtBoxes;

        int intRow = 0;

        public MainWindow()
        {
            InitializeComponent();  

            // array of textboxes used as a reference
            txtBoxes = new TextBox[25]
            {
                txt1_1, txt1_2, txt1_3, txt1_4, txt1_5,
                txt2_1, txt2_2, txt2_3, txt2_4, txt2_5,
                txt3_1, txt3_2, txt3_3, txt3_4, txt3_5,
                txt4_1, txt4_2, txt4_3, txt4_4, txt4_5, 
                txt5_1, txt5_2, txt5_3, txt5_4, txt5_5
            };
        }

        // called whenever anything is typed into any textbox
        private void LetterEntered(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = (sender as TextBox);
            int intTxtIndex = Array.IndexOf(txtBoxes, txtBox);

            // clear text box and return if user is trying to enter something into a textbox but previous textboxes are still empty
            for (int i = 0; i < intTxtIndex; i++)
                if (txtBoxes[i].Text == "")
                {
                    txtBox.Clear();
                    return;
                }

            // ensure character entered was a letter, make sure textbox contains only one letter, capitalise letter entered
            if (!Validate(txtBox))
                return;



            // move cursor to next textbox unless at end of row, user must press enter
            if ((Array.IndexOf(txtBoxes, txtBox) + 1) % 5 != 0)
                txtBoxes[intTxtIndex + 1].Focus();

            else
                txtBox.CaretIndex = 1;
        }

        private bool Validate(TextBox txtBox)
        {
            int intLength = txtBox.Text.Length;
            
            // return if "" has just been entered to stop non-letter character
            if (intLength == 0)
                return false;
            
            string strEntered = txtBox.Text[intLength - 1].ToString();  //  get character just entered

            // don't allow non-letter character to be entered
            if (!letters.Contains(strEntered.ToLower()))
            {
                txtBox.Text = intLength == 2 ? txtBox.Text[0].ToString() : "";  // keep character already in textbox if it exists, otherwise relpace number with nothing
                txtBox.CaretIndex = 1;
                return false;
            }

            // removes old text when new letter is entered
            if (intLength > 1)
                txtBox.Text = strEntered.ToString();

            // capitalise letter in textbox
            txtBox.Text = txtBox.Text.Substring(0, 1).ToUpper();

            return true;
        }

        private void Key(object sender, TextCompositionEventArgs e)
        {
            // go to next line if user presses enter
            if (e.Text == "\r" && (sender as TextBox).Text != "")
            {
                intRow += 1;
                txtBoxes[intRow * 5].Focus();
            }
        }
    }
}
