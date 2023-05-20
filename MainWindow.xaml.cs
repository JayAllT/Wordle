using System;
using System.Collections.Generic;
using System.IO;
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

        // foreground colours for text boxes
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);

        TextBox[] txtBoxes;

        int intRow = 0;  // keep track of what row user is currently on

        List<string> words = new List<string>();  // list of words
        string strWord;  // word user has to find

        bool booFinished = false;  // if wordle has been solved or all guesses were incorrect

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

            GetWords();
        }

        // get words from words.txt, choose word user must guess
        private void GetWords()
        {
            // add words from words.txt to words list
            string strChkWord;

            using (StreamReader reader = new StreamReader("words.txt"))
                while ((strChkWord = reader.ReadLine()) != null)
                    words.Add(strChkWord);

            NewWord();
        }

        // picks a new word
        private void NewWord()
        {
            Random rng = new Random();
            strWord = words[rng.Next(words.Count)];
        }

        // called whenever anything is typed into any textbox
        private void LetterEntered(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = (sender as TextBox);
            int intTxtIndex = Array.IndexOf(txtBoxes, txtBox);

            // return if word has been guessed
            if (booFinished)
                return;

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

        // check if enter is pressed in an end-of-row textbox
        private void Key(object sender, TextCompositionEventArgs e)
        {
            // return unless textbox has letter in it and the enter key was pressed
            if (e.Text != "\r" || (sender as TextBox).Text == "")
                return;
            
            intRow += 1;

            // go to next row if not already on last row
            if (intRow < 5)
                txtBoxes[intRow * 5].Focus();

            string strEntered = "";  // word just entered
            char chrCurrent;
            TextBox txtCurrent;

            // iterate through previous row, get word entered, and change background colours
            for (int i = 0; i < 5; i++)
            {
                txtCurrent = txtBoxes[(intRow - 1) * 5 + i];  // iterate through previous line
                chrCurrent = txtCurrent.Text.ToLower().ToCharArray()[0];  // text of current textbox

                strEntered += txtCurrent.Text.ToLower();  // get word just entered
            }

            Console.WriteLine(strWord);

            // background colours
            char[] letters = new char[5] { ' ', ' ', ' ', ' ', ' ' };  // letters in word, not including duplicates
            int[] letterCounts = new int[5] { 0, 0, 0, 0, 0 };  // counts of each letter
            int[] markedCounts = new int[5] { 0, 0, 0, 0, 0 };  // keep track of how many times each letter has been marked a colour, for example so that a letter that is found once in the real word but twice in the user's guess is not marked yellow twice

            for (int i = 0; i < 5; i++)
            {
                // add letter to letters if not already in there
                if (!letters.Contains(strWord[i]))
                    letters[i] = strWord[i];

                // increment count of letter
                letterCounts[Array.IndexOf(letters, strWord[i])] += 1;
            }

            // mark letters green
            int index;
            for (int i = 0; i < 5; i++)  // iterate through letters
            {
                // if letter is in correct place
                if (strEntered[i] == strWord[i])
                {
                    index = Array.IndexOf(letters, strEntered[i]);  // get index of letter in letters array

                    // mark textbox green, increment marked count so that if the letter is somewhere else, it isn't marked yellow
                    txtBoxes[(intRow - 1) * 5 + i].Background = green;
                    markedCounts[index]++;
                }
            }

            // mark letters yellow
            for (int i = 0; i < 5; i++)  // iterate through letters
            {
                // if letter is somewhere in word and hasn't already been marked green
                if (strWord.Contains(strEntered[i]) && txtBoxes[(intRow - 1) * 5 + i].Background != green)
                {
                    index = Array.IndexOf(letters, strEntered[i]);  // get index of letter in letters array

                    // mark letter yellow if it has not already been marked enough times, incrememnt marked count
                    if (markedCounts[index] < letterCounts[index])
                    {
                        markedCounts[index]++;
                        txtBoxes[(intRow - 1) * 5 + i].Background = yellow;
                    }
                }
            }

            // check if word is correct
            if (strEntered.Equals(strWord))
                Correct();

            // check if all guesses have been used
            else if (intRow == 5)
                Incorrect();
        }

        // if user guesses correct word
        private void Correct()
        {
            booFinished = true;

            // disable textboxes
            SetTextboxStates(false);

            // enable new word button
            btnReplay.IsEnabled = true;
        }

        // if user reaches end without guessing correct word
        private void Incorrect()
        {
            booFinished = true;

            SetTextboxStates(false);

            // display correct word
            lblOut.Content = $"Correct Word: {strWord.ToUpper()}";

            // enable new word button
            btnReplay.IsEnabled = true;
        }

        // set state of all textboxes to true or false
        private void SetTextboxStates(bool state)
        {
            foreach (TextBox box in txtBoxes)
                box.IsEnabled = state;
        }

        // reset game
        private void btnReplay_Click(object sender, RoutedEventArgs e)
        {
            intRow = 0;

            NewWord();

            // clear textboxes
            foreach ()
        }
    }
}
