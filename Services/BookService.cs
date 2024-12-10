using BookStoreApi.AppContext;
using BookStoreApi.Contracts;
using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<BookService> _logger;

        // Construtor para inicializar dependências
        public BookService(ApplicationContext context, ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Métodos da interface IBookService
        public async Task<BookResponse> AddBookAsync(CreateBookRequest createBookRequest)
        {
            // adicionando a logica para adicionar um livro ao banco de dados
            try
            {
                var book = new BookModel
                {
                    Title = createBookRequest.Title,
                    Author = createBookRequest.Author,
                    Description = createBookRequest.Description,
                    Category = createBookRequest.Category,
                    Language = createBookRequest.Language,
                    TotalPages = createBookRequest.TotalPages
                };
                // adicionando o livro ao banco de dados
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Livro {book.Title} adicionado ao banco de dados");

                return new BookResponse
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro: {ex.Message} ao adicionar o livro ao banco de dados");
                throw;
            }
        }

        public async Task<BookResponse> GetBookByIdAsync(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    _logger.LogInformation($"Livro com id {id} não encontrado");
                    return null;
                }

                return new BookResponse
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o livro pelo id: {ex.Message}");
                throw;
            }
            
        }
        public async Task<IEnumerable<BookResponse>> GetBooksAsync()
        {
            try
            {
                var books = await _context.Books.ToListAsync(); // Aguarda a tarefa
                return books.Select(book => new BookResponse
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Category = book.Category,
                    Language = book.Language,
                    TotalPages = book.TotalPages
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter os livros: {ex.Message}");
                throw;
            }
        }


        public async Task<BookResponse> UpdateBookAsync(Guid id, UpdateBookRequest book)
        {
            try
            {
                // buscando o livro pelo id
                var existingBook = await _context.Books.FindAsync(id);
                if (existingBook == null)
                {
                    _logger.LogWarning($"Livro com id {id} não encontrado.");
                    return null;
                }

                // atualizando o livro
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Category = book.Category;
                existingBook.Language = book.Language;
                existingBook.TotalPages = book.TotalPages;

                // salvar o livro no banco de dados
                await _context.SaveChangesAsync();
                _logger.LogInformation("Livro atualizado com sucesso.");

                // 
                return new BookResponse
                {
                    Id = existingBook.Id,
                    Title = existingBook.Title,
                    Author = existingBook.Author,
                    Description = existingBook.Description,
                    Category = existingBook.Category,
                    Language = existingBook.Language,
                    TotalPages = existingBook.TotalPages
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar o livro {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            try
            {
                // buscando o livro pelo id
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    _logger.LogWarning($"Livro com id {id} não encontrado");
                    return false;
                }

                // removendo o livro do banco de dados
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Livro com Id {id} removido do banco de dados");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao remover o livro: {ex.Message}");
                throw;
            }
        }

    }
}
