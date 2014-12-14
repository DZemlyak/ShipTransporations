using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CaptainsMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add Captain", AddCaptain},
                {"Update Captain", UpdateCaptain},
                {"Delete Captain", DeleteCaptain},
                {"Show Captain", ShowCaptain},
                {"Show all Captains", ShowAllCaptains}
            };
            Menu(menu);
        }

        private static void AddCaptain(Dictionary<string, MenuList> menu)
        {
            try {
                var captain = ObjectCreator.CreateCaptain();
                if (context.Captains.Any(a => a.ShipId == captain.ShipId))
                    throw new Exception(string.Format("Captain with ShipID {0} already exists.", captain.ShipId));
                context.Captains.Add(captain);
                context.SaveChanges();
                context.Entry(captain).State = EntityState.Detached;
                Console.WriteLine("\nCaptain added.");
            }
            catch (Exception ex) {
                
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateCaptain(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Captain ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var captain = context.Captains.AsNoTracking().FirstOrDefault(t => t.CaptainId == id);
                if (captain == null)
                    throw new Exception("Element is not found.");
                captain = ObjectCreator.CreateCaptain(captain);
                //if (context.Captains.Any(a => a.ShipId == captain.ShipId))
                //    throw new Exception(string.Format("Captain with ShipID {0} already exists.", captain.ShipId));
                context.Entry(captain).State = EntityState.Modified;
                context.SaveChanges();
                context.Entry(captain).State = EntityState.Detached;
                Console.WriteLine("\nCaptain updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {   
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteCaptain(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Captain ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var captain = context.Captains.Find(id);
                context.Captains.Remove(captain);
                context.SaveChanges();
                Console.WriteLine("\nCaptain deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }
        
        private static void ShowCaptain(Dictionary<string, MenuList> menu)
        {
            try {
                int id;
                Console.Write("Enter Captain ID: ");
                var temp = Console.ReadLine();
                while (!int.TryParse(temp, out id)) {
                    Console.Write("Incorrect ID. Type again: ");
                    temp = Console.ReadLine();
                }
                var captain = context.Captains.AsNoTracking().FirstOrDefault(t => t.CaptainId == id);
                if (captain == null)
                    throw new Exception("Element is not found.");
                Console.WriteLine(captain);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllCaptains(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Captains list.\n");
                var captains = context.Captains.AsNoTracking().ToList();
                if (captains.Count == 0) Console.WriteLine("No elements found.");
                foreach (var captain in captains) {
                    Console.WriteLine(captain);
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
