using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

string seqServerUrl = Environment.GetEnvironmentVariable("seqServerUrl");
if (string.IsNullOrEmpty(seqServerUrl))
{
  seqServerUrl = configuration["Serilog:WriteTo:1:Args:serverUrl"];
}

string seqApiKey = Environment.GetEnvironmentVariable("seqApiKey");
if (string.IsNullOrEmpty(seqApiKey))
{
  seqApiKey = configuration["Serilog:WriteTo:1:Args:apiKey"];
}

Log.Logger = new LoggerConfiguration().ReadFrom
  .Configuration(configuration)
  .Enrich.WithProperty("Service", "BookingService")
  .WriteTo.Seq(
    serverUrl: seqServerUrl,
    apiKey: seqApiKey)
  .CreateLogger();

try
{
  var builder = WebApplication.CreateBuilder(args);

  builder.Services.AddControllers();

  var app = builder.Build();

  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.Run();
}
catch (Exception e)
{
  Log.Fatal(e, "Can not properly start BookingService.");
}
finally
{
  Log.CloseAndFlush();
}
