using System;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Attributes;
using LT.DigitalOffice.Kernel.Responses;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Business.Commands.Booking.Interfaces
{
  [AutoInject]
  public interface ICreateBookingCommand
  {
    Task<OperationResultResponse<Guid>> ExecuteAsync(CreateBookingRequest request);
  }
}
