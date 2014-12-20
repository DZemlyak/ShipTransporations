using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void TripsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Trip", AddTrip},
                {"Update Trip", UpdateTrip},
                {"Delete Trip", DeleteTrip},
                {"Show Trip", ShowTrip},
                {"Show all Trips", ShowAllTrips}
            };
            Menu(menu);
        }

        private static void AddTrip(Dictionary<string, MenuList> menu)
        {
            try {
                var trip = ObjectCreator.CreateTrip();
                var repository = new Repository<Trip>(new TripValidator());
                repository.Add(trip);
                Console.WriteLine("\nTrip added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateTrip(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Trip>(new TripValidator());
                var trip = repository.Read(id);
                trip = ObjectCreator.CreateTrip(trip);
                repository.Update(trip);
                Console.WriteLine("\nTrip updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteTrip(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Trip>(new TripValidator());
                var trip = repository.Read(id);
                repository.Delete(trip);
                Console.WriteLine("\nTrip deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void ShowTrip(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Trip>(new TripValidator());
                var trip = repository.Read(id);
                Console.WriteLine(trip);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllTrips(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Trips list.\n");
                var repository = new Repository<Trip>(new TripValidator());
                foreach (var trip in repository.ReadAll()) {
                    Console.WriteLine(trip);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
    }
}
