using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverMatcher
{
    public class Driver
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Driver(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public double GetDistanceTo(int orderX, int orderY)
        {
            return Math.Sqrt(Math.Pow(X - orderX, 2) + Math.Pow(Y - orderY, 2));
        }
    }
}
