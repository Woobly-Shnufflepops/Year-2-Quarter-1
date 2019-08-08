using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Domain_Name_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLocalComputer_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                string localName = Dns.GetHostName();
                richTextBox1.Text = "Local computer name: " + localName + "\n";
                //get IPAddress of the local computer
                IPAddress[] ipAddress = await Dns.GetHostAddressesAsync(localName);
                //the await causes the button to exit temporarly. This will allow other
                //buttons to function. When the result is returned by the method, the
                //system sneds the control back to this button to resume from where it
                //left off
                foreach(IPAddress ipadd in ipAddress)
                {
                    richTextBox1.AppendText(ipadd + "\n");
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private async void btnGetIPAddresses_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                string domainName = txtDomainName.Text;
                IPAddress[] ipAddress = await Dns.GetHostAddressesAsync(domainName);
                
                foreach (IPAddress ipadd in ipAddress)
                {
                    richTextBox1.AppendText(ipadd + "\n");
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
    }
}
/*
 * Reading:
 * Read the Socket Class on how to create a socket, bind it to an IP Address, then send
 * data to a client and receive data from the client
 */
