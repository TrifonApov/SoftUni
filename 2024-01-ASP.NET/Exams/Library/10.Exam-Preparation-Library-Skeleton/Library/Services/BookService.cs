using Library.Contracts;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddBookToCollection(string userId, object book)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public Task GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await dbContext.IdentityUserBooks
                .Where(ub=>ub.CollectorId == userId)
                .Select(b=> new AllBookViewModel()
                {
                    Id = b.Book.Id, 
                    Title = b.Book.Title, 
                    Author = b.Book.Author, 
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description, 
                    Category = b.Book.Category.Name
                })
                .ToListAsync();
        }
    }
}
