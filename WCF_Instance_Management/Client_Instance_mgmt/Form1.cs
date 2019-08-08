using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client_Instance_mgmt.ServiceReference1;

namespace Client_Instance_mgmt
{
    public partial class Form1 : Form
    {
        Service1Client proxy = new Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = proxy.GetNextCount();
            label1.Text = counter.ToString();
        }
    }
}
