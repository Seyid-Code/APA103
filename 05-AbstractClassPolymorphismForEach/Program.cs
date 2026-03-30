using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportManagementSystem
{
    class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }
        public int MaxSpeed { get; set; }
        public Vehicle(string brand, string model, int year, string plateNumber, int maxSpeed)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.FuelLevel = 100;
            this.MaxSpeed = maxSpeed;
        }
        public string GetVehicleInfo()
        {
            return $"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate: {PlateNumber}, Fuel: {FuelLevel}%";
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine(GetVehicleInfo());
        }
    }
    class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public Car(string brand, string model, int year, string plateNumber, int doorsCount, int trunkCapacity, bool isAutomatic, int maxSpeed)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.DoorsCount = doorsCount;
            this.TrunkCapacity = trunkCapacity;
            this.IsAutomatic = isAutomatic;
        }
        public void ShowCarInfo()
        {
            Console.WriteLine($"{GetVehicleInfo()}, Doors: {DoorsCount}, Trunk: {TrunkCapacity}L, Automatic: {IsAutomatic}, MaxSpeed: {MaxSpeed} km/h");
        }
        public double CalculateFuelCost(double distance)
        {
            double consumptionPer100km = 8;
            double pricePerLiter = 1.50;
            return (distance / 100) * consumptionPer100km * pricePerLiter;
        }
    }
    class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public string Type { get; set; }
        public Motorcycle(string brand, string model, int year, string plateNumber, int engineCapacity, string type, bool hasSidecar, int maxSpeed)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.EngineCapacity = engineCapacity;
            this.Type = type;
            this.HasSidecar = hasSidecar;
        }
        public void ShowMotorcycleInfo()
        {
            Console.WriteLine($"{GetVehicleInfo()}, Engine: {EngineCapacity}cc, Type: {Type}, Sidecar: {HasSidecar}, MaxSpeed: {MaxSpeed} km/h");
        }
        public double CalculateFuelCost(double distance)
        {
            double consumptionPer100km = 4;
            double pricePerLiter = 1.50;
            return (distance / 100) * consumptionPer100km * pricePerLiter;
        }
    }
    class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }
        public Truck(string brand, string model, int year, string plateNumber, double cargoCapacity, int axleCount, double currentLoad, int maxSpeed)
            : base(brand, model, year, plateNumber, maxSpeed)
        {
            this.CargoCapacity = cargoCapacity;
            this.AxleCount = axleCount;
            this.CurrentLoad = currentLoad;
        }
        public void ShowTruckInfo()
        {
            Console.WriteLine($"{GetVehicleInfo()}, CargoCapacity: {CargoCapacity}t, Axles: {AxleCount}, CurrentLoad: {CurrentLoad}t, MaxSpeed: {MaxSpeed} km/h");
        }
        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad += weight;
                Console.WriteLine($"{weight} Ton Yuk Elave Olundu. Yeni Cari Yuk: {CurrentLoad}t");
            }
            else
            {
                Console.WriteLine($"Yuk Elave Edile Bilmez! Maksimum Tutum: {CargoCapacity}t");
            }
        }
        public double CalculateFuelCost(double distance)
        {
            double baseConsumption = 25;
            double extraPerTon = 2;
            double pricePerLiter = 1.80;
            double totalConsumption = baseConsumption + (CurrentLoad * extraPerTon);
            return (distance / 100) * totalConsumption * pricePerLiter;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Mercedes", "E200", 2023, "AA-1001", 4, 500, true, 220);
            Car car2 = new Car("BMW", "320i", 2022, "BB-2022", 4, 480, true, 235);
            Car car3 = new Car("Toyota", "Camry", 2021, "CC-3033", 4, 524, true, 210);
            List<Vehicle> vehicles = new List<Vehicle> { car1, car2, car3 };
            Motorcycle moto1 = new Motorcycle("Yamaha", "R1", 2023, "DD-4004", 998, "Sport", false, 299);
            Motorcycle moto2 = new Motorcycle("Harley-Davidson", "Street", 2022, "EE-5055", 1868, "Cruiser", true, 180);
            vehicles.Add(moto1);
            vehicles.Add(moto2);
            Truck truck1 = new Truck("MAN", "TGX", 2020, "FF-6066", 18, 3, 12, 120);
            Truck truck2 = new Truck("Volvo", "FH16", 2021, "GG-7077", 25, 4, 18, 110);
            vehicles.Add(truck1);
            vehicles.Add(truck2);
            Console.WriteLine("Car Info");
            foreach (var car in new List<Car> { car1, car2, car3 })
            {
                car.ShowCarInfo();
                Console.WriteLine($"500 km Yanacaq Xerci: {car.CalculateFuelCost(500):0.00} AZN\n");
            }
            Console.WriteLine("Motorcycle Info");
            foreach (var moto in new List<Motorcycle> { moto1, moto2 })
            {
                moto.ShowMotorcycleInfo();
                Console.WriteLine($"300 km Yanacaq Xerci: {moto.CalculateFuelCost(300):0.00} AZN\n");
            }
            Console.WriteLine("Truck Info");
            foreach (var truck in new List<Truck> { truck1, truck2 })
            {
                truck.ShowTruckInfo();
                Console.WriteLine($"800 km Yanacaq Xerci: {truck.CalculateFuelCost(800):0.00} AZN\n");
            }
            Console.WriteLine("Adding Cargo to First Truck");
            truck1.LoadCargo(5);
            Console.WriteLine($"800 km Yanacaq Xerci (Yeni Yuk): {truck1.CalculateFuelCost(800):0.00} AZN\n");
            Console.WriteLine("Statistics");
            int totalVehicles = vehicles.Count;
            double avgMaxSpeed = vehicles.Average(v => v.MaxSpeed);
            double maxFuelCost = vehicles.Max(v =>
            {
                if (v is Car c) return c.CalculateFuelCost(500);
                if (v is Motorcycle m) return m.CalculateFuelCost(300);
                if (v is Truck t) return t.CalculateFuelCost(800);
                return 0;
            });
            Vehicle mostExpensiveVehicle = vehicles.First(v =>
            {
                if (v is Car c) return c.CalculateFuelCost(500) == maxFuelCost;
                if (v is Motorcycle m) return m.CalculateFuelCost(300) == maxFuelCost;
                if (v is Truck t) return t.CalculateFuelCost(800) == maxFuelCost;
                return false;
            });
            Console.WriteLine($"Umumi Neqliyyat Sayi: {totalVehicles}");
            Console.WriteLine($"Orta Maksimum Suret: {avgMaxSpeed:0.0} km/h");
            Console.WriteLine($"En Bahalı Yanacaq Xerci: {mostExpensiveVehicle.Brand} {mostExpensiveVehicle.Model}, Xerc: {maxFuelCost:0.00} AZN");
        }
    }
}