using System;
using System.Collections.Generic;

namespace TopDos.ObjectPooling
{
    public class ObjectPool<T>
    {
        private readonly Func<T> _preloadFunc;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;

        private Queue<T> _pool = new Queue<T>();
        private List<T> _activeObjects = new List<T>();

        public ObjectPool(Func<T> preloadFunc, Action<T> getAction, Action<T> returnAction, int preloadCount)
        {
            _preloadFunc = preloadFunc;
            _getAction = getAction;
            _returnAction = returnAction;

            if (preloadFunc == null)
            {
                throw new ArgumentNullException("Preload function is not defined");
            }

            for (int i = 0; i < preloadCount; i++)
            {
                Return(preloadFunc());
            }
        }

        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunc();
            _getAction(item);
            _activeObjects.Add(item);

            return item;
        }

        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _activeObjects.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (var item in _activeObjects)
            {
                Return(item);
            }
        }
    }
}
