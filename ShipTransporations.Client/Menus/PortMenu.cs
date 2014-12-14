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
                context.Ports.Add(port);
                context.SaveChanges();
                context.Entry(port).State = EntityState.Detached;
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
                var port = context.Ports.AsNoTracking().FirstOrDefault(t => t.PortId == id);
                port = ObjectCreator.CreatePort(port);
                context.Entry(port).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(port).State = EntityState.Detached;
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
                int id;
                Console.Write("Enter Port ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var port = context.Ports.Find(id);
                context.Ports.Remove(port);
                context.SaveChanges();
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
                int id;
                Console.Write("Enter Port ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var port = context.Ports.AsNoTracking().FirstOrDefault(t => t.PortId == id);
                if (port == null)
                    throw new Exception("Element is not found.");
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
                var ports = context.Ports.AsNoTracking().ToList();
                if (ports.Count == 0) Console.WriteLine("No elements found.");
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
