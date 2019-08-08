/*
 * Author: Matthew Powers
 * Class: CSI-256
 * Assignment: Async_Await
 * Date: 2/20/18
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
using System.IO;

namespace Async_Await_Powers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async Task<string> ReadToEndAsync()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string content = await sr.ReadToEndAsync();
                return content;
            }
            else return null;
            
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = await ReadToEndAsync();
        }
    }
}
