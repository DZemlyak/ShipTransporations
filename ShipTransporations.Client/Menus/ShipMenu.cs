using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void ShipsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Ship", AddShip},
                {"Update Ship", UpdateShip},
                {"Delete Ship", DeleteShip},
                {"Show Ship", ShowShip},
                {"Show all Ships", ShowAllShips}
            };
            Menu(menu);
        }

        private static void AddShip(Dictionary<string, MenuList> menu)
        {
            try {
                var ship = ObjectCreator.CreateShip();
                context.Ships.Add(ship);
                context.SaveChanges();
                context.Entry(ship).State = EntityState.Detached;
                Console.WriteLine("\nShip added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateShip(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Ship ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var ship = context.Ships.AsNoTracking().FirstOrDefault(t => t.ShipId == id);
                ship = ObjectCreator.CreateShip(ship);
                context.Entry(ship).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(ship).State = EntityState.Detached;
                Console.WriteLine("\nShip updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteShip(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Ship ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var ship = context.Ships.Find(id);
                context.Ships.Remove(ship);
                context.SaveChanges();
                Console.WriteLine("\nShip deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void ShowShip(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Ship ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var ship = context.Ships.AsNoTracking().FirstOrDefault(t => t.ShipId == id);
                if (ship == null)
                    throw new Exception("Element is not found.");
                Console.WriteLine(ship);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllShips(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Ships list.\n");
                var ships = context.Ships.AsNoTracking().ToList();
                if (ships.Count == 0) Console.WriteLine("No elements found.");
                foreach (var ship in ships) {
                    Console.WriteLine(ship);
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
