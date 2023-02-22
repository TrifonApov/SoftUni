namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    class AnimalsMain
    {
        static void Main()
        {
            var kitty = new Cat("asd",12,Gender.Male);
            var kitty1 = new Tomcat("asd1",10);
            var kitty2 = new Kitten("asd2",8);
            kitty.SoundProduce();
            kitty1.SoundProduce();
            kitty2.SoundProduce();

            var dog = new Dog("Sharo", 7, Gender.Male);
            dog.SoundProduce();

            var frog = new Frog("Toad", 2, Gender.Female);
            frog.SoundProduce();

            var animals = new List<Animal> {kitty, kitty1, kitty2, dog, frog};

            Console.WriteLine(animals.Average(a => a.Age));
        }
    }
}
