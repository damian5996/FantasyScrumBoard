using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder
                 .Property(user => user.LastName)
                 .IsRequired()
                 .HasMaxLength(64);

            builder
                 .Property(user => user.Email)
                 .IsRequired()
                 .HasMaxLength(128);

            builder
                 .Property(user => user.Level)
                 .IsRequired();

            builder
                 .Property(user => user.Nick)
                 .IsRequired(false)
                 .HasMaxLength(64);

            builder
                .Property(user => user.Exp)
                .IsRequired();

            builder
                .Property(user => user.CreatedAt)
                .IsRequired();

            builder
                .Property(user => user.DeletedAt)
                .IsRequired(false);
        }
    }
}
