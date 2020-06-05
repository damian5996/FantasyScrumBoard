using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class UserProjectEntityConfig : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder
                .HasKey(userProject => new { userProject.UserId, userProject.ProjectId });

            builder
                .Property(userProject => userProject.Role)
                .IsRequired();

            builder
                 .Property(userProject => userProject.Level)
                 .IsRequired();

            builder
                .Property(userProject => userProject.Exp)
                .IsRequired();

            builder
                .Property(userProject => userProject.IsOwner)
                .IsRequired();

            builder
                .HasOne(userProject => userProject.User)
                .WithMany(user => user.UserProjects)
                .HasForeignKey(userProject => userProject.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(userProject => userProject.Project)
                .WithMany(project => project.UserProjects)
                .HasForeignKey(userProject => userProject.ProjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
