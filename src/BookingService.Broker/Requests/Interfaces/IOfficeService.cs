using LT.DigitalOffice.Kernel.Attributes;
using System;
using System.Threading.Tasks;

namespace LT.DigitalOffice.BookingService.Broker.Requests.Interfaces
{
  [AutoInject]
    public interface IOfficeService
    {
      Task<bool> CheckWorkspaceExistence(Guid workspaceId);
    }
}
