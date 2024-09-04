using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new();
        private static ServiceLocator _instance;

        public static void Register<T>(T service)
        {
            Type type = typeof(T);
            if (Services.ContainsKey(type))
            {
                throw new Exception($"Service {type} is already registered.");
            }
            Services[type] = service;
        }

        public static void Unregister<T>()
        {
            Type type = typeof(T);
            if (!Services.ContainsKey(type))
            {
                throw new Exception($"Service {type} is not registered.");
            }
            Services.Remove(type);
        }

        public static T Get<T>()
        {
            Type type = typeof(T);
            if (!Services.TryGetValue(type, out object service))
            {
                throw new Exception($"Service {type} is not registered.");
            }
            return (T)service;
        }
    }
}