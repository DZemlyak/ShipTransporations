using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CargoTypesMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Cargo Type", AddCargoType},
                {"Update Cargo Type", UpdateCargoType},
                {"Delete Cargo Type", DeleteCargoType},
                {"Show Cargo Type", ShowCargoType},
                {"Show all Cargo Types", ShowAllCargoTypes}
            };
            Menu(menu);
        }

        private static void AddCargoType(Dictionary<string, MenuList> menu)
        {
            try {
                var cargoType = ObjectCreator.CreateCargoType();
                context.CargoTypes.Add(cargoType);
                context.SaveChanges();
                context.Entry(cargoType).State = EntityState.Detached;
                Console.WriteLine("\nCargoType added.");
            }
            catch (Exception ex) {
                
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateCargoType(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Cargo Type ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargoType = context.CargoTypes.AsNoTracking().FirstOrDefault(t => t.TypeId == id);
                if (cargoType == null)
                    throw new Exception("Element is not found.");
                cargoType = ObjectCreator.CreateCargoType(cargoType);
                context.Entry(cargoType).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(cargoType).State = EntityState.Detached;
                Console.WriteLine("\nCargo Type updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void DeleteCargoType(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Cargo Type ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargoType = context.CargoTypes.Find(id);
                context.CargoTypes.Remove(cargoType);
                Console.WriteLine("\nCargo type deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void ShowCargoType(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Cargo Type ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargoType = context.CargoTypes.AsNoTracking().FirstOrDefault(t => t.TypeId == id);
                if (cargoType == null)
                    throw new Exception("Element is not found.");
                Console.WriteLine(cargoType);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllCargoTypes(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Cargo Types list.\n");
                var cargoTypes = context.CargoTypes.AsNoTracking().ToList();
                if (cargoTypes.Count == 0) Console.WriteLine("No elements found.");
                foreach (var cargoType in cargoTypes) {
                    Console.WriteLine(cargoType);
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
