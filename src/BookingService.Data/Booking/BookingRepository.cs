using LT.DigitalOffice.BookingService.Data.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Data.Provider;
using LT.DigitalOffice.BookingService.Models.Db;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LT.DigitalOffice.BookingService.Data.Booking
{
  public class BookingRepository : IBookingRepository
  {
    private readonly IDataProvider _provider;
    private readonly ILogger<BookingRepository> _logger;

    public BookingRepository(
      IDataProvider provider,
      ILogger<BookingRepository> logger)
    {
      _provider = provider;
      _logger = logger;
    }

    public async Task CreateAsync(DbBooking booking)
    {
      if (booking == null)
      {
        _logger.LogWarning(new ArgumentNullException(nameof(booking)).Message);
        return;
      }

      _provider.Bookings.Add(booking);
      await _provider.SaveAsync();
    }

    public async Task<bool> HasOverlapAsync(Guid workspaceId, DateTime startTime, DateTime endTime)
    {
      return await _provider.Bookings.AnyAsync(b =>
        b.IsActive
        && b.WorkspaceId == workspaceId
        &&
        ((startTime >= b.StartTime && startTime <= b.EndTime)
        || (endTime >= b.StartTime && endTime <= b.EndTime)
        || (startTime <= b.StartTime && endTime >= b.EndTime)));
    }
  }
}
