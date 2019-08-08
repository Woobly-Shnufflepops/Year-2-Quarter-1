using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI_256_Final_Review_Powers
{
    public class Car
    {
        private string _make;
        private string _model;
        private int _mileage;
        private int _year;
        private decimal _price;
        private int _customerID;

        public Car() { }
        public Car(string make, string model, int mileage, int year, decimal price, int customerID)
        {
            this._make = make;
            this._model = model;
            this._mileage = mileage;
            this._year = year;
            this._price = price;
            this._customerID = customerID;
        }

        public string Make
        { get { return this._make; } }

        public string Model
        { get { return this._model; } }

        public int Year
        { get { return this._year; } }

        public int Mileage
        { get { return this._mileage; } }

        public decimal Price
        { get { return this._price; } }

        public int CustomerID
        { get { return this._customerID; } }

        public string[] makes = { "Ford", "Honda", "Toyota", "Nissan" };
        public string[] fordModels = { "Focus", "Explorer", "Mustang", "Taurus", "Fiesta" };
        public string[] hondaModels = { "Civic Sedan", "Civic Coupe", "Accord Sedan", "CR_Z", "Element" };
        public string[] toyotaModels = { "Corolla", "Camry", "Matrix", "Avalon", "Tundra" };
        public string[] nissanModels = { "Altima", "Maxima", "Murano", "370Z", "Pathfinder", "Quest", "Sentra" };
    }
}