using System;
using System.Collections.Generic;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void ShipsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Ship", AddShip},
                {"Update Ship", UpdateShip},
                //{"Delete Ship", DeleteShip},
                {"Show Ship", ShowShip},
                {"Show all Ships", ShowAllShips}
            };
            Menu(menu);
        }

        private static void AddShip(Dictionary<string, MenuList> menu)
        {
            try {
                var ship = ObjectCreator.CreateShip();
                RepositoryHelper.ShipRepository.Create(ship);
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
                var ship = RepositoryHelper.ShipRepository.GetItem(id);
                ship = ObjectCreator.CreateShip(ship);
                RepositoryHelper.ShipRepository.Update(ship);
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
                var ship = RepositoryHelper.ShipRepository.GetItem(id);
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
                var ships = RepositoryHelper.ShipRepository.ReadAll();
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
