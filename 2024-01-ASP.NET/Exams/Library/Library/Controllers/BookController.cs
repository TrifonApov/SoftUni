using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext data;

        public BookController(LibraryDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await data.Books
                .AsNoTracking()
                .Select(b => new AllBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name,
                    Rating = b.Rating
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            var model = await data.IdentityUserBooks
                .AsNoTracking()
                .Where(ub => ub.CollectorId == userId)
                .Select(b=> new UserBooksViewModel() 
                {
                    Id =b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Category = b.Book.Category.Name,
                    Description = b.Book.Description
                })
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateBookViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBookViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            await data.Books.AddAsync(new Book
            {
                Title = model.Title,
                Author = model.Author,
                Rating = model.Rating,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
            });
            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var userId = GetUserId();
            var bookToAdd = await data.Books
                .Where(b => b.Id == id)
                .Include(b=>b.UsersBooks)
                .FirstOrDefaultAsync();

            if (bookToAdd == null)
            {
                return RedirectToAction(nameof(All));
            }

            if(!bookToAdd.UsersBooks.Any(ub=>ub.CollectorId == userId)) 
            {
                bookToAdd.UsersBooks.Add(new IdentityUserBook()
                {
                    BookId = bookToAdd.Id,
                    CollectorId = userId
                });
            }

            await data.SaveChangesAsync();
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var userId = GetUserId();
            var bookToRemove = await data.Books
                .Where(b=>b.Id == id)
                .Include(b=>b.UsersBooks)
                .FirstOrDefaultAsync();

            if (bookToRemove == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var bookUser = bookToRemove.UsersBooks
                .FirstOrDefault(b => b.CollectorId == userId);
            if (bookUser == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            bookToRemove.UsersBooks.Remove(bookUser);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Mine));
        }

        private async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        [HttpGet]
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
