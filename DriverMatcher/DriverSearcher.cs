using System;
using System.Collections.Generic;
using System.Linq;

namespace DriverMatcher
{
    public static class DriverSearcher
    {
        public static List<Driver> FindDrivers_Sort(List<Driver> drivers, int orderX, int orderY)
        {
            return drivers.OrderBy(d => d.GetDistanceTo(orderX, orderY)).Take(5).ToList();
        }

        public static List<Driver> FindDrivers_Radius(List<Driver> drivers, int orderX, int orderY)
        {
            var result = new List<Driver>();
            double radius = 0;
            while (result.Count < 5 && radius < 20)
            {
                result = drivers.Where(d => d.GetDistanceTo(orderX, orderY) <= radius).ToList();
                radius += 0.5;
            }
            return result.Take(5).ToList();
        }

        public static List<Driver> FindDrivers_TopK(List<Driver> drivers, int orderX, int orderY)
        {
            var top5 = new List<Driver>();

            foreach (var driver in drivers)
            {
                if (top5.Count < 5)
                {
                    top5.Add(driver);
                    top5.Sort((a, b) => a.GetDistanceTo(orderX, orderY).CompareTo(b.GetDistanceTo(orderX, orderY)));
                }
                else
                {
                    double dist = driver.GetDistanceTo(orderX, orderY);
                    if (dist < top5.Last().GetDistanceTo(orderX, orderY))
                    {
                        top5.RemoveAt(4);
                        top5.Add(driver);
                        top5.Sort((a, b) => a.GetDistanceTo(orderX, orderY).CompareTo(b.GetDistanceTo(orderX, orderY)));
                    }
                }
            }
            return top5;
        }
    }
}
