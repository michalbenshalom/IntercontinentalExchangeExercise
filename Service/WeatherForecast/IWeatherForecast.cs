using System;
using System.Collections.Generic;
using System.Text;

namespace Services.WeatherForecast
{
    public interface IWeatherForecast
    {
        int? GetWeatherForecast(DateTime date, double lat, double lon);
    }
}
