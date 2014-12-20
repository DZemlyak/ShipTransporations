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

            if (cap == null)
                return new Captain { ShipId = shipId, FirstName = firstName, LastName = lastName };
            cap.ShipId = shipId;
            cap.FirstName = firstName;
            cap.LastName = lastName;
            return cap;
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

            if (cargo == null)
                return new Cargo { InsurancePrice = insPrice, Number = number, Price = price, 
                    TypeId = typeId, TripId = tripId, Weight = weight };

            cargo.InsurancePrice = insPrice;
            cargo.Number = number;
            cargo.Price = price;
            cargo.TypeId = typeId;
            cargo.TripId = tripId;
            cargo.Weight = weight;
            return cargo;
        }

        public static CargoType CreateCargoType(CargoType cargoType = null)
        {
            Console.WriteLine("Type CargoType details.\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            if (cargoType == null)
                return new CargoType { Name = name };

            cargoType.Name = name;
            return cargoType;
        }

        public static City CreateCity(City city = null)
        {
            Console.WriteLine("Type City details.\n");

            Console.Write("Name: ");
            var name = Console.ReadLine();

            if (city == null) return new City {Name = name};
            city.Name = name;
            return city;
        }

        public static Port CreatePort(Port port = null)
        {
            Console.WriteLine("Type Port details.\n");

            Console.Write("CityID: ");
            var temp = Console.ReadLine();
            var cityId = CheckInt(temp);

            Console.Write("Name: ");
            var name = Console.ReadLine();

            if (port == null)
                return new Port{ Name = name, CityId = cityId };

            port.Name = name;
            port.CityId = cityId;
            return port;
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

            if (ship == null)
                return new Ship {
                    Capacity = capacity,
                    CreateDate = createDate,
                    Number = number,
                    PortId = portId,
                    CrewSize = crewSize,
                    MaxDistance = maxDistance
                };

            ship.Capacity = capacity;
            ship.CreateDate = createDate;
            ship.Number = number;
            ship.PortId = portId;
            ship.CrewSize = crewSize;
            ship.MaxDistance = maxDistance;
            return ship;
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

            if (trip == null)
                return new Trip {
                    CaptainId = captainId, ShipId = shipId, EndDate = endDate, PortIdFrom = portIdFrom,
                    PortIdTo = portIdTo, StartDate = startDate };

            trip.CaptainId = captainId;
            trip.ShipId = shipId;
            trip.EndDate = endDate;
            trip.PortIdFrom = portIdFrom;
            trip.PortIdTo = portIdTo;
            trip.StartDate = startDate;
            return trip;
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
