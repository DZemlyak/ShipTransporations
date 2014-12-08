using System;
using System.Collections.Generic;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void TripsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Trip", AddTrip},
                {"Update Trip", UpdateTrip},
                //{"Delete Trip", DeleteTrip},
                {"Show Trip", ShowTrip},
                {"Show all Trips", ShowAllTrips}
            };
            Menu(menu);
        }

        private static void AddTrip(Dictionary<string, MenuList> menu)
        {
            try {
                var trip = ObjectCreator.CreateTrip();
                RepositoryHelper.TripRepositiry.Create(trip);
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
                var trip = RepositoryHelper.TripRepositiry.GetItem(id);
                trip = ObjectCreator.CreateTrip(trip);
                RepositoryHelper.TripRepositiry.Update(trip);
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
                var trip = RepositoryHelper.TripRepositiry.GetItem(id);
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
                var trips = RepositoryHelper.TripRepositiry.ReadAll();
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
