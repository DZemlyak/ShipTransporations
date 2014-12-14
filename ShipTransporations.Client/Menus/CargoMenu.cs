using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
                context.Cargos.Add(cargo);
                context.SaveChanges();
                context.Entry(cargo).State = EntityState.Detached;
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
                var cargo = context.Cargos.AsNoTracking().FirstOrDefault(t => t.CargoId == id);
                cargo = ObjectCreator.CreateCargo(cargo);
                context.Entry(cargo).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(cargo).State = EntityState.Detached;
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
                int id;
                Console.Write("Enter Cargo ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargo = context.Cargos.Find(id);
                context.Cargos.Remove(cargo);
                context.SaveChanges();
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
                int id;
                Console.Write("Enter Cargo ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var cargo = context.Cargos.AsNoTracking().FirstOrDefault(t => t.CargoId == id);
                if (cargo == null)
                    throw new Exception("Element is not found.");
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
                var cargos = context.Cargos.AsNoTracking().ToList();
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
