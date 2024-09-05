using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class ServiceLocator
    {
        public static ServiceLocator Container => _instance ??= new ServiceLocator(); 
        
        private static ServiceLocator _instance;
        private readonly Dictionary<Type, IService> _services = new();

        public void Register<T>(T service) where T : IService
        {
            Type type = typeof(T);
            if (_services.ContainsKey(type))
            {
                throw new Exception($"Service {type} is already registered.");
            }
            _services[type] = service;
        }

        public void Unregister<T>() where T : IService
        {
            Type type = typeof(T);
            if (!_services.ContainsKey(type))
            {
                throw new Exception($"Service {type} is not registered.");
            }
            _services.Remove(type);
        }

        public T Get<T>() where T : IService
        {
            Type type = typeof(T);
            if (!_services.TryGetValue(type, out IService service))
            {
                throw new Exception($"Service {type} is not registered.");
            }
            return (T)service;
        }
    }
}