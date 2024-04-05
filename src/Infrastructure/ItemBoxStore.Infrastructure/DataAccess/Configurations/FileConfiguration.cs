using ItemBoxStore.Domain.Images;
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
    /// Файл конфигурации сущности файла
    /// </summary>
    public class FileConfiguration : IEntityTypeConfiguration<StorageFile>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<StorageFile> builder)
        {
            builder
                .ToTable("Files")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(x => x.FilePath)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
