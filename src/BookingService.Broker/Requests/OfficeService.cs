using LT.DigitalOffice.BookingService.Broker.Requests.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LT.DigitalOffice.Kernel.BrokerSupport.Helpers;
using LT.DigitalOffice.Models.Broker.Requests.Office;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace LT.DigitalOffice.BookingService.Broker.Requests
{
  public class OfficeService : IOfficeService
  {
    private readonly IRequestClient<ICheckWorkspaceExistenceRequest> _rcCheckWorkspaceExistence;
    private readonly ILogger<OfficeService> _logger;

    public OfficeService(
      IRequestClient<ICheckWorkspaceExistenceRequest> rcCheckWorkspaceExistence,
      ILogger<OfficeService> logger)
    {
      _rcCheckWorkspaceExistence = rcCheckWorkspaceExistence;
      _logger = logger;
    }

    public async Task<Guid?> CheckWorkspaceExistence(Guid workspaceId, List<string> errors)
    {
      return (await RequestHandler.ProcessRequest<ICheckWorkspaceExistenceRequest, ICheckWorkspaceExistenceRequest>(
        _rcCheckWorkspaceExistence,
        ICheckWorkspaceExistenceRequest.CreateObj(workspaceId),
        errors,
        _logger))?.WorkspaceId;
    }
  }
}
