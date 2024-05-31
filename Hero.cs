namespace ArenaGame
{
    public class Hero
    {
        public string Name { get; private set; }

        public int Health { get; private set; }

        public int Strength { get; private set; }

        protected int StartingHealth { get; private set; }

        public bool IsDead { get { return Health <= 0; } }
        public Weapon Weapon { get; set; }
        private bool blockNextAttack;

        public Hero(string name)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
        }

        public virtual int Attack()
        {
            int baseAttack = (Strength * Random.Shared.Next(80, 121)) / 100;
            int weaponDamage = Weapon?.Use() ?? 0;
            return baseAttack + weaponDamage;
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            if (blockNextAttack)
            {
                incomingDamage = 0;
                blockNextAttack = false;
            }
            if (incomingDamage < 0) return;
            Health -= incomingDamage;
        }
        public void BlockNextAttack()
        {
            blockNextAttack = true;
        }

        public bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }

        public void Heal(int value)
        {
            Health = Health + value;
            if (Health > StartingHealth) Health = StartingHealth;
        }
        public virtual void UseSpecialAbility()
        {
            Weapon?.ApplySpecialAbility(this);
        }
    }
}
