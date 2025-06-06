using BookingAPI.Domain.Entities;
using BookingAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAPI.Infrastructure.EF.Maps
{
    internal sealed class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.OwnsOne(x => x.Slot, slot =>
            {
                slot.Property(s => s.StartTime)
                    .HasColumnName("StartTime")
                    .IsRequired();

                slot.Property(s => s.EndTime)
                    .HasColumnName("EndTime")
                    .IsRequired();
            });

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion(
                    c => c.ToString(),
                    v => Enum.Parse<BookingStatus>(v)
                );

            builder.Property(x => x.BookedBy).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();

            builder.HasOne<Room>()
                .WithMany()
                .HasForeignKey(x => x.RoomId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}