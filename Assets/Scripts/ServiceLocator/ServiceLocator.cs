using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ServiceLocator
{
    private static ServiceLocator _instance;
    private static object _lock = new object();
    private Dictionary<Type, object> services = new Dictionary<Type, object>();
    private Dictionary<string, object> servicesByName = new Dictionary<string, object>();
    private ServiceLocator() { }
    public static ServiceLocator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ServiceLocator();
                    }
                }
            }
            return _instance;
        }
    }
    public void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }
    public void SetService(string name, object service)
    {
        if (servicesByName.ContainsKey(name))
        {
            return; 
        }
        servicesByName[name] = service;
    }
    public T GetService<T>(params object[] args)
    {
        if (services.TryGetValue(typeof(T), out object result))
        {
            return (T)result;
        }
        var constructor = typeof(T).GetConstructor(args.Select(a => a.GetType()).ToArray());
        if (constructor != null)
        {
            result = constructor.Invoke(args);
            services.Add(typeof(T), result);
            return (T)result;
        }

        return default(T);
    }
    public T GetCommandService<T>(params object[] args) where T : class
    {
        if (services.TryGetValue(typeof(T), out object service))
        {
            return (T)service;
        }

        if (typeof(T).IsSubclassOf(typeof(MonoBehaviour)))
        {
            var gameObject = new GameObject(typeof(T).Name);
            var newService = gameObject.AddComponent(typeof(T)) as T;
            services[typeof(T)] = newService;
            return newService;
        }
        var constructor = typeof(T).GetConstructor(args.Select(arg => arg.GetType()).ToArray());
        if (constructor != null)
        {
            service = constructor.Invoke(args);
            services[typeof(T)] = service;
            return (T)service;
        }

        return null;
    }
    public bool IsServiceRegistered(string name)
    {
        return servicesByName.ContainsKey(name);
    }
}