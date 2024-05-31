using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Prince : Hero
    {
        private const int InspireChance = 20;
        public Prince(string name) : base(name) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(InspireChance))
            {
                attack = attack * 150 / 100;
            }
            return attack;
        }

        public override void UseSpecialAbility()
        {
            base.UseSpecialAbility();
            if (ThrowDice(25))
            {
                Heal(75);
            }
        }
    }
}
