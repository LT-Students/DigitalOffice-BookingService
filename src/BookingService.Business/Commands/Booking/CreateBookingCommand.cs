using FluentValidation.Results;
using LT.DigitalOffice.BookingService.Business.Commands.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Data.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Mappers.Booking.Interfaces;
using LT.DigitalOffice.BookingService.Models.Dto.Requests;
using LT.DigitalOffice.BookingService.Validation.Booking.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.AccessValidatorEngine.Interfaces;
using LT.DigitalOffice.Kernel.Constants;
using LT.DigitalOffice.Kernel.Helpers.Interfaces;
using LT.DigitalOffice.Kernel.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Business.Commands.Booking
{
  public class CreateBookingCommand : ICreateBookingCommand
  {
    private readonly IAccessValidator _accessValidator;
    private readonly IBookingRepository _repository;
    private readonly ICreateBookingValidator _validator;
    private readonly IDbBookingMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IResponseCreator _responseCreator;

    public CreateBookingCommand(
      IAccessValidator accessValidator,
      IBookingRepository repository,
      ICreateBookingValidator validator,
      IDbBookingMapper mapper,
      IHttpContextAccessor httpContextAccessor,
      IResponseCreator responseCreator)
    {
      _accessValidator = accessValidator;
      _repository = repository;
      _validator = validator;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
      _responseCreator = responseCreator;
    }

    public async Task<OperationResultResponse<Guid?>> ExecuteAsync(CreateBookingRequest request)
    {
      //TODO: Update right
      if (!await _accessValidator.HasRightsAsync(Rights.AddEditRemoveCompanyData))
      {
        return _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.Forbidden);
      }

      ValidationResult validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        return _responseCreator.CreateFailureResponse<Guid?>(
          HttpStatusCode.BadRequest,
          validationResult.Errors.Select(vf => vf.ErrorMessage).ToList());
      }

      OperationResultResponse<Guid?> response = new();

      response.Body = await _repository.CreateAsync(_mapper.Map(request));

      _httpContextAccessor.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;

      return response.Body is null
        ? _responseCreator.CreateFailureResponse<Guid?>(HttpStatusCode.BadRequest)
        : response;
    }
  }
}
