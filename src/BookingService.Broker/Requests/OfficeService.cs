using LT.DigitalOffice.BookingService.Broker.Requests.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.Broker;
using LT.DigitalOffice.Models.Broker.Common;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Broker.Requests
{
  public class OfficeService : IOfficeService
  {
    private readonly IRequestClient<ICheckWorkspaceIsBookable> _rcCheckWorkspaceExistence;

    public OfficeService(IRequestClient<ICheckWorkspaceIsBookable> rcCheckWorkspaceExistence)
    {
      _rcCheckWorkspaceExistence = rcCheckWorkspaceExistence;
    }

    public async Task<bool> CheckWorkspaceExistence(Guid workspaceId, List<string> errors)
    {
      Response<IOperationResult<bool>> result =
        await _rcCheckWorkspaceExistence.GetResponse<IOperationResult<bool>>(
          ICheckWorkspaceIsBookable.CreateObj(workspaceId));

      if (result.Message is null)
      {
        return false;
      }

      return result.Message.Body;
    }
  }
}
