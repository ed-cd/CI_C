using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CI
{
    public class Shelter
    {
        private readonly LinkedList<IAnimal> _animalsInShelter = new LinkedList<IAnimal>();
        public int Count => _animalsInShelter.Count;        

        public void Enqueue(IAnimal animal)
        {
            _animalsInShelter.AddLast(animal);            
        }

        public IAnimal DequeueAny()
        {
            if (_animalsInShelter.Count == 0)
            {
                throw new Exception("No animals");
            }
            var ret = _animalsInShelter.First.Value;
            _animalsInShelter.RemoveFirst();
            return ret;
        }

        public T Dequeue<T>() where T : class,IAnimal
        {
            if (_animalsInShelter.Count == 0) {
                throw new Exception("No animals");
            }
            var node = _animalsInShelter.First;
            do
            {
                var val = node.Value;
                if (val is T)
                {
                    _animalsInShelter.Remove(node);
                    return val as T;
                }
                node = node.Next;
            } while (node != null);
            return null;
        }

        public Cat DequeueCat()
        {
            return Dequeue<Cat>();
        }
        public Dog DequeueDog() {
            return Dequeue<Dog>();
        }
    }

    public interface IAnimal
    {
        string Type { get; }
    }

    public class Cat : IAnimal
    {
        private static int _globalCount = 0;
        private readonly int _count;

        public Cat()
        {
            _globalCount ++;
            _count = _globalCount;
        }
        public string Type => $"Cat {_count}";
    }

    public class Dog : IAnimal
    {
        private static int _globalCount = 0;
        private readonly int _count;

        public Dog()
        {
            _globalCount++;
            _count = _globalCount;
        }
        public string Type => $"Dog {_count}";
    }
}