using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.EntityTypeConfiguration
{
    internal class ShoppingCartEntityConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> b)
        {
            b.Property<int>("Id")
                       .ValueGeneratedOnAdd()
                       .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

            b.Property<string>("ApplicationUserId")
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            b.Property<int>("Count")
                .HasColumnType("int");

            b.Property<int>("BookId")
                .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("ApplicationUserId");

            b.HasIndex("BookId");

            b.ToTable("ShoppingCarts");

        }
    }
}
