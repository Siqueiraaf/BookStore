using System.Reflection;
using BookStoreApi.AppContext;
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

            // add validacções para o current assembly
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}