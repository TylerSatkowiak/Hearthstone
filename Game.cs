using System;
using System.Collections.Generic;
using System.Linq;

namespace Hearthstone
{
    public class Game
    {
        public static int Player1Mana = 0;
        public static int Player2Mana = 0;
        public static int Player1Health = 30;
        public static int Player2Health = 30;

        public static List<Creatures> Hand1 = new List<Creatures>();
        public static List<Creatures> Hand2 = new List<Creatures>();
        public static List<Creatures> Board1 = new List<Creatures>();
        public static List<Creatures> Board2 = new List<Creatures>();

        public static Deck player1 = new Deck();
        public static Deck player2 = new Deck();

        //Show deck list and draw each player's initial cards.
        public void PlayGame()
        {
            Program.ViewPlayerDecks(player1);
            Console.WriteLine("");
            Hand1.AddRange(Deck.Draw(3, 1));
            Hand2.AddRange(Deck.Draw(4, 2));

            Hand2.Add(new Creatures("Coin", 0, 0, 0, "+1 to Mana", "",false)); //"ADD COIN TO HAND"
            Player1Turn();
        }

        public void SummoningSickness(List<Creatures> board)
        {
            foreach (Creatures card in board)
            {
                card.CanAttack = true;
            }
        }

        //After Player 1 end's turn, turn to player 2
        public void Player1Turn()
        {
            SummoningSickness(Board1);
            Player1Mana++;
            int useableMana = Player1Mana;
            Hand1.AddRange(Deck.Draw(1, 1));
            Hand1 = Program.Discard(Hand1);

            int choose = 0;
            bool endTurn = true;
            while (endTurn)
            {
                ShowHand(Hand1, 1, Player1Health, useableMana, Player1Mana);
                Console.WriteLine("Select an option using the numbers on the left.");
                string entry = Console.ReadLine();
                choose = Program.ValidateMenuChoice(entry, Hand1);

                if (choose > 1 && choose <= Hand1.Count)
                {
                    if (Hand1[choose - 1].ManaCost > useableMana)
                    {
                        Console.WriteLine($"You don't have enough Mana to play {Hand1[choose - 1].CardName}");
                    }
                    else
                    {
                        PrintToBoard(Hand1, Board1, choose, 1);
                        useableMana -= Hand1[choose - 1].ManaCost;
                        Hand1.RemoveAt(choose - 1);
                    }
                }

                else if (choose == Hand1.Count + 1)
                {
                    if(Board1.Count == 0)
                    {
                        Console.WriteLine("You don't have anything to attack with!");
                        Console.WriteLine("");
                    }

                    else
                    {
                        Console.WriteLine("");
                        PrintBoards(Board1);
                        Console.WriteLine("");
                        PrintBoards(Board2);
                        
                        
                        int attack = AttackChoice(Board1);
                        int defend = DefendChoice(Board2);

                    }

                }

                else if (choose == Hand1.Count + 2)
                {
                    Console.WriteLine("Do you want to end your turn?");
                    string q = Console.ReadLine().ToLower();
                    if (q == "y")
                    {
                        Console.Clear();
                        Player2Turn();
                    }

                }

                else if (choose == Hand1.Count + 3)
                {
                    Program.Concede();
                }

                else
                {
                    Console.WriteLine("uhh......SMOKEBOMB!");
                }
            }
        }

        public static void PrintBoards(List<Creatures> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (board.Count == 0)
                {
                    Console.WriteLine("There is nothing on the board.");
                    break;
                }
                Console.WriteLine($"{i + 1}. {board[i]}");
            }
        }

        public static int DefendChoice(List<Creatures> board)
        {

            Console.WriteLine("What do you want to attack?");
            string entry = Console.ReadLine();
            if (!int.TryParse(entry, out int menuValue))
            {
                Console.WriteLine("Please have a valid input.");
                return 0;
            }

            else if (menuValue > 0 && menuValue <= board.Count + 2)
            {
                return menuValue;
            }

            else
            {
                Console.WriteLine("Please have a valid input.");
                return 0;
            }
        }

        public static int AttackChoice(List<Creatures> board)
        {
            if (board.Count == 0)
            {
                Console.WriteLine("You don't have any minions to attack with.");
                return 0;
            }
            else
            {
                Console.WriteLine("Which creature do you want to attack with?");
                string entry = Console.ReadLine();
                if (!int.TryParse(entry, out int menuValue))
                {
                    Console.WriteLine("Please have a valid input.");
                    return 0;
                }

                else if (menuValue > 0 && menuValue <= board.Count)
                {
                    return menuValue;
                }

                else
                {
                    Console.WriteLine("Please have a valid input.");
                    return 0;
                }
            }

        }

        //Deal minion damage to the opposing hero

        //Deal ATK dmg to creature's health, if either reach 0, send to graveyard
        public static void Damage(List<Creatures> board1, int selection1, List<Creatures> board2, int selection2)
        {


        }


        //Similar to Player 1's turn, add a 'coin' to their hand. 
        public void Player2Turn()
        {
            SummoningSickness(Board2);
            Player2Mana++;
            int useableMana = Player2Mana;
            Hand2.AddRange(Deck.Draw(1, 2));
            Hand2 = Program.Discard(Hand2);


            int choose = 0;
            bool endTurn = true;
            while (endTurn)
            {
                ShowHand(Hand2, 2, Player2Health, useableMana, Player2Mana);
                Console.WriteLine("Select an option using the numbers on the left.");
                string entry = Console.ReadLine();
                choose = Program.ValidateMenuChoice(entry, Hand2);

                if (choose > 1 && choose <= Hand2.Count)
                {
                    if (Hand2[choose - 1].ManaCost > Player2Mana)
                    {
                        Console.WriteLine($"You don't have enough Mana to play {Hand2[choose - 1].CardName}");
                    }

                    else if (Hand2[choose - 1].CardName == "Coin")
                    {
                        useableMana += 1;
                    }

                    else
                    {
                        PrintToBoard(Hand2, Board2, choose, 2);
                        useableMana -= Hand2[choose - 1].ManaCost;
                        Hand2.RemoveAt(choose - 1);
                    }
                }

                else if (choose == Hand2.Count + 1)
                {
                    AttackChoice(Board2);
                }

                else if (choose == Hand2.Count + 2)
                {
                    Console.WriteLine("Do you want to end your turn?");
                    string q = Console.ReadLine().ToLower();
                    if (q == "y")
                    {
                        Console.Clear();
                        Player1Turn();
                    }

                }

                else if (choose == Hand2.Count + 3)
                {
                    Program.Concede();
                }

                else
                {
                    Console.WriteLine("UHH....SMOKEBOMB!");
                }
            }
        }



        //Send a minion from the player's hand onto the field.
        public static void PrintToBoard(List<Creatures> deck, List<Creatures> board, int choice, int playerNumber)
        {
            board.Add(deck[choice - 1]);
            Console.WriteLine($"Succesfully added to board for Player {playerNumber}");
            for (int i = 0; i < board.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {board[i]}");
            }
            Console.WriteLine("");
        }

        //Show hand, Health, Mana and option to pass turn
        public void ShowHand(List<Creatures> deck, int playerNumber, int health, int mana, int totalMana)
        {
            Console.WriteLine($"Player {playerNumber}'s hand:");
            Console.WriteLine($"Current Health: {health}");
            Console.WriteLine($"Total Mana: {totalMana}");
            Console.WriteLine($"Useable Mana: {mana}");
            Console.WriteLine(String.Format("{0,-25} {1,9} {2,6} {3,-6} {4,16} {5,8}", "Card Name", "Mana Cost", "Attack", "Health", "Ability", "Type"));

            for (int i = 0; i < deck.Count; i++)
            {
                if (deck.Count == 0)
                {
                    Console.WriteLine("OH NO! You don't have any cards in hand.");
                }

                Console.WriteLine($"{i + 1}. {deck[i]}");
            }
            Console.WriteLine($"{deck.Count + 1}. Attack");
            Console.WriteLine($"{deck.Count + 2}. End turn?");
            Console.WriteLine($"{deck.Count + 3}. Concede?");
            Console.WriteLine("");
        }



    }
}