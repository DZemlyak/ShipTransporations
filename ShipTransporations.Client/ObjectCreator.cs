using System;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    public static class ObjectCreator
    {
        public static Captain CreateCaptain(Captain cap = null)
        {
            Console.WriteLine("Type captain details.\n");
            
            Console.Write("ShipID: ");
            var temp = Console.ReadLine();
            var shipId = CheckInt(temp);
            
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();
            
            Console.Write("LastName: ");
            var lastName = Console.ReadLine();
            
            return cap != null 
                ? new Captain { CaptainId = cap.CaptainId, ShipId = shipId, FirstName = firstName, LastName = lastName } 
                : new Captain { ShipId = shipId, FirstName = firstName, LastName = lastName };
        }

        public static Cargo CreateCargo(Cargo cargo = null)
        {
            Console.WriteLine("Type cargo details.\n");
            
            Console.Write("TypeID: ");
            var temp = Console.ReadLine();
            var typeId = CheckInt(temp);
            
            Console.Write("TripID: ");
            temp = Console.ReadLine();
            var tripId = CheckInt(temp);

            Console.Write("Number: ");
            temp = Console.ReadLine();
            var number = CheckInt(temp);

            Console.Write("Weight: ");
            temp = Console.ReadLine();
            var weight = CheckInt(temp);

            Console.Write("Price: ");
            temp = Console.ReadLine();
            var price = CheckDouble(temp);

            Console.Write("InsurancePrice: ");
            temp = Console.ReadLine();
            var insPrice = CheckDouble(temp);

            return cargo != null 
                ? new Cargo { CargoId = cargo.CargoId, InsurancePrice = insPrice, 
                    Number = number, Price = price, TypeId = typeId,TripId = tripId, Weight = weight }
                : new Cargo { InsurancePrice = insPrice, Number = number, Price = price, 
                    TypeId = typeId, TripId = tripId, Weight = weight
            };
        }

        public static CargoType CreateCargoType(CargoType cargoType = null)
        {
            Console.WriteLine("Type CargoType details.\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            return cargoType != null 
                ? new CargoType { TypeId = cargoType.TypeId, Name = name } 
                : new CargoType {Name = name};
        }

        public static City CreateCity(City city = null)
        {
            Console.WriteLine("Type City details.\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            return city != null 
                ? new City { CityId = city.CityId, Name = name } 
                : new City { Name = name };
        }

        public static Port CreatePort(Port port = null)
        {
            Console.WriteLine("Type Port details.\n");

            Console.Write("CityID: ");
            var temp = Console.ReadLine();
            var cityId = CheckInt(temp);

            Console.Write("Name: ");
            var name = Console.ReadLine();

            return port != null 
                ? new Port{ Name = name, CityId = cityId, PortId = port.PortId } 
                : new Port{ Name = name, CityId = cityId };
        }

        public static Ship CreateShip(Ship ship = null)
        {
            Console.WriteLine("Type Ship details.\n");

            Console.Write("PortID: ");
            var temp = Console.ReadLine();
            var portId = CheckInt(temp);

            Console.Write("Number: ");
            temp = Console.ReadLine();
            var number = CheckInt(temp);

            Console.Write("Capacity: ");
            temp = Console.ReadLine();
            var capacity = CheckInt(temp);

            Console.Write("CreateDate: ");
            temp = Console.ReadLine();
            var createDate = CheckDate(temp);

            Console.Write("MaxDistance: ");
            temp = Console.ReadLine();
            var maxDistance = CheckInt(temp);

            Console.Write("CrewSize: ");
            temp = Console.ReadLine();
            var crewSize = CheckInt(temp);

            return ship != null
                ? new Ship {
                    Capacity = capacity, CreateDate = createDate, Number = number, PortId = portId, 
                    CrewSize = crewSize, MaxDistance = maxDistance, ShipId = ship.ShipId }
                : new Ship {
                    Capacity = capacity, CreateDate = createDate, Number = number, PortId = portId, 
                    CrewSize = crewSize, MaxDistance = maxDistance };
        }

        public static Trip CreateTrip(Trip trip = null)
        {
            Console.WriteLine("Type Trip details.\n");

            Console.Write("CaptainID: ");
            var temp = Console.ReadLine();
            var captainId = CheckInt(temp);

            Console.Write("ShipID: ");
            temp = Console.ReadLine();
            var shipId = CheckInt(temp);

            Console.Write("PortIDFrom: ");
            temp = Console.ReadLine();
            var portIdFrom = CheckInt(temp);

            Console.Write("PortIDTo: ");
            temp = Console.ReadLine();
            var portIdTo = CheckInt(temp);

            DateTime startDate, endDate;
            do {
                Console.Write("StartDate: ");
                temp = Console.ReadLine();
                startDate = CheckDate(temp);

                Console.Write("EndDate: ");
                temp = Console.ReadLine();
                endDate = CheckDate(temp);
            } while (startDate > endDate);
            
            return trip != null
                ? new Trip {
                    TripId = trip.TripId, CaptainId = captainId, ShipId = shipId, EndDate = endDate, PortIdFrom = portIdFrom,
                    PortIdTo = portIdTo, StartDate = startDate }
                : new Trip {
                    CaptainId = captainId, ShipId = shipId, EndDate = endDate, PortIdFrom = portIdFrom,
                    PortIdTo = portIdTo, StartDate = startDate };
        }

        private static int CheckInt(string temp) {
            int value;
            while (!int.TryParse(temp, out value) || value < 0) {
                Console.WriteLine("Can't be negative!");
                Console.Write("Type again: ");
                temp = Console.ReadLine();
            }
            return value;
        }

        private static double CheckDouble(string temp) {
            double value;
            while (!double.TryParse(temp, out value) || value < 0) {
                Console.WriteLine("Can't be negative!");
                Console.Write("Type again: ");
                temp = Console.ReadLine();
            }
            return value;
        }

        private static DateTime CheckDate(string temp)
        {
            DateTime value;
            while (!DateTime.TryParse(temp, out value))  {
                Console.WriteLine("It's not a date!");
                Console.Write("Type again: ");
                temp = Console.ReadLine();
            }
            return value;
        }

    }
}
