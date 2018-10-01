using System;
using System.Collections.Generic;
using System.Text;


namespace SharedData
{

    class Car
    {
        public int CarID { get; set; }
        public string Brand { get; }
        public string Model { get; }
        public string Description { get; set; }
        public int Mileage { get; }
        public string Color { get; set; }
        public int Year { get; }
        public Status Status { get; set; }
        public FuelType FuelType { get; }
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
            this.Status = status;
            this.FuelType = fuelType;
            bids = new List<Bid>();
        }

        public override string ToString()
        {
            return $"carID: {CarID}\n, brand: {Brand}\n, model: {Model}\n, description: {Description}\n, mileage: {Mileage}\n, color: {Color}\n, year: {Year}\n, Status: {Status}\n, fueltype: {FuelType}\n, bids: {bids.Count()}.";
        }

        public enum Status { ForSale, Sold }
        public enum FuelType { Gasoline, Diesel, Gas, Electric }

    }
}
