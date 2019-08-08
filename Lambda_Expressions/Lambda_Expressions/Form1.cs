using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lambda_Expressions
{
    //Delegate type for methods that takes an int and returns a bool
    public delegate bool MyPredicate(int x);
    public delegate bool MyPredicate2(int x, int y);
    public delegate double MyPredicate3(int[] x, int[] y);
    public partial class Form1 : Form
    {
        /*
         * lambda expressions is another form of writing anonymous methods:
         * 
         * syntax:
         * (input-parameters) => expression
         * 
         * or
         * 
         * (input-parameters) =>
         * {
         * 
         * };
         */
        MyPredicate d1, d2, d3;
        MyPredicate2 d4;
        MyPredicate3 d5;
        /*
         * Exercise:
         * 1: Define a delegate type that takes 2 ints and returns a bool
         * Declare a delegate object
         * create the delegate object to reference a lambda experssion that returns true when x is odd and positive AND y is at least twice x
         * 
         * 2: Define a delegate type that takes 2 arrays of ints and returns the average (as a double) of the first array
         * and the average of the second array.
         * Use a lambda expression when you create a delegate for this type.
         */
        private void btnEvenPositive_Click(object sender, EventArgs e)
        {
            int x;
            if(int.TryParse(txtInteger.Text, out x))
            {
                //invoke delegate object d3
                richTextBox1.Text = "Is the value " + x + " both even and positive? " + d3(x);
            }
        }

        public Form1()
        {
            InitializeComponent();
            //1: Create a delegate object to a named method
            //d1 = new MyPredicate(IsEvenPositive);
            //Or use a short-cut syntax
            d1 = IsEvenPositive;
            //2: Create a delegate to an anonymous method
            d2 = delegate (int x)
            {
                return x > 0 && x % 2 == 0;
            };
            //3: Create a delegate to a lambda expression
            d3 = x => x > 0 && x % 2 == 0;

            d4 = (x, y) => x > 0 && x % 2 == 1 && y >= Math.Pow(x, 2);

            d5 = (a, b) => (a.Average() + b.Average() / 2);
        }

        //named method:
        private bool IsEvenPositive(int x)
        {
            return x > 0 && x % 2 == 0;
        }
    }
}
