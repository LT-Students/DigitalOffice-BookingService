using System;
using LT.DigitalOffice.BookingService.Models.Db;
using LT.DigitalOffice.Kernel.Attributes;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Data.Booking.Interfaces
{
  [AutoInject]
  public interface IBookingRepository
    {
      Task CreateAsync(DbBooking booking);
      Task<bool> HasOverlapAsync(Guid workspaceId, DateTime startTime, DateTime endTime);
    }
}
