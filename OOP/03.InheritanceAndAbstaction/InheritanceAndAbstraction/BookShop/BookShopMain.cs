namespace BookShop
{
    using System;

    class BookShopMain
    {
        public static void Main()
        {
            Book book = new Book("Pod Igoto", "Ivan Vazov", 15.90m);
            Console.WriteLine(book.ToString());

            GoldenEditionBook book1 = new GoldenEditionBook("Tutun", "Dimitar Dimov", 22.90m);
            Console.WriteLine(book1.ToString());
        }
    }
}
