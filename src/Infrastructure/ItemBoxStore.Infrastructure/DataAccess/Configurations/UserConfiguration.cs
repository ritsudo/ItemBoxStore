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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(t => t.Id);

            builder
                .Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
