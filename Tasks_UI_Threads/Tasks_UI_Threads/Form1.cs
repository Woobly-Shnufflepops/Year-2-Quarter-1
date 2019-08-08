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

namespace Tasks_UI_Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //synchronous call to ComputeTask1
            //ComputeTask1();
            //make asynchronous call to ComputeTask1
            //Task t1 = new Task(() => ComputeTask1());
            Task t1 = Task.Factory.StartNew(() => ComputeTask1());
        }
        private void ComputeTask1()
        {
            Random rand = new Random();
            double total = 0;
            for(int i = 1; i<=1000000000; i++)
            {
                total += rand.Next();
            }
            SetText("Task 1: " + total.ToString("f0"));
        }
        //method to resolve cross-threading problems
        private void SetText(string s)
        {
            if (richTextBox1.InvokeRequired)
            {
                //create a delegate object. THe delegate type to use should have
                //the same signature as this method
                //you could define your own custom delegate type or use .Net predefined type
                Action<string> action = SetText;
                Invoke(action, s);
            }
            else
            {
                richTextBox1.AppendText(s + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task t2 = Task.Factory.StartNew(() =>
            {
                Random rand = new Random();
                double total = 0;
                for (int i = 1; i <= 100000000; i++)
                {
                    total += rand.Next();
                }
                SetText("Task 2: " + total.ToString("f0"));
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = int.Parse(label1.Text);
            count++;
            label1.Text = count.ToString();
        }
    }
}
