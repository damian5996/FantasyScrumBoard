using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class WorkItemEntityConfig : IEntityTypeConfiguration<WorkItem>
    {
        public void Configure(EntityTypeBuilder<WorkItem> builder)
        {
            builder
                .HasKey(workItem => workItem.Id);

            builder
                .Property(workItem => workItem.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(workItem => workItem.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(workItem => workItem.CreatedAt)
                .IsRequired();

            builder
                .Property(workItem => workItem.EditedAt)
                .IsRequired(false);

            builder
                .Property(workItem => workItem.Status)
                .IsRequired();

            builder
                .Property(workItem => workItem.StoryPoints)
                .IsRequired();

            builder
                .Property(workItem => workItem.VersionGuid)
                .IsRequired()
                .HasMaxLength(64);

            builder
               .Property(workItem => workItem.Type)
               .IsRequired();

            builder
                .HasOne(workItem => workItem.Sprint)
                .WithMany(sprint => sprint.WorkItems)
                .HasForeignKey(workItem => workItem.SprintId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(workItem => workItem.AssignedUser)
                .WithMany(assignedUser => assignedUser.WorkItems)
                .HasForeignKey(workItem => workItem.AssignedUserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(workItem => workItem.Project)
                .WithMany(project => project.WorkItems)
                .HasForeignKey(workItem => workItem.ProjectId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
