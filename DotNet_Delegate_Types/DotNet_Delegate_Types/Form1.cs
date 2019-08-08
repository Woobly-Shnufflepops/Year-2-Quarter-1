using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNet_Delegate_Types
{
    public partial class Form1 : Form
    {
        //Use a Func<...> delegate type  for the GetPositives method
        Func<List<int>, List<int>> function1;
        Func<string[], List<string>> function2;
        Predicate<int> predicate1;
        /*
         * .Net Generic Delegate Types
         * ================================
         * Action<...> delegate type
         * 
         */
        public Form1()
        {
            InitializeComponent();
            //Create function 1 delegate object
            function1 = GetPositives;

            //Create a delegate type for a lambda expression
            //that takes an array of strings and returns a LIst of
            //all the string items that starts with the letter 'a'
            function2 = array =>
            {
                List<string> tempList = new List<string>();
                foreach(string s in array)
                {
                    if (s.StartsWith("a", StringComparison.CurrentCultureIgnoreCase))
                    {
                        tempList.Add(s);
                    }
                }
                return tempList;
            };

            //Use .Net delegate type for a lambda expression that takes an int
            //and returns true if the int value is negative and even

            predicate1 = x => x < 0 && x % 2 == 0;
        }

        //Named method
        private List<int> GetPositives(List<int> list)
        {
            List<int> tempList = new List<int>();
            foreach(int x in list)
            {
                if (x > 0) tempList.Add(x);
            }
            return tempList;
        }
    }
}
