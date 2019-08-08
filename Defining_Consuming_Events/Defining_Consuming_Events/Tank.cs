using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Consuming_Events
{
    //1: Before you define an event, you must define a delegate type
    //The signature of the delegate depends on the type of data you want
    //to send to the client when the event is sent.

    //Following .Net recommendations, the data should be encapsulated in
    //a class that inherits from the .Net class EventArgs

    public delegate void TankHandler(Object sender, TankEventArgs e);
    public class Tank
    {
        private int _currentLevel;
        private int _maxLevel;
        private int _minLevel;

        //Define an event. An event is considered
        //a property of a class. It should always be
        //declared as public
        //2: Define the event
        //Syntax: public event DelegateTypeName EventName
        public event TankHandler Overflow;
        public event TankHandler Underflow;

        public Tank(int currentLevel, int maxLevel, int minLevel)
        {
            _currentLevel = currentLevel;
            _maxLevel = maxLevel;
            _minLevel = minLevel;
        }
        public int CurrentLevel
        {
            get { return _currentLevel; }
        }
        //method to add water to the tank
        public void AddWater(int amount)
        {
            //as we add water, the current level could
            //exceed the maxLevel. At that point, we need
            //to alert or notify the client implies fire
            //the Overflow event, which invokes the delegate
            //object, and the delegate calls a method in the
            //client.

            if (amount + _currentLevel > _maxLevel)
            {
                if(Overflow != null) //check that a client has registered to this event
                {   
                    //We have exceeded the max, fire the event
                    int excess = Math.Abs(_maxLevel - (amount + _currentLevel));
                    string message = "Would cause the tank to overflow";
                    TankEventArgs te = new TankEventArgs(message, excess);
                    //Fire the event: same syntax as invoking a delegate
                    Overflow(this, te);
                }
            }
            else _currentLevel += amount;
        }

        //method to use or remove water from the tank
        public void UseWater(int amount)
        {
            if (_currentLevel - amount < _minLevel)
            {
                if (Underflow != null)
                {
                    int deficiency = _minLevel - (amount - _currentLevel);
                    string message = "Would cause the tank to underflow";
                    TankEventArgs te = new TankEventArgs(message, deficiency);
                    Underflow(this, te);
                }
            }
            else _currentLevel -= amount;
        }
    }
}
