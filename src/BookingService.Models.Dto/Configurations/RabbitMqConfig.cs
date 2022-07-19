using LT.DigitalOffice.Kernel.BrokerSupport.Attributes;
using LT.DigitalOffice.Kernel.BrokerSupport.Configurations;
using LT.DigitalOffice.Models.Broker.Requests.Office;

namespace LT.DigitalOffice.BookingService.Models.Dto.Configurations
{
  public class RabbitMqConfig : BaseRabbitMqConfig
  {
    [AutoInjectRequest(typeof(ICheckWorkspaceIsBookableRequest))]
    public string CheckWorkspaceIsBookableEndpoint { get; set; }
  }
}
