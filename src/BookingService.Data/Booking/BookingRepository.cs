using LT.DigitalOffice.BookingService.Data.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Data.Provider;
using LT.DigitalOffice.BookingService.Models.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Data.Booking
{
  public class BookingRepository : IBookingRepository
  {
    private readonly IDataProvider _provider;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<BookingRepository> _logger;

    public BookingRepository(
      IDataProvider provider,
      IHttpContextAccessor httpContextAccessor,
      ILogger<BookingRepository> logger)
    {
      _provider = provider;
      _httpContextAccessor = httpContextAccessor;
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
  }
}
