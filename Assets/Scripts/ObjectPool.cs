using System;
using System.Collections.Generic;

public class ObjectPool<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly Func<T> _factoryMethod;
    
    public ObjectPool(Func<T> factoryMethod, int capacity)
    {
        _factoryMethod = factoryMethod;

        for (int i = 0; i < capacity; i++)
        {
            _queue.Enqueue(factoryMethod());
        }
    }

    public T TakeObject()
    {
        if (_queue.Count == 0)
        {
            _queue.Enqueue(_factoryMethod());
        }

        return _queue.Dequeue();
    }

    public void ReturnToPool(T obj)
    {
        _queue.Enqueue(obj);
    }
}
