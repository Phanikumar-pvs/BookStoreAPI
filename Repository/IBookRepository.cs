using BookStoreAPI.Models;

namespace BookStoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetBooksAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int id, BookModel bookModel);

        Task DeleteBookAsync(int id);
    }
}
