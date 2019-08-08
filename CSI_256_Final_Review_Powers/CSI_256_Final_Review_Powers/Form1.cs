using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSI_256_Final_Review_Powers
{
    public partial class Form1 : Form
    {
        List<Car> carList = new List<Car>();
        public Form1()
        {
            InitializeComponent();
            randomCars();
        }
        public void randomCars()
        {
            
            Random rand = new Random();
            Car randCar = new Car();
            //create 50 random cars
            for (int i = 0; i < 50; i++)
            {
                //get random year
                int year = rand.Next(2000, 2011);

                //get random mileage
                int mileage = rand.Next(20000) * (DateTime.Now.Year - year);

                //get random make
                string make = randCar.makes[rand.Next(4)];
                //get random model
                string model;
                //get random Price
                decimal price;

                switch (make)
                {
                    case "Ford":
                        model = randCar.fordModels[rand.Next(randCar.fordModels.Length)];
                        price = rand.Next(10000, 20000) * (decimal)Math.Pow(0.85, DateTime.Now.Year - year);
                        break;
                    case "Honda":
                        model = randCar.hondaModels[rand.Next(randCar.fordModels.Length)];
                        price = rand.Next(12000, 23000) * (decimal)Math.Pow(0.85, DateTime.Now.Year - year);
                        break;
                    case "Toyota":
                        model = randCar.toyotaModels[rand.Next(randCar.fordModels.Length)];
                        price = rand.Next(15000, 30000) * (decimal)Math.Pow(0.85, DateTime.Now.Year - year);
                        break;
                    case "Nissan":
                        model = randCar.nissanModels[rand.Next(randCar.fordModels.Length)];
                        price = rand.Next(12000, 25000) * (decimal)Math.Pow(0.85, DateTime.Now.Year - year);
                        break;
                    default:
                        model = "unknown";
                        price = 0;
                        break;
                }
                int custID = rand.Next(1, 10);
                carList.Add(new Car(make, model, mileage, year, price, custID));

            }//end of for loop
        }
}
