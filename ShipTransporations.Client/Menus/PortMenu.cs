using System;
using System.Collections.Generic;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void PortsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Port", AddPort},
                {"Update Port", UpdatePort},
                //{"Delete Port", DeletePort},
                {"Show Port", ShowPort},
                {"Show all Ports", ShowAllPorts}
            };
            Menu(menu);
        }

        private static void AddPort(Dictionary<string, MenuList> menu)
        {
            try {
                var port = ObjectCreator.CreatePort();
                RepositoryHelper.PortRepository.Create(port);
                Console.WriteLine("\nPort added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdatePort(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Port ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var port = RepositoryHelper.PortRepository.GetItem(id);
                port = ObjectCreator.CreatePort(port);
                RepositoryHelper.PortRepository.Update(port);
                Console.WriteLine("\nPort updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowPort(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Port ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var port = RepositoryHelper.PortRepository.GetItem(id);
                Console.WriteLine(port);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllPorts(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Ports list.\n");
                var porrts = RepositoryHelper.PortRepository.ReadAll();
                if (porrts.Count == 0) Console.WriteLine("No elements found.");
                foreach (var port in porrts) {
                    Console.WriteLine(port);
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
