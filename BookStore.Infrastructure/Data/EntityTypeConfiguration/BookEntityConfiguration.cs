using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.EntityTypeConfiguration
{
    internal class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(255)
                   .IsRequired(); 

            builder.Property(x => x.Author)
                   .HasMaxLength(100); 

            builder.Property(x => x.Description)
                   .HasMaxLength(1000);

        }
    }
}
