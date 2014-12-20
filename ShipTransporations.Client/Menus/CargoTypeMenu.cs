using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
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
                var repository = new Repository<CargoType>(new CargoTypeValidator());
                repository.Add(cargoType);
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
                var id = GetEntityId();
                var repository = new Repository<CargoType>(new CargoTypeValidator());
                var cargoType = repository.Read(id);
                repository.Update(cargoType);
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
                var id = GetEntityId();
                var repository = new Repository<CargoType>(new CargoTypeValidator());
                var cargoType = repository.Read(id);
                repository.Delete(cargoType);
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
                var id = GetEntityId();
                var repository = new Repository<CargoType>(new CargoTypeValidator());
                var cargoType = repository.Read(id);
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
                var repository = new Repository<CargoType>(new CargoTypeValidator());
                foreach (var cargoType in repository.ReadAll()) {
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
