namespace RPGGame
{
    using System;
    using Characters;

    class RpgGameMain
    {
        static void Main()
        {
            var priest = new Priest();
            var warrior = new Warrior();
            var mage = new Mage();

            Console.WriteLine(priest.ToString());
            Console.WriteLine(warrior.ToString());
            Console.WriteLine(mage.ToString());

            priest.Attack(warrior);
            warrior.Attack(mage);
            mage.Attack(warrior);

            Console.WriteLine(priest.ToString());
            Console.WriteLine(warrior.ToString());
            Console.WriteLine(mage.ToString());
        }
    }
}
