using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CitiesMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add City", AddCity},
                {"Update City", UpdateCity},
                {"Delete City", DeleteCity},
                {"Show City", ShowCity},
                {"Show all Cities", ShowAllCities}
            };
            Menu(menu);
        }

        private static void AddCity(Dictionary<string, MenuList> menu)
        {
            try {
                var city = ObjectCreator.CreateCity();
                context.Cities.Add(city);
                context.SaveChanges();
                context.Entry(city).State = EntityState.Detached;
                Console.WriteLine("\nCity added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateCity(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter City ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var city = context.Cities.AsNoTracking().FirstOrDefault(t => t.CityId == id);
                city = ObjectCreator.CreateCity(city);
                context.Entry(city).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(city).State = EntityState.Detached;
                Console.WriteLine("\nCity updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {      
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteCity(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter City ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var city = context.Cities.Find(id);
                context.Cities.Remove(city);
                context.SaveChanges();
                Console.WriteLine("\nCity type deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowCity(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter City ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var city = context.Cities.AsNoTracking().FirstOrDefault(t => t.CityId == id);
                if (city == null)
                    throw new Exception("Element is not found.");
                Console.WriteLine(city);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllCities(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Cities list.\n");
                var cities = context.Cities.AsNoTracking().ToList();
                if (cities.Count == 0) Console.WriteLine("No elements found.");
                foreach (var city in cities) {
                    Console.WriteLine(city);
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
