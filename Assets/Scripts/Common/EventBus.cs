using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    private Dictionary<Type, List<Action<object>>> handlers = new Dictionary<Type, List<Action<object>>>();

    public void Publish<T>(T message)
    {
        if (handlers.ContainsKey(typeof(T)))
        {
            var handler = handlers[typeof(T)];
            for (int i = 0; i < handler.Count; i++)
            {
                handler[i].Invoke(message);
            }
        }
    }

    public void Subscribe<T>(Action<T> handler)
    {
        if (!handlers.ContainsKey(typeof(T)))
        {
            handlers.Add(typeof(T), new List<Action<object>>());
        }
        handlers[typeof(T)].Add(obj => handler((T)obj));
    }


    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EventBus();

            return _instance;
        }
    }
}