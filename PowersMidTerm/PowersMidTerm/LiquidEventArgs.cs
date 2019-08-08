using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowersMidTerm
{
    //Question 7:
    public class LiquidEventArgs : EventArgs
    {
        private string _message;
        private int _amount;

        public LiquidEventArgs(string message, int amount)
        {
            _message = message;
            _amount = amount;
        }

        public string Message { get { return _message; } }
        public int Amount { get { return _amount; } }
    }
}
