using LT.DigitalOffice.Kernel.BrokerSupport.Configurations;

namespace LT.DigitalOffice.BookingService.Models.Dto.Configurations
{
  public class RabbitMqConfig : BaseRabbitMqConfig
  {
    public string AuthenticationServiceValidationUrl { get; set; }
  }
}
