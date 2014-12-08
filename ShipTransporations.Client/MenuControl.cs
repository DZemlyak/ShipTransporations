using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipTransportations.Client
{
    static partial class MenuControl
    {
        private delegate void MenuList(Dictionary<string, MenuList> menu);

        public static void StartMenu()
        {
            var menu = new Dictionary<string, MenuList> {
                {"Captains Menu", CaptainsMenu},
                {"Cargos Menu", CargosMenu},
                {"Cargo Types Menu", CargoTypesMenu},
                {"Cities Menu", CitiesMenu},
                {"Ports Menu", PortsMenu},
                {"Ships Menu", ShipsMenu},
                {"Trips Menu", TripsMenu},
            };
            Menu(menu);
        }

        private static void Menu(Dictionary<string, MenuList> menu)
        {
            var position = 1;
            do {
                Console.CursorVisible = false;
                Console.Clear();
                PrintMenu(menu, position);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow) {
                    position--;
                    if (position == 0)
                        position = menu.Count;
                }
                if (key.Key == ConsoleKey.DownArrow) {
                    if (position == menu.Count)
                        position = 0;
                    position++;
                }
                if (key.Key == ConsoleKey.LeftArrow) break;
                if (key.Key != ConsoleKey.Enter) continue;
                Console.Clear();
                Console.CursorVisible = true;
                menu.ElementAt(position - 1).Value.Invoke(menu);
            } while (true);
        }

        private static void PrintMenu(Dictionary<string, MenuList> menu, int position)
        {
            var i = 1;
            Console.WriteLine("*** Menu ***");
            Console.WriteLine("-------------------------------");
            foreach (var m in menu) {
                Console.Write(i == position ? " -> " : "    ");
                Console.WriteLine(m.Key);
                i++;
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 3);
            Console.WriteLine("UP/DOWN - up/down. LEFT - back/exit. ENTER - select.");
        }
    }
}
