using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.BookingService.Models.Db
{
  public class DbBooking
  {
    public const string TableName = "Bookings";
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public bool IsActive { get; set; }
  }

  public class DbBookingConfiguration : IEntityTypeConfiguration<DbBooking>
  {
    public void Configure(EntityTypeBuilder<DbBooking> builder)
    {
      builder.ToTable(DbBooking.TableName);

      builder.HasKey(t => t.Id);

      builder.Property(w => w.WorkspaceId).IsRequired();

      builder.Property(st => st.StartTime).IsRequired();

      builder.Property(et => et.EndTime).IsRequired();
    }
  }
}
