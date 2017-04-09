using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace CI
{
    public class DP
    {
        private CS cs1 = new CS();
        private CS cs2 = new CS();
        private CS cs3 = new CS();
        private CS cs4 = new CS();
        private CS cs5 = new CS();

        private Philosopher p1;
        private Philosopher p2;
        private Philosopher p3;
        private Philosopher p4;
        private Philosopher p5;

        public DP()
        {
            p1 = new Philosopher(cs1, cs5, 5) {Name = "A"};
            p2 = new Philosopher(cs2, cs1, 5) {Name = "B"};
            p3 = new Philosopher(cs3, cs2, 5) {Name = "C"};
            p4 = new Philosopher(cs4, cs3, 5) {Name = "D"};
            p5 = new Philosopher(cs5, cs4, 5) {Name = "E"};
        }

        public void Run()
        {
            var t1 = new Thread(p1.Eat);
            var t2 = new Thread(p2.Eat);
            var t3 = new Thread(p3.Eat);
            var t4 = new Thread(p4.Eat);
            var t5 = new Thread(p5.Eat);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
        }
    }

    public class DP_V2
    {
        private CS cs1 = new CS();
        private CS cs2 = new CS();
        private CS cs3 = new CS();
        private CS cs4 = new CS();
        private CS cs5 = new CS();

        private Philosopher p1;
        private Philosopher p2;
        private Philosopher p3;
        private Philosopher p4;
        private Philosopher p5;

        public DP_V2()
        {
            p1 = new Philosopher(cs1, cs5, 5) {Name = "A"};
            p2 = new Philosopher(cs2, cs1, 5) {Name = "B"};
            p3 = new Philosopher(cs3, cs2, 5) {Name = "C"};
            p4 = new Philosopher(cs4, cs3, 5) {Name = "D"};
            p5 = new Philosopher(cs5, cs4, 5) {Name = "E"};
        }

        public void Run()
        {
            var t1 = new Thread(p1.Eat);
            var t2 = new Thread(p2.Eat);
            var t3 = new Thread(p3.Eat);
            var t4 = new Thread(p4.Eat);
            var t5 = new Thread(p5.Eat);
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
        }
    }

    public class Philosopher
    {
        public Philosopher(CS left, CS right, int bitesleft)
        {
            Left = left;
            Right = right;
            BitesLeft = bitesleft;
        }

        public string Name { get; set; }
        public int BitesLeft { get; set; }
        public CS Left { get; set; }
        public CS Right { get; set; }

        private Random _rand = new Random();

        public void Eat()
        {
            Console.WriteLine($"{Name} has started eating");
            while (BitesLeft > 0)
            {
                if (Monitor.TryEnter(Left))
                {
                    if (Monitor.TryEnter(Right))
                    {
                        Monitor.Exit(Left);
                        Monitor.Exit(Right);
                        _chew();
                    }
                    else
                    {
                        Monitor.Wait(Right);
                    }
                }
                else
                {
                    Monitor.Wait(Left);
                }
            }
            Console.WriteLine($"{Name} has finished eating");
        }


        private void _chew()
        {
            Console.WriteLine($"{Name} is chewing");
            Thread.Sleep(300);
            BitesLeft--;
        }
    }

    public class Philosopher_V2
    {
        public Philosopher_V2(CS left, CS right, int bitesleft)
        {
            Left = left;
            Right = right;
            BitesLeft = bitesleft;
        }

        public string Name { get; set; }
        public int BitesLeft { get; set; }
        public CS Left { get; set; }
        public CS Right { get; set; }

        private Random _rand = new Random();

        public void Eat()
        {
            Console.WriteLine($"{Name} has started eating");
            while (BitesLeft > 0)
            {
                if (Left.PickUp())
                {
                    if (Right.PickUp())
                    {
                        Left.PutDown();
                        Right.PutDown();
                        _chew();
                        BitesLeft--;
                        continue;
                    }
                    Left.PutDown();
                }
                _snooze();
            }
            Console.WriteLine($"{Name} has finished eating");
        }

        private void _snooze()
        {
            Console.WriteLine($"{Name} is snoozing");
            Thread.Sleep(_rand.Next(100) + 100);
        }


        private void _chew()
        {
            Console.WriteLine($"{Name} is chewing");
            Thread.Sleep(300);
        }
    }

    public class CS
    {
        private readonly object _lock = new object();

        public bool PickUp()
        {
            return Monitor.TryEnter(_lock);
        }

        public void PutDown()
        {
            Monitor.Exit(_lock);
        }
    }

    public class TestInOrder
    {
        public string Name { get; set; }
        public TestInOrder Next = null;
        public bool Running = true;

        public delegate void TestEventHandler(object sender, EventArgs e);

        public event TestEventHandler Signalled;

        public virtual void OnSignalled(EventArgs e)
        {
            Console.WriteLine(Name);
            Next?.OnSignalled(EventArgs.Empty);
            Running = false;
        }

        public void Run()
        {
            while (Running)
            {
            }
        }
    }
}