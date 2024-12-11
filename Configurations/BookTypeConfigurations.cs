using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreApi.Configurations
{

namespace bookapi_minimal.Configurations
{
    public class BookTypeConfigurations : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            // Configuração da tabela de livros
            builder.ToTable("Books");

            // Configuração da chave primária
            builder.HasKey(x => x.Id);

            // Configuração das colunas(Propriedades)
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Category).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Language).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TotalPages).IsRequired();

            // Configuração dos dados iniciais
            builder.HasData(
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "O Alquimista",
                    Author = "Paulo Coelho",
                    Description = "O alquimista um clássico contemporâneo sobre o poder transformador dos sonhos.",
                    Category = "Fiction",
                    Language = "Portuguese",
                    TotalPages = 208
                },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "A novel about the serious issues of rape and racial inequality.",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 281
                },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 328
                } 
            );
        }
    }
}
}