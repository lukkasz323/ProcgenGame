using ProcgenGame.Core;

// Create a host and start running it.
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services
        .AddLogging(BuildLogging)
        .AddGame<Game1>()
).Build();
await host.RunAsync();

// Builds the logging service.
static void BuildLogging(ILoggingBuilder logging) =>
    logging.ClearProviders()
           .AddDebug()
           .SetMinimumLevel(LogLevel.Debug);