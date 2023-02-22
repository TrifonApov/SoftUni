namespace ExceptionHandling
{
    using System;

    class ExceptionHandling
    {
        static void Main()
        {

            //var noLastName = new Person("FirstName", "  ", 21);
            //var nullFirstName = new Person(null, "LastName", 21);
            //var nullLastName = new Person("FirstName", null, 21);
            //var tooOld = new Person("FirstName", "LastName", 121);

            try
            {
                var pesho = new Person("Pesho", "Peshev", 24);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                var noFirstName = new Person(String.Empty, "LastName", 12);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Exception thrown: {0}", e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception thrown: {0}", e.Message);
            }

            try
            {
                var negativeAge = new Person("FirstName", "LastName", -1);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Exception thrown: {0}", e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception thrown: {0}", e.Message);
            }
        }
    }
}
