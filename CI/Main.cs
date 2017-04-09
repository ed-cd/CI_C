using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CI
{
    class XXX
    {
        public static void Main(string[] args)
        {
            //TestAsync.Test5Tasks();
            //            new TestYieldReturn().IterateTwice();
            //new DP().Run();
//            new DP_V2().Run();
            var ii1 = new TestInOrder() {Name = "1"};
            var ii2 = new TestInOrder() {Name = "2",Next = ii1};
            var ii3 = new TestInOrder() {Name = "3",Next = ii2};
            new Thread(ii1.Run).Start();
            new Thread(ii2.Run).Start();
            new Thread(ii3.Run).Start();
            ii3.OnSignalled(EventArgs.Empty);
        }
    }
}