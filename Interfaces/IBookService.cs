using BookStoreApi.Contracts;

namespace BookStoreApi.Interfaces
{
    public interface IBookService
    {
        Task<BookResponse> AddBookAsync(CreateBookRequest createBookRequest);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookResponse>> GetBooksAsync();
        Task<BookResponse> UpdateBookAsync(Guid Id, UpdateBookRequest updateBookRequest);
        Task<bool> DeleteBookAsync(Guid Id);

    }
}