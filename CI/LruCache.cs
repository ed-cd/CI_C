using System;
using System.Collections.Generic;
using System.Threading;

namespace CI
{
    public class LruCache<K,T>
    {
        private Dictionary<K, T> _hash = new Dictionary<K, T>();
        private LinkedList<K> _queue = new LinkedList<K>();
        private readonly int _maxSize;
        private int _currentSize = 0;

        public LruCache(int maxSize)
        {
            _maxSize = maxSize;
        }

        public void Add(K key, T val)
        {
            lock (this)
            {
                if (_currentSize == _maxSize)
                {
                    _removeOldest();
                    _currentSize--;
                }
                _hash.Add(key, val);
                _currentSize++;
            }
        }

        public T Get(K key)
        {
            return _hash[key];
        }
        private void _removeOldest()
        {
            var key = _queue.First.Value;
            _queue.RemoveFirst();
            _hash.Remove(key);
        }


    }
}