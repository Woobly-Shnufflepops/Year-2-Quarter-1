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

namespace Task_Exception_Handling
{
    public partial class Form1 : Form
    {
        /*
         * Handling exceptions thrown from tasks
         * When a task (or child task) throws an exception, the .Net
         * Task Manager creates an AggregationException (adds the 
         * exception thrown by the task, to the aggregationException),
         * and passes the aggregationException to the parent task or
         * main thread if it happens to be the parent.
         * 
         * To allow the system to throw an aggregationException, the
         * parent MUST use a Wait statement within a try catch block. 
         */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //example of a parent task with a single child task
            //thrwoing an exception
            Task parentTask = Task.Factory.StartNew(() =>
            {
                SetText("Parent starting...");
                //start a child task
                Task childTask = Task.Factory.StartNew(() =>
                {
                    SetText("Child task starting...");
                    Thread.SpinWait(1000000000);
                    SetText("Child task is about to throw an exception...");
                    Thread.SpinWait(1000000);
                    //Usually a task does not directly throw an exception.
                    //An exception occurs if something goes wrong within the
                    //child task. Here, we throw an exception to simulate
                    //such an action
                    throw new ArgumentException("Argument not valid... throw from childTask");
                    //The system creates an AggregationException, adds the ArgumentException
                    //to the AggregationException, and sends it to the parent task for that to 
                    //happen this task has to be specified as a child task, otherwise
                    //it will just be a nested or inner task
                }, TaskCreationOptions.AttachedToParent); //end of childTask
                //In the parent task, add the try catch block to respond to the
                //AggregationException. The try catch block must add the wait statement
                try
                {
                    childTask.Wait();
                }
                catch (AggregateException ae)
                {
                    //An exception in general contains a collection called InnerExceptions
                    //InnerExceptions can contain other exceptions. The system actually adds
                    //all the child exceptions to the innerExceptions of the AggregateException
                    SetText("Parent task catching exceptions: ");
                    foreach(Exception ex in ae.InnerExceptions)
                    {
                        SetText("Type: " + ex.GetType().Name + "\n" + "Message: " + ex.Message + "\n");
                    }
                }
            }); //end of parent Task
        }
        private void SetText(string text)
        {
            if (richTextBox1.InvokeRequired)
            {
                Action<string> action = SetText;
                this.Invoke(action, text);
            }
            else richTextBox1.AppendText(text + "\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task parentTask = Task.Factory.StartNew(() =>
            {
                SetText("Parent starting...");
                //start a child task
                Task childTask1 = Task.Factory.StartNew(() =>
                {
                    SetText("Child task 1 starting...");
                    Thread.SpinWait(1000000000);
                    SetText("Child task 1 is about to throw an exception...");
                    Thread.SpinWait(1000000);
                    throw new ArgumentException("Argument not valid... throw from childTask1");
                }, TaskCreationOptions.AttachedToParent); //end of childTask

                Task childTask2 = Task.Factory.StartNew(() =>
                {
                    SetText("Child task 2 starting...");
                    Thread.SpinWait(1000000000);
                    SetText("Child task 2 is about to throw an exception...");
                    Thread.SpinWait(1000000);
                    throw new IndexOutOfRangeException("Invalid Index... throw from childTask2");
                }, TaskCreationOptions.AttachedToParent); //end of childTask
                try
                {
                    Task.WaitAll(childTask1, childTask2);
            }
                catch (AggregateException ae)
                {
                    //An exception in general contains a collection called InnerExceptions
                    //InnerExceptions can contain other exceptions. The system actually adds
                    //all the child exceptions to the innerExceptions of the AggregateException
                    SetText("Parent task catching exceptions: ");
                    foreach (Exception ex in ae.InnerExceptions)
                    {
                        SetText("Type: " + ex.GetType().Name + "\n" + "Message: " + ex.Message + "\n");
                    }
                }
            });
            
        }
    }
}
