using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_Delegates
{
    /*
     * Generic Delegates
     */
    //Delegate that takes 2 doubles and returns a double
    public delegate double MyDelegate1(double a, double b);
    //Delegate that takes 2 ints and returns a dobule
    public delegate double MyDelegate2(int a, int b);
    //Delegate that takes 2 ints and returns a bool
    public delegate bool MyDelegate3(int a, int b);
    //
    public delegate double MyDelegate4(float a, int b);

    //All the above delegate types can be replaced by a single generic delegate
    public delegate TResult MyGenDelegate<T1, T2, TResult>(T1 a, T2 b);
    public partial class Form1 : Form
    {
        //Define a delegate object for the IsGreater method using the generic delegate
        MyGenDelegate<int, int, bool> d1;
        MyGenDelegate<int, int, double> d2;
        MyGenDelegate<int[], int, int> d3;
        MyGenDelegate<int[], int[], double> d4;

        Func<int[], int[], double> maxAverage;
        Predicate<int> prediacte1;
        Func<int, int, int> largest;
        //Exercise: Delegate object for a lambda expression that takes 2 arrays
        //and returns the average of their max values
        //--------------------------------------------------
        //Repeat the same thing using the .net Func<> delegate type
        //Use .Net Predicate for lambda experssions that:
        //1: Returns true if input is odd
        //2: Returns true if input is even and negative
        //
        //Use Action delegate that takes 2 inputs and displays the largest one
        public Form1()
        {
            InitializeComponent();
            d1 = IsGreater;
            d2 = Average;
            //Assign d3 to a lambda expresssion that returns the index of 
            //the second parameter within the array
            d3 = (array, x) =>
            {
                for(int i = 0; i < array.Length; i++)
                {
                    if (array[i] == x) return i;
                }
                return -1;
            };

            d4 = (array1, array2) => (array1.Max() + array2.Max()) / 2;

            maxAverage = (array1, array2) =>
            {
                return (array1.Max() + array2.Max()) / 2;
            };

            prediacte1 = x => x % 2 == 1;

            prediacte1 = y => y % 2 == 0 && y < 0;

            largest = (x, y) =>
            {
                if (x > y) return x;
                else return y;
            };
        }

        private bool IsGreater(int x, int y)
        {
            return x > y;
        }
        private double Average(int x, int y)
        {
            double avg = (x + y);
            return avg / 2;
        }

        
    }
}
