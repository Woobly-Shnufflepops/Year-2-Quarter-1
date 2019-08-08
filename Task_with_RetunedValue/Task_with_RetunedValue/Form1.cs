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

namespace Task_with_RetunedValue
{
    public partial class Form1 : Form
    {
        /*
         * if a method is running within a task and returns a value,
         * then use the Task<TResult> or Task.Factory<TResult>
         */
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRunTaskWithReturnValue_Click(object sender, EventArgs e)
        {
            Func<double> function = GetAverageOfRandoms;
            //Task<double> task1 = new Task<double>(function);
            //task1.Start();

            Task<double> task1 = Task.Factory.StartNew<double>(function);

            //Query the Result property of the Task<Result> to get the returned
            //value from the method
            double average = task1.Result;
            //the property Result blocks, meaning it will wait until the result
            //is returned from the task
            //Causes this button click to block as well, and lock the UI
            richTextBox1.Text = "Average = \n" + average;
        }
        private double GetAverageOfRandoms()
        {
            Random rand = new Random();
            double total = 0;
            int count = 1000000000;
            for(int i = 1; i <= count; i++)
            {
                total += rand.Next();
            }
            return total;
        }

        int counter = 0;

        private void btnUILockCheck_Click(object sender, EventArgs e)
        {
            //This button is used so the user can check whether the UI is
            //locked or not
            counter++;
            label1.Text = "X = " + counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func<double> function = GetAverageOfRandoms;
            Task<double> task1 = Task.Factory.StartNew<double>(function);
            //To make sure that the UI would not lock, you need to get the Result
            //from within a second task, when task1 completes. This is made possible
            //with the use of the ContinueWith(action<Task>) method that creates a
            //task when task1 has completed
            task1.ContinueWith(previousTask =>
            {
                //previousTask parameter is assigned the value task1 by the system.
                //It represents task1, use it to get the Result returned from task1
                //This method creates and starts a second task to avoid locking the
                //UI
                double average = task1.Result;
                richTextBox1.Text = "Average = \n" + average;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
