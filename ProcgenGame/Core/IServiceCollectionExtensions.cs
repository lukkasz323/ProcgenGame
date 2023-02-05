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
        services.AddGame<Game1>();
    /// <summary>
    /// Adds a <see cref="Game"/> to the service contract.
    /// </summary>
    /// <typeparam name="T">Specifies the concrete <see cref="Game"/> implementation to add.</typeparam>
    /// <param name="services">The service contract for registering dependencies with the DI container.</param>
    /// <returns>The service contract for registering dependencies with the DI container.</returns>
    internal static IServiceCollection AddGame<T>(this IServiceCollection services) where T : Game =>
        services.AddSingleton<T>()
                .AddHostedService<GameService<T>>();
}