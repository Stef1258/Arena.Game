using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Weapon
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public virtual int Use()
        {
            return Damage;
        }

        public virtual void ApplySpecialAbility(Hero hero) { }
    }

    public class Sword : Weapon
    {
        public Sword() : base("Sword", 30) { }
    }

    public class Shield : Weapon
    {
        private const int BlockChance = 20;
        public Shield() : base("Shield", 0) { }

        public override void ApplySpecialAbility(Hero hero)
        {
            if (hero.ThrowDice(BlockChance))
            {
                hero.BlockNextAttack();
            }
        }
    }

    public class MagicStaff : Weapon
    {
        private const int HealAmount = 50;
        public MagicStaff() : base("Magic Staff", 20) { }

        public override void ApplySpecialAbility(Hero hero)
        {
            hero.Heal(HealAmount);
        }
    }
}

