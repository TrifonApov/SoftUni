using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollection(string userId, AllBookViewModel book);

        public Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<AllBookViewModel> GetBookByIdAsync(int id);

        public Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);

    }
}
