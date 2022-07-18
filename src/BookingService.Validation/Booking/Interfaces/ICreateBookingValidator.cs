using FluentValidation;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Attributes;

namespace LT.DigitalOffice.BookingService.Validation.Booking.Interfaces
{
  [AutoInject]
  public interface ICreateBookingValidator : IValidator<CreateBookingRequest>
  {
  }
}
