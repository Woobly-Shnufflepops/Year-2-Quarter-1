using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Defining_Consuming_Events
{
    public partial class Form1 : Form
    {
        Tank tank = null;
        public Form1()
        {
            InitializeComponent();
            btnAddWater.MouseEnter += new EventHandler(btnAddWater_MouseEnter);
        }

        private void btnCreateNewTank_Click(object sender, EventArgs e)
        {
            if(tank == null)
            {
                int initialAmount, maxAmount, minAmount;
                int.TryParse(txtAmount.Text, out initialAmount);
                int.TryParse(txtMaxAmount.Text, out maxAmount);
                int.TryParse(txtMinAmount.Text, out minAmount);
                //Has not yet been created
                tank = new Tank(initialAmount, maxAmount, minAmount);
                //register this client to receive Overflow event from the tank object
                //1: Create a delegate object
                //TankHandler th = new TankHandler(tank_Overflow);
                //2: Add the delegate object to the event
                //tank.Overflow += th;

                //Replaced above steps 1 and 2 with a single statement
                tank.Overflow += new TankHandler(tank_Overflow);
                tank.Underflow += new TankHandler(tank_Underflow);

                //optional
                btnCreateNewTank.Enabled = false;
            }
        }
        //method that handles the Overflow event when it gets fired from the tank
        //Must have the same signature as the delegate type (TankHandler)
        private void tank_Overflow(Object sender, TankEventArgs e)
        {
            string message = e.Message;
            int excess = e.Amount;
            MessageBox.Show("Message: " + message + "\n" + "Excess: " + excess);
        }

        private void btnAddWater_Click(object sender, EventArgs e)
        {
            //get amount to be added
            int amount;
            int.TryParse(txtAmount.Text, out amount);
            //add it to the tank
            if(tank != null)//make sure the tank has been created
            {
                tank.AddWater(amount);
                //recall that this event, AddWater may fire an event when its
                //current level exceeds the max level

                //Display current level:
                txtCurrentLevel.Text = "Current level: " + tank.CurrentLevel + " gallons";
            }
        }

        private void tank_Underflow(Object sender, TankEventArgs e)
        {
            string message = e.Message;
            int deficency = e.Amount;
            MessageBox.Show("Message: " + message + "\n" + "Deficency: " + deficency);
        }
        //set up the method handler for the button MouseEnter
        private void btnAddWater_MouseEnter(Object sender, EventArgs e)
        {
            btnAddWater.Font = new Font("Arial", 18, FontStyle.Italic | FontStyle.Bold);
        }

        private void btnAddWater_MouseLeave(Object sender, EventArgs e)
        {
            btnAddWater.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        }

        private void btnUseWater_Click(object sender, EventArgs e)
        {
            int amount;
            int.TryParse(txtAmount.Text, out amount);
            if (tank != null)
            {
                tank.UseWater(amount);
                
                txtCurrentLevel.Text = "Current level: " + tank.CurrentLevel + " gallons";
            }
        }
    }
}
//Complete the project by adding a new event Underflow to the tank and fire this event when
//the water falls below the minLevel
//1: Add GUI to form1 to allow to use water
//2: Register form1 to receive Underflow event
//
//Likewise, add the MouseLeave event to the btnAddWater
//to restore the font back to it's original size