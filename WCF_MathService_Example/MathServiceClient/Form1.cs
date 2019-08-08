using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathServiceClient.ServiceReference1;

namespace MathServiceClient
{
    public partial class Form1 : Form
    {
        //Declare/create the proxy object
        //Proxy: MathClient
        MathClient proxy = new MathClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int v1 = int.Parse(txtValue1.Text);
                int v2 = int.Parse(txtValue2.Text);

                //Call the proxy to add
                int result = proxy.Add(v1, v2);

                //Display
                label3.Text = string.Format("{0} + {1} = {2}", v1, v2, result);
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }
    }
}
/*
 * Add-ons
 * Add more functions to the MathServiceLibrary
 * Ability to compute Power of 2 values (v1 to the power of v2)
 * Ability to compute the square root of a value
 * Ability to computer the log of a value
 * 
 * Rebuild server app
 * Create new client app to use all the services provided by the updated Math library
 * 
 * Next: A look at passing (serializing) objects between the server and the client
 */
