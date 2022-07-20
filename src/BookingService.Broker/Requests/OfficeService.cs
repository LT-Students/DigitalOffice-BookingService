using LT.DigitalOffice.BookingService.Broker.Requests.Interfaces;
using LT.DigitalOffice.Kernel.BrokerSupport.Broker;
using LT.DigitalOffice.Models.Broker.Requests.Office;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Broker.Requests
{
  public class OfficeService : IOfficeService
  {
    private readonly IRequestClient<ICheckWorkspaceIsBookableRequest> _rcCheckWorkspaceExistence;

    public OfficeService(IRequestClient<ICheckWorkspaceIsBookableRequest> rcCheckWorkspaceExistence)
    {
      _rcCheckWorkspaceExistence = rcCheckWorkspaceExistence;
    }

    public async Task<bool> CheckWorkspaceExistence(Guid workspaceId)
    {
      Response<IOperationResult<bool>> result =
        await _rcCheckWorkspaceExistence.GetResponse<IOperationResult<bool>>(
          ICheckWorkspaceIsBookableRequest.CreateObj(workspaceId));

      if (result.Message is null)
      {
        return false;
      }

      return result.Message.Body;
    }
  }
}
