using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PowersMidTerm
{
    //Question 7:
    public delegate void LiquidHandler(Object sender, LiquidEventArgs e);
    public class Liquid
    {
        private string _liquidtype;
        private int _tempature;
        private int _highThreshold;

        public string liquidtype { get { return _liquidtype; } }
        public int temperature
        {
            get { return _tempature; }
            set { _tempature = value; }
        }
        public int highThreshold { get { return _highThreshold; } }

        public event LiquidHandler OverHeat;

        public Liquid(string LiquidType, int Temperature, int HighThreshold)
        {
            _liquidtype = LiquidType;
            _tempature = Temperature;
            _highThreshold = HighThreshold;
        }
        
        public CancellationTokenSource cts2 = null;
        
        public void HeatLiquid(int amount)
        {
            cts2 = new CancellationTokenSource();
            CancellationToken token = cts2.Token;
            Task t1 = Task.Factory.StartNew(() =>
            {

                while(temperature <= highThreshold)
                {
                    temperature += amount;
                    if (temperature > highThreshold)
                    {
                        if(OverHeat != null)
                        {
                            int tooHotBy = highThreshold - temperature;
                            string message = "Warning: Temperature Exceeded";
                            LiquidEventArgs le = new LiquidEventArgs(message, tooHotBy);
                            OverHeat(this, le);
                        }
                        
                    }
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    Thread.Sleep(1000);
                }
                
            }, token);
        }
    }
}
