using System;
using System.Collections.Generic;
using ShipTransportations.Model.Repository;

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
                RepositoryHelper.CargoTypesRepository.Create(cargoType);
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
                var cargoType = RepositoryHelper.CargoTypesRepository.GetItem(id);
                cargoType = ObjectCreator.CreateCargoType(cargoType);
                RepositoryHelper.CargoTypesRepository.Update(cargoType);
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
                RepositoryHelper.CargoTypesRepository.Delete(id);
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
                var cargoType = RepositoryHelper.CargoTypesRepository.GetItem(id);
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
                var cargoTypes = RepositoryHelper.CargoTypesRepository.ReadAll();
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
