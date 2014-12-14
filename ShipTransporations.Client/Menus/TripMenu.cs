using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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
                context.Trips.Add(trip);
                context.SaveChanges();
                context.Entry(trip).State = EntityState.Detached;
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
                int id;
                Console.Write("Enter Trip ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var trip = context.Trips.AsNoTracking().FirstOrDefault(t => t.TripId == id);
                trip = ObjectCreator.CreateTrip(trip);
                context.Entry(trip).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(trip).State = EntityState.Detached;
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
                int id;
                Console.Write("Enter Trip ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var trip = context.Trips.Find(id);
                context.Trips.Remove(trip);
                context.SaveChanges();
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
                int id;
                Console.Write("Enter Trip ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var trip = context.Trips.AsNoTracking().FirstOrDefault(t => t.TripId == id);
                if (trip == null)
                    throw new Exception("Element is not found.");
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
                var trips = context.Trips.AsNoTracking().ToList();
                if (trips.Count == 0) Console.WriteLine("No elements found.");
                foreach (var trip in trips) {
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
