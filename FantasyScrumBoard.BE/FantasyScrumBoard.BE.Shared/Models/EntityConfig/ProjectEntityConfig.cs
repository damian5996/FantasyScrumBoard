using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class ProjectEntityConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(project => project.Id);

            builder
                .Property(project => project.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(project => project.Description)
                .IsRequired()
                .HasMaxLength(512);

            builder
                 .Property(project => project.StartDate)
                 .IsRequired();

            builder
                 .Property(project => project.EndDate)
                 .IsRequired(false);

            builder
                 .Property(project => project.DeletedAt)
                 .IsRequired(false);

            builder
                 .Property(project => project.CreatedAt)
                 .IsRequired();

            builder
                 .Property(project => project.EditedAt)
                 .IsRequired();
        }
    }
}
