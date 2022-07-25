using LT.DigitalOffice.BookingService.Mappers.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Models.Db;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.Kernel.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace LT.DigitalOffice.BookingService.Mappers.Booking
{
  public class DbBookingMapper : IDbBookingMapper
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbBookingMapper(
      IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public DbBooking Map(CreateBookingRequest request)
    {
      if (request is null)
      {
        return null;
      }

      return new DbBooking
      {
        Id = Guid.NewGuid(),
        WorkspaceId = request.WorkspaceId,
        StartTime = request.StartTime,
        EndTime = request.EndTime,
        CreatedBy = _httpContextAccessor.HttpContext.GetUserId(),
        CreatedAtUtc = DateTime.UtcNow,
        IsActive = true
      };
    }
  }
}
