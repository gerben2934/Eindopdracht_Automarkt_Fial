using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static SharedData.Car;

namespace SharedData.Packets
{
    class CarMessage : IPacket
    {
        /**
        {
            "packetType" : "CarMessage",
            "object" : {
                "carId" : "12345",
                "carBrand" : "Toyota",
                "carModel" : "Yaris",
                "carDescription" : "Toyota Yaris 1.4",
                "carMileage" : "10000",
                "carYear" : "2014",
                "carStatus" : "FORSALE",
                "carFuelType" : "GAS",
            }
        }
        **/
        public Status Status { get; private set; }
        public FuelType FuelType { get; private set; }

        public Car Car { get; set; }

        public CarMessage(Car car)
        {
            this.Car = car;
        }

        public static IPacket ToClass(dynamic json)
        {
            int CarID = (int)json.data.carId;
            string Brand = (string)json.data.carBrand;
            string Model = (string)json.data.carModel;
            string Description = (string)json.data.carDescription;
            int Mileage = (int)json.data.carMileage;
            string Color = (string)json.data.carColor;
            int Year = (int)json.data.carYear;
            Status st;
            bool successSt = Enum.TryParse((string)json.data.carStatus, true, out st);
            FuelType ft;
            bool successFt = Enum.TryParse((string)json.data.carFuelType, true, out ft);
            if (successFt && successFt)
            {
                Car car = new Car(CarID, Brand, Model, Description, Mileage, Color, Year, st, ft);
                return new CarMessage(car);
            }
            else
                return null;
        }

        IPacket IPacket.ToClass(dynamic json)
        {
            return CarMessage.ToClass(json);
        }

        public dynamic ToJson()
        {
            dynamic json = new
            {
                packetType = nameof(CarMessage),
                data = new
                {
                    carId = Car.CarID,
                    carBrand = Car.Brand,
                    carModel = Car.Model,
                    carDescription = Car.Description,
                    carMileage = Car.Mileage,
                    carColor = Car.Color,
                    carYear = Car.Year,
                    carStatus = Status.ToString(),
                    carFuelType = FuelType.ToString()
                }
            };

            return JsonConvert.SerializeObject(json);
        }
    }
}
