using System;
using System.Collections.Generic;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CargosMenu(Dictionary<string, MenuList> menu) {
            menu = new Dictionary<string, MenuList> {
                {"Add Cargo", AddCargo},
                {"Update Cargo", UpdateCargo},
                //{"Delete Cargo", DeleteCaptain},
                {"Show Cargo", ShowCargo},
                {"Show all Cargos", ShowAllCargos}
            };
            Menu(menu);
        }
        
        private static void AddCargo(Dictionary<string, MenuList> menu) {
            try {
                var cargo = ObjectCreator.CreateCargo();
                RepositoryHelper.CargoRepository.Create(cargo);
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
                int id;
                Console.Write("Enter Cargo ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargo = RepositoryHelper.CargoRepository.GetItem(id);
                cargo = ObjectCreator.CreateCargo(cargo);
                RepositoryHelper.CargoRepository.Update(cargo);
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

        private static void ShowCargo(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Cargo ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargo = RepositoryHelper.CargoRepository.GetItem(id);
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
                var cargos = RepositoryHelper.CargoRepository.ReadAll();
                if(cargos.Count == 0) Console.WriteLine("No elements found.");
                foreach (var cargo in cargos) {
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
