using BookStoreApi.Contracts;
using BookStoreApi.Interfaces;

namespace BookStoreApi.Endpoints
{
    public static class BookEndpoints
    {
        public static IEndpointRouteBuilder MapBookEndPoint(this IEndpointRouteBuilder app)
        {
            // Rota para adicionar um novo livro
            app.MapPost("/books", async (CreateBookRequest createBookRequest, IBookService bookService) =>
                {
                    var result = await bookService.AddBookAsync(createBookRequest);
                    return Results.Created($"/books/{result.Id}", result);
                });

            // Rota para obter todos os livros
            app.MapGet("/books", async (IBookService bookService) =>
            {
                var result = await bookService.GetBooksAsync();
                return Results.Ok(result);
            });

            // Rota para obter um livro existente pelo ID
            app.MapGet("/books/{id}", async (Guid id, IBookService bookService) =>
            {
                var result = await bookService.GetBookByIdAsync(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            });

            // Rota para atualizar um livro existente
            app.MapPut("/books/{id}", async (Guid id, UpdateBookRequest updateBookRequest, IBookService bookService) =>
            {
                var result = await bookService.UpdateBookAsync(id, updateBookRequest);
                return result != null ? Results.Ok(result) : Results.NotFound();
            });

            // Rota para excluir um livro existente
            app.MapDelete("/books/{id}", async (Guid id, IBookService bookService) =>
            {
                var result = await bookService.DeleteBookAsync(id);
                return result ? Results.NoContent() : Results.NotFound();
            });

            return app;
        }
    }
}