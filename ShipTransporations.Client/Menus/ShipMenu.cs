using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

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
                var repository = new Repository<Ship>(new ShipValidator());
                repository.Add(ship);
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
                var id = GetEntityId();
                var repository = new Repository<Ship>(new ShipValidator());
                var ship = repository.Read(id);
                ship = ObjectCreator.CreateShip(ship);
                repository.Update(ship);
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
                var id = GetEntityId();
                var repository = new Repository<Ship>(new ShipValidator());
                var ship = repository.Read(id);
                repository.Delete(ship);
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
                var id = GetEntityId();
                var repository = new Repository<Ship>(new ShipValidator());
                var ship = repository.Read(id);
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
                var repository = new Repository<Ship>(new ShipValidator());
                foreach (var ship in repository.ReadAll()) {
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
