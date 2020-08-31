using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Hearthstone
{
    public class Deck
    {
        //list of all possible cards
        public List<Creatures> AllCards = new List<Creatures>
        {
            new Creatures("Murloc Raider", 1, 2, 1, "", "Murloc", false),
            new Creatures("Stonetusk Boar", 1, 1, 1, "Charge", "Beast", false),
            new Creatures("Bluegill Warrior", 2, 2, 1, "", "Murloc", false),
            new Creatures("River Crocolisk", 2, 2, 3, "", "Beast", false),
            new Creatures("Magma Rager", 3, 5, 1, "", "Elemental", false),
            new Creatures("Chillwind Yeti", 4, 4, 5, "", "", false),
            new Creatures("Gnomish Inventor", 4, 2, 4, "Draw", "", false),
            new Creatures("Boulderfist Ogre", 6, 6, 7, "", "", false),
            new Creatures("Core Hound", 7, 9, 5, "", "Beast", false),
            new Creatures("War Golem", 7, 7, 7, "", "", false),
            new Creatures("Timber Wolf", 1, 1, 1, "+1 ATK to Beasts", "Beast", false),
            new Creatures("Voidwalker", 1, 1, 3, "Taunt", "Demon", false),
            new Creatures("Kor'kron Elite", 4, 4, 3, "Charge", "", true),
            new Creatures("Felstalker", 2, 4, 3, "Discard", "Demon", false),
            new Creatures("Sizzling Top", 2, 3, 2, "Windfury", "Mech", false),
            new Creatures("Murloc Raider", 1, 2, 1, "", "Murloc", false),
            new Creatures("Stonetusk Boar", 2, 1, 1, "Charge", "Beast", true),
            new Creatures("Bluegill Warrior", 2, 2, 1, "", "Murloc", false),
            new Creatures("River Crocolisk", 2, 2, 3, "", "Beast", false),
            new Creatures("Magma Rager", 3, 5, 1, "", "Elemental", false),
            new Creatures("Chillwind Yeti", 4, 4, 5, "", "", false),
            new Creatures("Gnomish Inventor", 4, 2, 4, "Draw", "", false),
            new Creatures("Boulderfist Ogre", 6, 6, 7, "", "", false),
            new Creatures("Core Hound", 7, 9, 5, "", "Beast", false),
            new Creatures("War Golem", 7, 7, 7, "", "", false),
            new Creatures("Timber Wolf", 1, 1, 1, "+1 ATK to Beasts", "Beast", false),
            new Creatures("Voidwalker", 1, 1, 3, "Taunt", "Demon", false),
            new Creatures("Kor'kron Elite", 4, 4, 3, "Charge", "", true),
            new Creatures("Felstalker", 2, 4, 3, "Discard", "Demon", false),
            new Creatures("Sizzling Top", 2, 3, 2, "Windfury", "Mech", false)
        };

        //non-static list of cards, to handle cards in this deck
        public static List<Creatures> aDeck = new List<Creatures>();
        public static List<Creatures> bDeck = new List<Creatures>();

        public void AddCards()
        {
            var listA = new List<Creatures>(AllCards);
            var listB = new List<Creatures>(AllCards);
            while (listA.Count > 0)
            {
                Random rand = new Random();
                var randomIndex = rand.Next(0, listA.Count);
                aDeck.Add(listA[randomIndex]);
                listA.RemoveAt(randomIndex);
            }

            while (listB.Count > 0)
            {
                Random rand = new Random();
                var randomIndex = rand.Next(0, listB.Count);
                bDeck.Add(listB[randomIndex]);
                listB.RemoveAt(randomIndex);
            }
        }

        public Deck()
        {
            AddCards();
        }

        //Draw a specific amount of cards, if more than 10 cards, discard the card drawn.
        public static List<Creatures> Draw(int j, int playerNumber)
        {
            List<Creatures> Drawing = new List<Creatures>();

            if(playerNumber == 2)
            {
                for (int i = 0; i < j; i++)
                {
                    Drawing.Add(bDeck[i]);
                }
                bDeck.RemoveRange(0, j);
                return Drawing;
            }
            else
            {
                for (int i = 0; i < j; i++)
                {
                    Drawing.Add(aDeck[i]);
                }
                aDeck.RemoveRange(0, j);
                return Drawing;
            }
        }

    }
}
