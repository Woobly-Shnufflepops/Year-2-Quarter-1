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

namespace Powers_Task_Cancellation_Lab_Assignment
{
    public partial class Form1 : Form
    {
        string fileName = "";
        CancellationTokenSource cts = null;
        List<string> textToRead = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void openAndReadFile()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "e:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            fileName = openFileDialog1.FileName;
                            StreamReader textReader = new StreamReader(fileName);
                            FileInfo fi = new FileInfo(fileName);
                            for (int i = 0; i < fi.Length; i++)
                            {
                                textToRead.Add(i.ToString());
                            }
                            textReader.Close();

                            for(int j = 0; j < fi.Length; j++)
                            {
                                rchtxtbxFileOutput.AppendText(textToRead[j]);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            Task t1 = Task.Factory.StartNew(() =>
            {
                cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;

                if (token.IsCancellationRequested)
                {
                    rchtxtbxFileOutput.AppendText("Task canceld");
                    token.ThrowIfCancellationRequested();
                }
                openAndReadFile();
            });
            
        }


    }
}
