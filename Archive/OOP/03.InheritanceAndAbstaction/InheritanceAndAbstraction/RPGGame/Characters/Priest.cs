namespace RPGGame.Characters
{
    using Interfaces;

    public class Priest : Character, IHeal
    {
        public Priest() : base(125, 200, 100)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= 2 * this.Damage;
            this.Health += this.Damage/10;
        }
        public void Heal(Character targer)
        {
            this.Mana -= 100;
            targer.Health += 150;
        }
    }
}