namespace RPGGame.Characters
{
    using Interfaces;

    public abstract class Character : IAttack
    {
        protected Character(int health, int mana, int damage)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
        }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public abstract void Attack(Character target);

        public override string ToString()
        {
            return
                string.Format(
                    "{0}\n\tHealt: {1}\n\tMana: {2}\n\tDamage: {3}",
                    this.GetType().Name,
                    this.Health,
                    this.Mana,
                    this.Damage);
        }
    }
}