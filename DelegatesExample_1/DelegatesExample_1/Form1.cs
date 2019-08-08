using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegatesExample_1
{
    /*
     * A delegate is just a reference to a method.
     * Start by defining a delegate type (just as you do with classes)
     * (the syntax must have the keyword: delegate and must have the signature)
     * Example:
     */
    public delegate double MyDelegate1(double x, double y);
    //keyword delegate, followed by return type, then the name, and finally the parameter list
    //The return type and the parameters list form the signature
    /*
     * Objects of this delegate type can only reference mthods that return a double
     * and take two inputs of type double
     */

    public delegate int MyDelegate2(int[] array);
    public delegate bool MyDelegate3(int num);
    public partial class Form1 : Form
    {
        //Declare a delegate object
        MyDelegate1 d1;
        MyDelegate2 d2;
        MyDelegate2 d3;

        MyDelegate1 d4;
        MyDelegate2 d5;

        MyDelegate3 d6;
        MyDelegate3 d7;
        public Form1()
        {
            InitializeComponent();
            //create a delegate object d1
            d1 = new MyDelegate1(Add);
            d2 = new MyDelegate2(FirstOddPositive);
            d3 = new MyDelegate2(minMax);

            //let d4 reference an anonymous method
            d4 = delegate (double a, double b)
            {
                return a * b;
            };
            d5 = delegate (int[] a)
            {
                int value = 0;
                int counter = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > 0 && a[i] % 2 == 0)
                    {
                        value += a[i];
                        counter++;
                    }
                }
                return value / counter;
            };

            d6 = delegate (int nu)
            {
                if(nu > 0 && nu % 2 == 1)
                {
                    return true;
                }
                else return false;
            };

            d7 = delegate (int mu)
            {
                if (mu >= 50 && mu <= 100) return true;
                else return false;
            };
        }

        //method: with the same signature as MyDelegate1
        private double Add(double a, double b)
        {
            return a + b;
        }

        private int[] nums = { 18, 2, 4, 6, 9, 1, 57, 7 };

        private int FirstOddPositive(int[] a)
        {
            foreach(int x in a)
            {
                if (x > 0 && x % 2 == 1) return x;
            }
            return 0;
        }

        private int minMax(int[] b)
        {
            int min = 99999999;
            int max = 0;
            for(int i = 0; i < b.Length; i++)
            {
                if (b[i] < min) min = b[i];
                if (b[i] > max) max = b[i];
            }
            return (min + max) / 2;
        }

        private void btnCallDelegate_Click(object sender, EventArgs e)
        {
            //get two random values
            Random rand = new Random();
            double v1 = rand.Next();
            double v2 = rand.Next();

            //Invoke d1 delegate
            //When you invoke a delegate object, it will call all the methods it is referencing.
            //The syntax for invoking a delegate is similar to calling a method
            double result = d1(v1, v2);
            //Display
            richTextBox1.Text = v1 + " + " + v2 + " = " + result;
        }

        private void btnOddMethod_Click(object sender, EventArgs e)
        {
            int firstoddpositive = d2(nums);
            richTextBox1.Text = "First odd positive is: " + firstoddpositive;
        }

        private void btnMinMax_Click(object sender, EventArgs e)
        {
            int minMax = d3(nums);
            richTextBox1.Text = "The average of the min and max is: " + minMax;
        }

        private void btnDelegateDivider_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "The average of the even ints is: " + d5(nums);
        }

        private void btnNuAndMu_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Postive and odd? " + d6(79) + "\n" + "Between 50 and 100? " + d7(60);
        }



        //Exercise:
        //1: Define a delegate type that takes an array of ints and returns the first odd positive value
        //2: Create this delegate object
        //3: In a button invoke this delegate

        //Exercise pt2:
        //Create a delegate objcet d3 for a method that takes an array and returns the average of its max and min (let the average be an int)

        //Exercise pt3:
        //Create a delegate object from MyDelegate2 to reference an anonymous method that takes an array of ints and returns the average
        //(as an int) of all the even positive values
        //Add a button to test it

        //Exercise pt4:
        //Using anonymous methods: define a delegate type for methods that take an int and return a bool
        //Create two delegate objects to reference anonymous methods
        //First one reutrns true if input is positive and odd,
        //The second one returns true if input is between 50 and 100 inclusive (in both methods, try to write a single statement)
        //Test both methods in a single button
    }
}
