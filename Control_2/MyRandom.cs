using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_2
{
    internal class MyRandom
    {
        private static int _seed = Environment.TickCount;
        private static Random _random = new Random(_seed);

        public static int nextInt()
        {
            return _random.Next(1,10);
        }
    }
}
