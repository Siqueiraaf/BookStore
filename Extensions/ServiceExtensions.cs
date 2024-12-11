using System.Reflection;
using BookStoreApi.AppContext;
using BookStoreApi.Exceptions;
using BookStoreApi.Interfaces;
using BookStoreApi.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAplicationServices(this IHostApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));

            // Adicionando o databese ao contexto
            builder.Services.AddDbContext<ApplicationContext>(configure =>
            {
                configure.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });

            // add validações para o current assembly
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IBookService, BookService>();

            // Adicionando o manipulador de exceções
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddProblemDetails();
        }
    }
}