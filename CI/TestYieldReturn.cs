using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    class TestYieldReturn
    {
        public static int count;

        public IEnumerable<string> Test()
        {
            count++;
            yield return "test";
        }

        public void IterateTwice()
        {
            var result = Test();
            Console.WriteLine($"count at start:{count}");
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine($"count at end:{count}");
        }
    }
}