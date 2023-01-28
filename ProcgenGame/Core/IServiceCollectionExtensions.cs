using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcgenGame.Core
{
    /// <summary>
    /// Defines several extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the specified game to the service collection.
        /// </summary>
        /// <param name="services">The service contract for adding dependencies to the container.</param>
        /// <typeparam name="T">Specifies the type of <see cref="Game"/> to add.</typeparam>
        /// <returns>The current <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddGame<T>(this IServiceCollection services) where T : Game =>
            services.AddSingleton<T>()
                    .AddHostedService<GameService>();
    }
}