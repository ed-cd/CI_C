using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CI
{
    public interface IShelter
    {
        void Enqueue(IAnimal animal);
        IAnimal DequeueAny();
        Cat DequeueCat();
        Dog DequeueDog();
        int Count { get; }
    }
    public class AltShelter: IShelter
    {
        private static int _count = 0;
        private readonly LinkedList<Tuple<Cat, int>> _cats = new LinkedList<Tuple<Cat, int>>();
        private readonly LinkedList<Tuple<Dog, int>> _dogs = new LinkedList<Tuple<Dog, int>>();
        public int Count => _cats.Count + _dogs.Count;

        public void Enqueue(IAnimal animal)
        {
            _count++;
            if (animal is Cat)
            {
                _cats.AddLast(new Tuple<Cat, int>((Cat) animal,_count));
            }
            else if (animal is Dog)
            {
                _dogs.AddLast(new Tuple<Dog, int>((Dog) animal, _count));
            }
            else
            {
                throw new Exception("Unknown animal");
            }
        }

        public IAnimal DequeueAny()
        {
            if (Count == 0)
            {
                throw new Exception("No animals");
            }
            if(_cats.Count ==0)
            {
                return _dogs.First.Value.Item1;
            }
            if (_dogs.Count == 0)
            {
                return _cats.First.Value.Item1;
            }
            if (_cats.First.Value.Item2 < _dogs.First.Value.Item2)
            {
                return DequeueCat();
            }
            return DequeueDog();
        }

        public Cat DequeueCat()
        {
            if (_cats.Count == 0)
            {
                throw new Exception("No Cats");
            }
            var ret = _cats.First.Value.Item1;
            _cats.RemoveFirst();
            return ret;
        }
        public Dog DequeueDog() {
            if (_dogs.Count == 0) {
                throw new Exception("No Dogs");
            }
            var ret = _dogs.First.Value.Item1;
            _dogs.RemoveFirst();
            return ret;
        }
    }

    public class Shelter: IShelter
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

        public T Dequeue<T>() where T : class, IAnimal
        {
            if (_animalsInShelter.Count == 0)
            {
                throw new Exception($"No {typeof(T)}s");
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

        public Dog DequeueDog()
        {
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