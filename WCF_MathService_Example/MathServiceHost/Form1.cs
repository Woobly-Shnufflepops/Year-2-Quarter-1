using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using MathServiceLib;

namespace MathServiceHost
{
    public partial class Form1 : Form
    {
        ServiceHost sh = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                //1: Set the address as a Uri object
                Uri baseAddress = new Uri("http://localhost:9999/MathService");
                //Create a ServiceHost
                sh = new ServiceHost(typeof(MathService), baseAddress);

                //Attach an EndPoint to this service host
                sh.AddServiceEndpoint(typeof(IMath), new BasicHttpBinding(), "Adder");
                //Allow metadata to be accessed by the client(s)
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                //Add this behavior to sh
                sh.Description.Behaviors.Add(smb);

                //Open the service
                sh.Open();
                label1.Text = "MathService is ready \n" + "http://localhost:9999/MathService";
            }
            catch (CommunicationException ce)
            {
                MessageBox.Show(ce.Message);
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (sh != null) sh.Close();
        }
    }
}
