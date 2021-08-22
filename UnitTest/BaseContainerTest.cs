using System;
using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.WeatherForecast;
using Xunit;

namespace UnitTest
{
    public abstract class BaseContainerTest
    {
        protected IServiceCollection _serviceCollection;
        protected IWeatherForecast _WeatherForecast = A.Fake<IWeatherForecast>();

        [TestInitialize]
        public virtual void Initialize()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton(_WeatherForecast);
        }
    }
}
