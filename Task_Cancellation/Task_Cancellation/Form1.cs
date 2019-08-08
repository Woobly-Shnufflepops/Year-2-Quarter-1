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

namespace Task_Cancellation
{
    /*
     * Check MSDN documentation for task cancellation
     * 1: Need to create a CancellationTokenSource instance
     * 2: The CancellationTokenSource instance defines a property: Token
     * and a method to Cancel()
     * 3: (From a button) apply the Cancel() method to request that a task
     * cancels itself. THe Cancel method sets the Token to True
     * The task checks the Token property to find out if a
     * request for cancellation has been made.
     */
    
    public partial class Form1 : Form
    {
        CancellationTokenSource cts = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void SetText(string s)
        {
            if (listBox1.InvokeRequired)
            {
                Action<string> action = SetText;
                Invoke(action, s);
            }
            else
            {
                listBox1.Items.Add(s);
                //scroll down
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start a task using the overloaded StartNew method
            /*
             *  public Task StartNew
             *  (
	            Action action,
	            CancellationToken cancellationToken
                )
             */
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token; //used by the task

            Task t1 = Task.Factory.StartNew(() =>
            {
                double total = 0;
                Random rand = new Random();
                for (int n = 1; n < 100000000; n++)
                {
                    //check whether cancellation has been requested
                    //Option 1:
                    //Token.ThrowIfCancellationRequested();
                    //Option 2:
                    if (token.IsCancellationRequested)
                    {
                        //Do clean up. Such as closing resources
                        SetText("Cancellation requested...");
                        token.ThrowIfCancellationRequested();
                    }
                    total = +rand.Next();
                }
                SetText("Average = " + total / 100000000);
            }, token);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel task (request cancellation)
            if(cts != null)
            {
                cts.Cancel(); //Request to cancel
                //the cancel method causes the Token to be set to
                //true. It is up to the task to check the token
                //and exits.
            }
        }
    }
}
/*
 * Lab Assignment
 * Run a task that reads a long text file
 * provide a button to start the task
 * The task should check for cancellation, then before canceling, stops reading, closes the file, and then displays
 * only the content that has been read, if any
 * provide a button to cancel the task
 */
