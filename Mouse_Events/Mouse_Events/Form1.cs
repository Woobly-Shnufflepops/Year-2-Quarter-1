using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_Events
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x1, y1;
        public Form1()
        {
            InitializeComponent();
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            panel1.MouseUp += new MouseEventHandler(panel1_MouseUp);

            //create a graphics object for panel1
            g = panel1.CreateGraphics();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseButtons button = e.Button;
            x1 = e.X;
            y1 = e.Y;
            label1.Text = "x= " + x1 + "\n" + "y= " + y1 + "\n" + "button: " + button;
            //display a small filled circle
            if(e.Button == MouseButtons.Left)
            {
                Brush brush = new SolidBrush(Color.Purple);
                int diameter = 4;
                g.FillEllipse(brush, x1, y1, diameter, diameter);
            }
            
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseButtons button = e.Button;
            int x = e.X;
            int y = e.Y;
            label2.Text = "x= " + x + "\n" + "y= " + y + "\n" + "buttons: " + button;
            if (e.Button == MouseButtons.Left)
            {
                Brush brush = new SolidBrush(Color.Blue);
                int diameter = 4;
                g.FillEllipse(brush, x, y, diameter, diameter);
                Pen pen = new Pen(Color.Green);
                g.DrawLine(pen, x1, y1, e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Pen pen = new Pen(Color.Blue);
                g.DrawLine(pen, x1, y1, e.X, e.Y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            label2.Text = string.Empty;
        }
    }
}
//Exercise:
//Add MouseMove event that captures the x2 and y2 and draws a line only if the right button is used (assuming you used the left button for the previous example)
