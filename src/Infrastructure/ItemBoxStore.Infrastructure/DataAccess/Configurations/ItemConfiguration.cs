using ItemBoxStore.Domain.Images;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Configurations
{
    /// <summary>
    /// Файл конфигурации сущности объявления
    /// </summary>
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .ToTable("Items")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.SubCategoryId)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.Price)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.AuthorId)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
