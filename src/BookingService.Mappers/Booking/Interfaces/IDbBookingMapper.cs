using LT.DigitalOffice.BookingService.Models.Db;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.BookingService.Mappers.Booking.Interfaces
{
  [AutoInject]
  public interface IDbBookingMapper
  {
    DbBooking Map(CreateBookingRequest request);
  }
}
