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

namespace PowersMidTerm
{
    //Question 2:
    public delegate bool MyDelegate1(List<string> L1, string S1);
    public partial class Form1 : Form
    {
        //Question 2 and 3 string list to compare
        List<string> listOfStrings = new List<string>();

        public Form1()
        {
            InitializeComponent();
            preload();
        }

        //Question 2 and 3
        public void preload()
        {
            listOfStrings.Add("Yes");
            listOfStrings.Add("No");
            listOfStrings.Add("Maybe");
            listOfStrings.Add("dog");
            listOfStrings.Add("baby");
            listOfStrings.Add("meep");
            //Question 3 addition
            listOfStrings.Add("dog");
            listOfStrings.Add("meep");
            listOfStrings.Add("meep");
        }

        //Question 2 Continued:
        private void Button_Q2_Click(object sender, EventArgs e)
        {
            MyDelegate1 d1;
            d1 = new MyDelegate1(stringInStrings);
            rchtxtbxQ2.Clear();
            rchtxtbxQ2.AppendText(d1(listOfStrings, txtbxQ2.Text).ToString());
        }
        public bool stringInStrings(List<string> list, string matcher)
        {
            matcher = txtbxQ2.Text;
            foreach(string word in list)
            {
                if (word == matcher) return true;
            }
            return false;
        }

        //Question 3:
        private void Button_Q3_Click(object sender, EventArgs e)
        {
            MyDelegate1 d2;
            d2 = (list, matcher) =>
            {
                int counter = 0;
                foreach (string word in list)
                {
                    if (word == matcher) counter++;
                }
                if (counter >= 2) return true;
                else return false;
            };
            MessageBox.Show(d2(listOfStrings, txtbxQ3.Text).ToString());
        }

        //Question 1:
        //A delegate type signature is its return type and parameters

        //Question 4:
        public delegate bool Predicate<in word>(string Test);
        private void Button_Q4_Click(object sender, EventArgs e)
        {
            //Predicate<> d1;
        }

        //Question 5:
        public List<int> randNums()
        {
            Random rand = new Random();
            List<int> numList = new List<int>();
            for(int i = 0; i < 11; i++)
            {
                numList.Add(Math.Abs(rand.Next(0, 101)));
            }
            return numList;
        }
        private void Button_Q5_Click(object sender, EventArgs e)
        {
            List<int> list1 = randNums();
            List<int> list2 = randNums();
            string listText = "";
            Func<List<int>, List<int>, List<int>> delList = delegate (List<int> listnum1, List<int> listnum2)
            {
                List<int> list3 = new List<int>();
                for(int i = 0; i < list1.Count; i++)
                {
                    list3.Add(list1[i] + list2[i]);
                }
                return list3;
            };
            foreach(int num in delList(list1, list2))
            {
                listText += num.ToString() + " ";
            }
            MessageBox.Show(listText.ToString());
        }

        //Question 6
        Graphics g;
        int x1, y1;
        CancellationTokenSource cts = null;

        private void Button_Cancel_Q6_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }

        private void mouseDriver(object sender, MouseEventArgs e)
        {
            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task t1 = Task.Factory.StartNew(() =>
            {
                bool x = true;
                while (x == true)
                {
                    Random rand = new Random();
                    MouseButtons button = e.Button;
                    x1 = e.X;
                    y1 = e.Y;
                    //display a small filled circle
                    Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    Brush brush = new SolidBrush(randomColor);
                    int diameter = 4;
                    g.FillEllipse(brush, x1, y1, diameter, diameter);
                    if (token.IsCancellationRequested)
                    {
                        MessageBox.Show("random colors stopped");
                        token.ThrowIfCancellationRequested();
                    }
                }
            }, token);
        }


        private void Button_Q6_Click(object sender, EventArgs e)
        {
            //mouseDriver(panel1, e.MouseHover);
        }

        //Question 7:
        
        Liquid liquid = null;
        private void btnCreateLiquidClass_Click(object sender, EventArgs e)
        {
            if (liquid == null)
            {
                string liquidType;
                int initialTemp, threshold;
                liquidType = txtLiquidType.Text;
                int.TryParse(txtTemperature.Text, out initialTemp);
                int.TryParse(txtHeatThreshold.Text, out threshold);

                liquid = new Liquid(liquidType, initialTemp, threshold);

                liquid.OverHeat += new LiquidHandler(liquid_OverHeat);
            }
        }

        private void btnHeatLiquid_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(txtHeatLiquidByDegrees.Text, out amount);
            if(liquid != null)
            {
                liquid.HeatLiquid(amount);
                txtTemperature.Text = liquid.temperature.ToString();
            }
        }

        private void btnTurnOffHeat_Click(object sender, EventArgs e)
        {
            if (liquid.cts2 != null)
            {
                liquid.cts2.Cancel();
            }
        }

        private void liquid_OverHeat(object sender, LiquidEventArgs e)
        {
            string message = e.Message;
            int amount = e.Amount;
            MessageBox.Show("Message: " + message + "\n" + "Over heat by: " + amount);
        }

        //Question 8:
        //Keyboard events: KeyDown, KeyPress, and KeyUp
        private bool nonNumberEntered = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if(e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }


    }
}
