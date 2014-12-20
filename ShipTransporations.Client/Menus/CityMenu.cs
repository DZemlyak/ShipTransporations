using System;
using System.Collections.Generic;
using ShipTransportations.EF;
using ShipTransportations.EF.Validators;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private static void CitiesMenu(Dictionary<string, MenuList> menu)
        {
            menu = new Dictionary<string, MenuList> {
                {"Add City", AddCity},
                {"Update City", UpdateCity},
                {"Delete City", DeleteCity},
                {"Show City", ShowCity},
                {"Show all Cities", ShowAllCities}
            };
            Menu(menu);
        }

        private static void AddCity(Dictionary<string, MenuList> menu)
        {
            try {
                var city = ObjectCreator.CreateCity();
                var repository = new Repository<City>(new CityValidator());
                repository.Add(city);
                Console.WriteLine("\nCity added.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void UpdateCity(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<City>(new CityValidator());
                var city = repository.Read(id);
                city = ObjectCreator.CreateCity(city);
                repository.Update(city);
                Console.WriteLine("\nCity updated.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {      
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void DeleteCity(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<City>(new CityValidator());
                var city = repository.Read(id);
                repository.Delete(city);
                Console.WriteLine("\nCity type deleted.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowCity(Dictionary<string, MenuList> menu)
        {
            try {
                var id = GetEntityId();
                var repository = new Repository<City>(new CityValidator());
                var city = repository.Read(id);
                Console.WriteLine(city);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {
                Console.WriteLine("\nPress any button.");
                Console.ReadKey();
            }
        }

        private static void ShowAllCities(Dictionary<string, MenuList> menu)
        {
            try {
                Console.Write("Cities list.\n");
                var repository = new Repository<City>(new CityValidator());
                foreach (var city in repository.ReadAll()) {
                    Console.WriteLine(city);
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
