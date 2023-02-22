using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MuseElf museElf = new("Pesho", 1);
            Elf elf = new("Elfina", 2);

            SoulMaster soulMaster = new("Merlin", 3);
            DarkWizard darkWizard = new("Gosho", 4);
            Wizard wizard = new("Madafaka", 5);

            BladeKnight bladeKnight = new("Blade", 6);
            DarkKnight darkKnight = new("Bruce", 7);
            Knight knight = new("Alfred", 999);

            Hero hero = new("No more heroes anymore", int.MaxValue);

            Console.WriteLine(museElf);
            Console.WriteLine(elf);
            Console.WriteLine(soulMaster);
            Console.WriteLine(darkWizard);
            Console.WriteLine(wizard);
            Console.WriteLine(bladeKnight);
            Console.WriteLine(darkKnight);
            Console.WriteLine(knight);
            Console.WriteLine(hero);
        }
    }
}