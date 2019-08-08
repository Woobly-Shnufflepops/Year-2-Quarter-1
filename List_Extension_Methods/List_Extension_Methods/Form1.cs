using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace List_Extension_Methods
{
    // IEnumerable class conatins a list of methods that apply
    // to any class that implements the interface IEnumerable<t>
    public partial class Form1 : Form
    {
        List<int> mainList = new List<int>();

        string[] stringArray = new string[] { "We", "Do", "Not", "Have", "Enough", "Vespene", "Gas", "Require", "Minerals",
            "You", "Know", "The", "Muffin", "Man", "pig", "dog", "woman", "body", "beep", "meep", "apple" };
        public Form1()
        {
            InitializeComponent();
            InitializeIntList();
            
        }

        private void InitializeIntList()
        {
            Random rand = new Random();
            for(int i = 1; i <= 100; i++)
            {
                mainList.Add(rand.Next(-999, 1000));
            }
        }

        private void btnFirstOddNegative_Click(object sender, EventArgs e)
        {
            /*
             * public T Find(Predicate<T> match)
             */
            Predicate<int> predicate = x => x < 0 && x % 2 != 0;
            int firstOddNegative = mainList.Find(predicate);
            MessageBox.Show(firstOddNegative.ToString());
        }

        private void btn7charAorB_Click(object sender, EventArgs e)
        {
            Predicate<string> predicate1 = word =>
            {
                return word.Length >= 7;
            };
            string sevenLongString = Array.Find(stringArray, predicate1);
            Predicate<string> predicate2 = characterStart =>
            {
                return characterStart.StartsWith("a") || characterStart.StartsWith("b");
            };
            string[] containsAorB = Array.FindAll(stringArray, predicate2);
            string words = "";
            foreach (string word in containsAorB)
            {
                words += word + " ";
            }
            MessageBox.Show(sevenLongString + "\n" + words);
        }
        
    }
    //Exercise:
    //Define a string array with at least 20 strings
    //use the Find method to return the first string that
    //has 7 or more characters
    //Use the FindAll to return all the strings that start
    //with 'a' or 'b'
}
