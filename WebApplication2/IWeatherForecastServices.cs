
namespace WebApplication2
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
        IEnumerable<WeatherForecast> Get_default();
    }
}