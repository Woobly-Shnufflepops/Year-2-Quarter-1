/*
 * Author: Matthew Powers
 * Class: CSI-256
 * Assignment: Nested Tasks
 * Date: 1/31/18
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Nested_Tasks_Powers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Method that contains 4 tasks, 3 of which are nested. Generates random numbers, then returns the average
        private int nestedTasks()
        {
            //Defining counter and the random number generator. Counter will be used to find the average
            int counter = 0;
            Random rand = new Random();
            //The outer task which has inner tasks, returns an int
            Task<int> outerTask = Task.Factory.StartNew<int>(() =>
            {
                //First task, and all remaining tasks are the same.
                //Creates an int total, loops through adding random numbers between 0 and 100
                //and increases the counter as it loops, returns the total
                Task<int> nestedTask1 = Task.Factory.StartNew<int>(() =>
                {
                    int total = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        total += rand.Next(0, 101);
                        counter++;
                    }
                    return total;
                });

                Task<int> nestedTask2 = Task.Factory.StartNew<int>(() =>
                {
                    int total = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        total += rand.Next(0, 101);
                        counter++;
                    }
                    return total;
                });

                Task<int> nestedTask3 = Task.Factory.StartNew<int>(() =>
                {
                    int total = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        total += rand.Next(0, 101);
                        counter++;
                    }
                    return total;
                });
                //Grand total takes all the totals, then divides them by the counter to get the average
                int grandTotal = (nestedTask1.Result + nestedTask2.Result + nestedTask3.Result) / counter;
                return grandTotal;
            });
            //Returns the average of all the numbers
            return outerTask.Result;
            
        }

        //Prints/adds the results from nestedTasks() to the listbox
        private void btnPrintNums_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(nestedTasks());
        }
    }
}
