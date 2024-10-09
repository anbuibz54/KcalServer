using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.User;
using Models.Exceptions;
using Services.Weather;
namespace KcalServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IUserService userService;
    private readonly IWeatherForeCast weatherForeCast;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,IUserService userService,IWeatherForeCast weatherForeCast)
    {
        _logger = logger;
        this.userService = userService;
        this.weatherForeCast = weatherForeCast;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ApiResult<IEnumerable<WeatherForecast>> Get()
    {
        var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        weatherForeCast.GetRandomCelcius();
        var res = new ApiResult<IEnumerable<WeatherForecast>>();
        return res.Succeed( data);
    }
}
