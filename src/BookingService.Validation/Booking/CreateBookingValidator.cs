using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.BookingService.Validation.Booking.Interfaces;

namespace LT.DigitalOffice.BookingService.Validation.Booking
{
  public class CreateBookingValidator : AbstractValidator<CreateBookingRequest>, ICreateBookingValidator
  {
  }
}
