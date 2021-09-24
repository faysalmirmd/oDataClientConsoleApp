using System;
using Microsoft.Extensions.DependencyInjection;

namespace ODataClientConsoleApp.Extensions
{
    static class ServiceProviderExtensions
    {
        public static T ResolveWith<T>(this IServiceProvider provider, params object[] parameters) where T : class =>
            ActivatorUtilities.CreateInstance<T>(provider, parameters);
    }
}