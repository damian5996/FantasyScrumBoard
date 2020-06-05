using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class UserAchievementEntityConfig : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder
                .HasKey(userAchievement => userAchievement.UserId);

            builder
                .HasKey(userAchievement => userAchievement.AchievementId);

            builder
                .Property(userAchievement => userAchievement.EarnedDate)
                .IsRequired();

            builder
                .HasOne(userAchievement => userAchievement.User)
                .WithMany(user => user.UserAchievements)
                .HasForeignKey(userAchievement => userAchievement.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(userAchievement => userAchievement.Achievement)
                .WithMany(achievement => achievement.UserAchievements)
                .HasForeignKey(userAchievement => userAchievement.AchievementId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
