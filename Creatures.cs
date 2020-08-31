using System;

namespace Hearthstone
{
    public class Creatures
    {
        public string CardName { get; set; }
        public int ManaCost { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public string Ability { get; set; }
        public string Type { get; set; }
        public bool CanAttack { get; set; }

        public Creatures(string card, int mana, int attack, int health, string ability, string type, bool canAttack)
        {
            CardName = card;
            ManaCost = mana;
            Attack = attack;
            Health = health;
            Ability = ability;
            Type = type;
            CanAttack = canAttack;
        }

        public override string ToString()
        {
            return String.Format("{0,-16} {1,10} {2,6} {3,-6} {4,16} {5,8}", $"{CardName}", $"{ManaCost}", $"{Attack}\t", $"{Health}", $"{Ability}", $"{Type}");
        }
    }
}
