namespace ProcgenGame.Core;

/// <summary>
/// Defines a collection of extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
internal static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the dependencies for Procgen Game to the service contract.
    /// </summary>
    /// <param name="services">The service contract for registering dependencies with the DI container.</param>
    /// <returns>The service contract for registering dependencies with the DI container.</returns>
    internal static IServiceCollection AddProcgenGame(this IServiceCollection services) =>
        services.AddHostedService<GameService<Game1>>();
}