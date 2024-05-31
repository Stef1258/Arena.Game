using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Witch : Hero
    {
        private const int CurseChance = 15;
        public Witch(string name) : base(name) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(CurseChance))
            {
                attack += 50;
            }
            return attack;
        }

        public override void UseSpecialAbility()
        {
            base.UseSpecialAbility();
            if (ThrowDice(20))
            {
                Heal(100);
            }
        }
    }
}
