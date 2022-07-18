using System;
using System.Collections.Generic;
using FluentValidation;
using LT.DigitalOffice.BookingService.Broker.Requests.Interfaces;
using LT.DigitalOffice.BookingService.Data.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.BookingService.Validation.Booking.Interfaces;

namespace LT.DigitalOffice.BookingService.Validation.Booking
{
  public class CreateBookingValidator : AbstractValidator<CreateBookingRequest>, ICreateBookingValidator
  {
    public CreateBookingValidator(
      IBookingRepository bookingRepository,
      IOfficeService officeService)
    {
      RuleFor(r => r)
        .Cascade(CascadeMode.Stop)
        .Must(r => r.StartTime != default && r.EndTime != default)
        .WithMessage("Start and end time must be specified")
        .Must(r => r.StartTime > DateTime.Now && r.EndTime > DateTime.Now)
        .WithMessage("Start and end time must be after current time")
        .Must(r => r.StartTime < r.EndTime)
        .WithMessage("End time must be after start time")
        .MustAsync(async (r, _) =>
          await officeService.CheckWorkspaceExistence(r.WorkspaceId, new List<string>()))
        .WithMessage("Workspace either doesn't exist or not available for booking")
        .MustAsync(async (r, _) =>
          !await bookingRepository.HasOverlapAsync(r.WorkspaceId, r.StartTime, r.EndTime))
        .WithMessage("Workspace is already booked during specified period");
    }
  }
}
