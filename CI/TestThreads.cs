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

        private P p1;
        private P p2;
        private P p3;
        private P p4;
        private P p5;

        public DP()
        {
            p1 = new P(cs1,cs5);
            p2 = new P(cs2,cs1);
            p3 = new P(cs3,cs2);
            p4 = new P(cs4,cs3);
            p5 = new P(cs5,cs4);
        }

    }

    public class P
    {
        public P(CS left, CS right)
        {
            Left = left;
            Right = right;
        }
        private int count = 5;
        public CS Left { get; set; }
        public CS Right { get; set; }

        public void Eat()
        {
        }

        private void PickUpL()
        {
        }
    }

    public class CS
    {
        public bool PickUp()
        {
            return Monitor.TryEnter(this);
        }

        public void PutDown()
        {
            Monitor.Exit(this);
        }
    }
}