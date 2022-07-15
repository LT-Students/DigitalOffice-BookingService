using System;

namespace LT.DigitalOffice.BookingService.Models.Dto.Requests
{
  public record CreateBookingRequest
  {
    public Guid WorkspaceId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
  }
}
