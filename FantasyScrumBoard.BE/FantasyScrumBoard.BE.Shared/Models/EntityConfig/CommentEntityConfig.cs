using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(comment => comment.Id);

            builder
                .Property(comment => comment.Content)
                .IsRequired()
                .HasMaxLength(256);

            builder
                 .Property(comment => comment.CreatedAt)
                 .IsRequired();

            builder
                 .Property(comment => comment.EditedAt)
                 .IsRequired(false);

            builder
                .HasOne(comment => comment.Author)
                .WithMany(author => author.Comments)
                .HasForeignKey(comment => comment.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(comment => comment.WorkItem)
                .WithMany(workItem => workItem.Comments)
                .HasForeignKey(comment => comment.WorkItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
