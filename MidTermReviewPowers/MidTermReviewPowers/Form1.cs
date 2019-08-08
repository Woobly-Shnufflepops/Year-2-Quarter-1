using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTermReviewPowers
{
    public partial class Form1 : Form
    {
        Predicate<string> d8;
        public Form1()
        {
            InitializeComponent();
            //Question 4 continued:
            d1 = smallestInt;
            //Questoin 5 continued: 
            d2 = (num1, num2, num3) =>
            {
                return num1 * num2 * num3;
            };
            //Question 6 continued:
            d3 = twoIsLessThanOne;
            //Question 7 continued:
            d4 = (num1, num2, num3) =>
            {
                if (num1 + num2 < num3) return true;
                else return false;
            };
            //Question 9:
            d6 = num =>
            {
                if (num % 5 == 0) return true;
                else return false;
            };

            //Question 11:
            d8 = e => e[1] == 'e';
        }
        //Question 11:
        List<string> cities = new List<string>() { "Renton", "Seattle", "New York", "London", "Moscow", "Beijin", "Olympia", "Tuckwilla", "Li Jang Tower" };
        
        //Question 1:
        //A delegate object is a reference to a method

        //Question 2:
        //The most important information a delegate type definition contains is its signature

        //Question 3:
        public delegate TResult MyGenDelegate<T1, T2, T3, TResult>(T1 a, T2 b, T3 c);

        //Question 4:
        MyGenDelegate<int, int, int, int> d1;

        public int smallestInt(int x, int y, int z)
        {
            //First block checks to see if all the numbers are different
            if (x != y && x != z && y != z)
            {
                if (x < y && x < z) return x;
                else if (y < x && y < z) return y;
                else return z;
            }
            //If it gets to here, then at least two of the numbers are equal to each other
            else if (x == y && x < z) return x;
            else if (x == y && x > z) return z;
            else if (x == z && x < y) return x;
            else if (x == z && x > y) return y;
            else if (y == z && y < x) return y;
            else if (y == z && y > x) return x;
            //If it gets here, then all numbers are equal to each other
            else return x;
        }

        //Question 5:
        MyGenDelegate<double, double, double, double> d2;

        //Question 6:
        MyGenDelegate<int, int, int, bool> d3;

        public bool twoIsLessThanOne(int x, int y, int z)
        {
            if (x + y < z) return true;
            else return false;
        }

        //Question 7:
        MyGenDelegate<int, int, int, bool> d4;

        //Question 8:
        Func<int, bool> d5 = delegate (int num)
        {
            if (num % 5 == 0) return true;
            else return false;
        };

        //Question 9:
        Func<int, bool> d6;

        //Question 10:
        Func<double, int, double> d7 = delegate (double num1, int num2)
        {
            return Math.Pow(num1, num2);
        };

        //Question 11:
        public List<string> citiesWithAnE(List<string> cities)
        {
            List<string> citiesWithE = cities.FindAll(city => city[1] == 'e');
            return citiesWithE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> eCities = citiesWithAnE(cities);
            foreach (string city in eCities)
            {
                MessageBox.Show(city);
            }
        }

        //Question 12:
        public List<string> citiesWith2Words(List<string> listOfCities)
        {
            List<string> twoWordCities = cities.FindAll(city => 
            {
                if(city.IndexOf(' ') == city.LastIndexOf(' ') && city.Contains(" "))
                {
                    return true;
                }
                return false;
            });
            return twoWordCities;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> twoCities = citiesWith2Words(cities);
            foreach(string city in twoCities)
            {
                MessageBox.Show(city);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtIntX.Text);
            int y = int.Parse(txtIntY.Text);
            int z = int.Parse(txtIntZ.Text);
            MessageBox.Show(string.Format("The smallest integer is: {0}", smallestInt(x, y, z)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double x = double.Parse(txtIntX.Text);
            double y = double.Parse(txtIntY.Text);
            double z = double.Parse(txtIntZ.Text);
            MessageBox.Show(string.Format("The product of X * Y * Z is: {0}", d2(x, y, z)));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtIntX.Text);
            int y = int.Parse(txtIntY.Text);
            int z = int.Parse(txtIntZ.Text);
            MessageBox.Show(string.Format("Is X + Y less than Z? {0}", d3(x, y, z)));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtIntX.Text);
            int y = int.Parse(txtIntY.Text);
            int z = int.Parse(txtIntZ.Text);
            MessageBox.Show(string.Format("Is X + Y less than Z? {0}", d4(x, y, z)));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(txtNum1.Text);
            MessageBox.Show(string.Format("Is num 1 divisible by 5? {0}", d5(num1)));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(txtNum1.Text);
            MessageBox.Show(string.Format("Is num 1 divisible by 5? {0}", d6(num1)));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double number1 = double.Parse(txtDouble1.Text);
            int number2 = int.Parse(txtInt1.Text);
            MessageBox.Show(string.Format("{0} to the power of {1} equals {2}", number1, number2, d7(number1, number2)));
        }
    }
}
