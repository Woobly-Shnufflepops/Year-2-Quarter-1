using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Consuming_Events
{
    public class TankEventArgs : EventArgs
    {
        private string _message;
        private int _amount;

        public TankEventArgs(string message, int amount)
        {
            _message = message;
            _amount = amount;
        }

        public string Message { get { return _message; } }
        public int Amount { get { return _amount; } }
    }
}
