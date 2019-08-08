using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynchronousMethods_with_async_await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calls (synchronously) a long running method
            //this button does not exit until the method returns
            LongRunningMethod();
        }
        private void LongRunningMethod()
        {
            //Does some long running computation, then displays the result
            double total = 0;
            for(int i = 1; i < 1000000000; i++)
            {
                total += Math.Log(i);
            }
            //Display result
            richTextBox1.AppendText("From LongRunningMethod call synchronusly: \n" + total);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this button will call longRunningMethod that has been altered by adding an
            //internal task to execute the for loop
            longRunningMethod2();
        }

        //This method executes long running code in a task, but displays in the UI
        private void longRunningMethod2()
        {
            double total = 0;
            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 1000000000; i++)
                {
                    total += Math.Log(i);
                }
            });
            //part to display should be outside the task so that the UI displays the result
            //(no cross threading issues)
            //Problem: This method starts a task and right away moves on to display the total
            //which in most cases is 0.
            //Even though this method returns quickly, it does not display the right result
            richTextBox1.AppendText("from LongRunningMethod2 called synchronously: \n" + total);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LongRunningMethodAsync();
        }

        private async Task LongRunningMethodAsync()
        {
            //Execute the long running code in a task
            //display in the UI, but this time we'll ask the method to wait for the task to
            //complete before it moves on to display the total

            double total = 0;
            Task task = Task.Factory.StartNew(() =>
            {
                for (int i = 1; i < 1000000000; i++)
                {
                    total += Math.Log(i);
                }
            });
            //Causes method to wait at this point (but waiting would cause button2 to lock)
            //instead, we make the method wait and return back to the button. Then when this
            //task completes, it should come back again to this method to complete the display
            //code
            await task; //return back button2 (to allow button to be unlocked), but come back to
            //this point to complete the display code below
            richTextBox1.AppendText("from LongRunningMethod3 called synchronously: \n" + total);
        }

        int count = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            //Checks if UI is locked
            count++;
            label1.Text = count.ToString();
        }

        //========================================================================
        //Make a long running method that returns a value asynchronous using the await async keybowrd
        async private void button5_Click(object sender, EventArgs e)
        {
            double result = await LongRunningMethodWithReturnAsync();
            richTextBox1.AppendText(result.ToString());
        }
        //1: Long running method that returns a value
        private double LongRunningMethodWithReturn()
        {
            double total = 0;
            for (int x = 1; x < 100000000; x++)
            {
                total += Math.Log(x);
            }
            return total;
        }
        //Code, within the method that takes too long to run should be put in a task
        //redefine the method
        async private Task<double> LongRunningMethodWithReturnAsync()
        {
            
            Task<double> task = Task.Factory.StartNew<double>(() =>
            {
                double total = 0;
                for (int x = 1; x < 1000000000; x++)
                {
                    total += Math.Log(x);
                }
                return total;
            });
            //Cause it to return back to the button then come back to this point when
            //the task is finished
            await task;
            //Return the value from the task
            return task.Result; //Statement will block/not run until the task is finished
        }
    }
}
//Exercise:
/*
 * Define a method that takes a filename with a long list of numbers
 * The method is to read the entire file, add up al the numbers, and display the average
 * Call this method synchronously from a button
 * Define a second method that does exactly the same thing, but with async await so that
 * the method does not lock the button. Call this method from a second button
 */

//Lab assignment:
/*
 * Use a streamReader:
 * public override Task<string> ReadToEndAsync()
 * to read the content of a text file such as files with .cs extensions in a button click
 * provide a path to the text file
 * apply the ReadToEndAsync method
 * display the resulting string
 */