using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void PortsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Port", AddPort},
                {"Update Port", UpdatePort},
                {"Delete Port", DeletePort},
                {"Show Port", ShowPort},
                {"Show all Ports", ShowAllPorts}
            };
            Menu(menu);
        }

        private static void AddPort(Dictionary<string, MenuList> menu)
        {
            try {
                var port = ObjectCreator.CreatePort();
                var repository = new Repository<Port>(new PortValidator());
                repository.Add(port);
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
                var id = GetEntityId();
                var repository = new Repository<Port>(new PortValidator());
                var port = repository.Read(id);
                port = ObjectCreator.CreatePort(port);
                repository.Update(port);
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

        private static void DeletePort(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Port>(new PortValidator());
                var port = repository.Read(id);
                repository.Delete(port);
                Console.WriteLine("\nPort deleted.");
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
                var id = GetEntityId();
                var repository = new Repository<Port>(new PortValidator());
                var port = repository.Read(id);
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
                var repository = new Repository<Port>(new PortValidator());
                var ports = repository.ReadAll();
                foreach (var port in ports) {
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
