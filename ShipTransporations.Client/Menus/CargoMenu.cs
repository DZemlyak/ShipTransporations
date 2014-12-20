using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CargosMenu(Dictionary<string, MenuList> menu) {
            menu = new Dictionary<string, MenuList> {
                {"Add Cargo", AddCargo},
                {"Update Cargo", UpdateCargo},
                {"Delete Cargo", DeleteCargo},
                {"Show Cargo", ShowCargo},
                {"Show all Cargos", ShowAllCargos}
            };
            Menu(menu);
        }
        
        private static void AddCargo(Dictionary<string, MenuList> menu)
        {
            try {
                var cargo = ObjectCreator.CreateCargo();
                var repository = new Repository<Cargo>(new CargoValidator());
                repository.Add(cargo);
                Console.WriteLine("\nCargo added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally { 
                Console.WriteLine("\nPress any button."); 
                Console.ReadKey(); 
            }
        }

        private static void UpdateCargo(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Cargo>(new CargoValidator());
                var cargo = repository.Read(id);
                cargo = ObjectCreator.CreateCargo(cargo);
                repository.Update(cargo);
                Console.WriteLine("\nCargo updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {    
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteCargo(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Cargo>(new CargoValidator());
                var cargo = repository.Read(id);
                repository.Delete(cargo);
                Console.WriteLine("\nCargo deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void ShowCargo(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<Cargo>(new CargoValidator());
                var cargo = repository.Read(id);
                Console.WriteLine(cargo);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllCargos(Dictionary<string, MenuList> menu) {
            try {
                Console.Write("Cargos list.\n");
                var repository = new Repository<Cargo>(new CargoValidator());
                foreach (var cargo in repository.ReadAll()) {
                    Console.WriteLine(cargo);
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
