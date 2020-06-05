using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class AchievementEntityConfig : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder
                .HasKey(achievement => achievement.Id);

            builder
                .Property(achievement => achievement.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                 .Property(achievement => achievement.Description)
                 .IsRequired()
                 .HasMaxLength(256);

            builder
                 .Property(achievement => achievement.Type)
                 .IsRequired();
        }
    }
}
