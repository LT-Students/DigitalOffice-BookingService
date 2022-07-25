using System;
using System.Threading.Tasks;
using LT.DigitalOffice.BookingService.Business.Commands.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LT.DigitalOffice.BookingService.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class BookingController : ControllerBase
  {
    [HttpPost("create")]
    public async Task<OperationResultResponse<Guid?>> Create(
      [FromBody] CreateBookingRequest request,
      [FromServices] ICreateBookingCommand command)
    {
      return await command.ExecuteAsync(request);
    }
  }
}
