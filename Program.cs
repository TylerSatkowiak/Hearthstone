using System;
using System.Collections.Generic;
using System.Linq;

namespace Hearthstone
{
    public class Program
    {
        public static void Main()
        {
            var Game = new Game();
            Game.PlayGame();
        }

        public static List<Creatures> Discard(List<Creatures> deck)
        {
            if (deck.Count > 10)
            {
                Console.WriteLine(String.Format("{0,-25} {1,-9} {2,-6} {3,-6} {4,-20} {5,-8}", "Card Name", "Mana Cost", "Attack", "Health", "Ability", "Type"));
                Console.WriteLine($"Discarded: {deck[10]}");
                Console.WriteLine("");
            }
            return deck.Take(10).ToList();
        }

        public static int ValidateMenuChoice(string entry, List<Creatures> deck)
        {

            if (!int.TryParse(entry, out int menuValue))
            {
                Console.WriteLine("Please have a valid input.");
                return 0;
            }

            else if (menuValue > 0 && menuValue <= deck.Count + 3)
            {
                return menuValue;
            }

            else
            {
                Console.WriteLine("Please have a valid input.");
                return 0;
            }

        }

        public static void Concede()
        {
            //Method called to restart.
            Console.WriteLine("");
            Console.WriteLine("Quit?. Y/N?");
            string y = Console.ReadLine().ToLower();
            if (y == "y")
            {
                Environment.Exit(1);
            }
        }

        public static void ViewPlayerDecks(Deck deck)
        {
            Console.WriteLine("Each player's deck is filled with 2 copies of each of the following cards.");
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,-16} {1,-10} {2,-6} {3,-6} {4,-20} {5,-8}", "Card Name", "Mana Cost", "Attack", "Health", "Ability", "Type"));
            foreach (Creatures card in deck.AllCards)
            {
                Console.WriteLine($"{card}");
            }
        }

    }
}
