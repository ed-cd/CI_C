using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    class XXX
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(RecursiveFileSearch.findFile("Elerian-20161210-14.save", "C:\\Users\\edmitriev\\Documents"));
            Console.WriteLine(RecursiveFileSearch.findFile("Elerian-20161210-14.sav", "C:\\Users\\edmitriev\\Documents"));
        }
        public static List<int> fib(int n1, int n2)
        {
            if (n1 <= n2)
            {
                throw new Exception("not");
            }

            var list = new List<int> { n1, n2 };
            while (list.Last() != 0)
            {
                list.Add(list[list.Count - 2] - list[list.Count - 1]);
                if (list.Last() < 0) throw new Exception("not");
            }
            return list;
        }
    }
    
}
