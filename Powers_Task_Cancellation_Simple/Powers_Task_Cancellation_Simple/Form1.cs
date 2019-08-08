/* Author: Matthew Powers
 * Date 1/29/18
 * Class: CSI-256
 * Assignment: Task Cancellation
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
using System.IO;

namespace Powers_Task_Cancellation_Simple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //initiate list and cancelation token
        List<string> listOfWords = new List<string>();
        CancellationTokenSource cts = null;

        //method to write text
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
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        //Button click that creates the token, and starts the task, then writes out to the list box. If cancelation is requested by
        //pressing the other button, the task is stopped
        private void btnRunTask_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            

            Task t1 = Task.Factory.StartNew(() =>
            {
                StreamReader SR = new StreamReader(@"NorthwindDatabaseScript.txt");
                var lineCount = File.ReadLines(@"NorthwindDatabaseScript.txt").Count();
                for (int n = 0; n < lineCount; n++)
                {
                    listOfWords.Add(SR.ReadLine());
                }
                SR.Close();
                for(int i = 0; i < lineCount; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        SetText("Cancellation requested...");
                        token.ThrowIfCancellationRequested();
                    }
                    SetText(listOfWords[i].ToString());
                }
            }, token);
        }

        //Other button to stop the task from running
        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
