namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);


        }

        // Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command, true, out var ageRestriction))
            {
                return $"{command} is not a valis restriction";
            }
            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 03
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 04
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToList();
            StringBuilder result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 05
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }

        // Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower());
            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        // Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            int[] dateInfo = date.Split("-").Select(int.Parse).ToArray();
            DateTime inputDate = new DateTime(dateInfo[2], dateInfo[1], dateInfo[0]);

            var books = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();
            StringBuilder result = new();
            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }
            return result.ToString().TrimEnd();
        }

        // Problem 08
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        // Problem 09
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(a => a)
                .ToList();
            return string.Join(Environment.NewLine, books);
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(a => a.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();
            StringBuilder result = new();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.Author})");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Count(b => b.Title.Length > lengthCheck);
            return count;
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
            .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FullName} - {author.Copies}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();


            StringBuilder result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.Profit:F2}");
            }
            return result.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                        .Select(b => new
                        {
                            b.Book.ReleaseDate,
                            b.Book.Title
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder result = new StringBuilder();
            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");
                foreach (var book in category.RecentBooks)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return result.ToString().TrimEnd();
        }

        // Problem 15
        public static string IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);
            
            StringBuilder result = new StringBuilder();
            foreach (var book in books)
            {
                book.Price += 5;
                result.AppendLine($"{book.Title} new price ${book.Price:F2}");
            }
            context.SaveChanges();
            return result .ToString().TrimEnd();
        }

        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);
            int deletedBooksCount = booksToDelete.Count();
            foreach (var book in booksToDelete)
            {
                context.Books.Remove(book);
            }
            context.SaveChanges();
            return deletedBooksCount;
        }
    }
}