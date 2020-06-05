using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyScrumBoard.BE.Shared.Models.EntityConfig
{
    public class NotificationEntityConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
                .HasKey(notification => notification.Id);

            builder
                .Property(notification => notification.Title)
                .IsRequired()
                .HasMaxLength(64);

            builder
                .Property(notification => notification.Content)
                .IsRequired()
                .HasMaxLength(256);

            builder
                 .Property(notification => notification.IsRead)
                 .IsRequired();

            builder
                 .Property(notification => notification.CreatedAt)
                 .IsRequired();

            builder
                 .Property(notification => notification.DeletedAt)
                 .IsRequired(false);

            builder
                .Property(notification => notification.RedirectUrl)
                .IsRequired(false)
                .HasMaxLength(256);

            builder
                .HasOne(notification => notification.Receiver)
                .WithMany(receiver => receiver.Notifications)
                .HasForeignKey(notification => notification.ReceiverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
