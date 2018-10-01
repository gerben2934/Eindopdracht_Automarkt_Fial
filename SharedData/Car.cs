using System;
using System.Collections.Generic;
using System.Text;


namespace SharedData
{

    public class Car
    {
        public enum Status { FORSALE, SOLD, REMOVED }
        public enum FuelType { GAS, ELECTRIC, DIESEL }

        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public Status CarStatus { get; set; }
        public FuelType CarFuelType { get; set; }
        public List<Bid> bids { get; }

        public Car(int carID, string brand, string model, string description, int mileage, string color, int year, Status status, FuelType fuelType)
        {
            this.CarID = carID;
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Mileage = mileage;
            this.Color = color;
            this.Year = year;
            this.CarStatus = status;
            this.CarFuelType = fuelType;
            //carbids = new List<Bid>();
        }

//        public override string ToString()
//        {
//            return $"carID: {CarID}\n, brand: {Brand}\n, model: {Model}\n, description: {Description}\n, mileage: {Mileage}\n, color: {Color}\n, year: {Year}\n, bids: {bids.Count()}.";
//        }


    }
}
