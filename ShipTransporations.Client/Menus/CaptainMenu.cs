using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

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
                var repository = new Repository<Captain>(new CaptainValidator());
                repository.Add(captain);
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
                var id = GetEntityId();
                var repository = new Repository<Captain>(new CaptainValidator());
                var captain = repository.Read(id);
                captain = ObjectCreator.CreateCaptain(captain);
                repository.Update(captain);
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
                var id = GetEntityId();
                var repository = new Repository<Captain>(new CaptainValidator());
                var captain = repository.Read(id);
                repository.Delete(captain);
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
                var id = GetEntityId();
                var repository = new Repository<Captain>(new CaptainValidator());
                var captain = repository.Read(id);
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
                var repository = new Repository<Captain>(new CaptainValidator());
                foreach (var captain in repository.ReadAll()) {
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
