// Scripts/Core/ServiceLocator.cs
using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new();

    public static void Register<T>(T service)
    {
        var type = typeof(T);
        if (services.ContainsKey(type))
        {
            throw new InvalidOperationException($"Service {type.Name} already registered.");
        }

        services[type] = service;
    }

    public static T Get<T>()
    {
        var type = typeof(T);
        if (services.TryGetValue(type, out var service))
        {
            return (T)service;
        }

        throw new InvalidOperationException($"Service {type.Name} not found.");
    }

    public static void Clear()
    {
        services.Clear();
    }
}
