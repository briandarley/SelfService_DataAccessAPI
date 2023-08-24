using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XUnitTest_Repository
{
    public class TestLoggerFactory
    {
        public static ILoggerFactory LoggerFactory { get; private set; }

        public static ILogger<T> CreateLogger<T>() => LoggerFactory.CreateLogger<T>();

        static TestLoggerFactory()
        {
            // Set up LoggerFactory
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                builder.AddConsole() // Logging to console
                       .AddDebug());  // Logging to debug output
            var serviceProvider = serviceCollection.BuildServiceProvider();

            LoggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        }
    }
}
