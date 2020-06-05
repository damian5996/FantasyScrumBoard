using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class SprintEntityConfig : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder
                .HasKey(sprint => sprint.Id);

            builder
                .Property(sprint => sprint.StartDate)
                .IsRequired();

            builder
                .Property(sprint => sprint.EstimatedEndDate)
                .IsRequired(false);

            builder
                .Property(sprint => sprint.ClosedAt)
                .IsRequired(false);

            builder
                .Property(sprint => sprint.CreatedAt)
                .IsRequired();

            builder
               .Property(sprint => sprint.Number)
               .IsRequired();

            builder
                .HasOne(sprint => sprint.Project)
                .WithMany(project => project.Sprints)
                .HasForeignKey(sprint => sprint.ProjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sprint => sprint.Mvp)
                .WithMany(mvp => mvp.Sprints)
                .HasForeignKey(sprint => sprint.MvpId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
