using NUnit.Framework;
using System.Collections.Generic;
using DriverMatcher;

namespace DriverMatcher.Tests
{
    [TestFixture]
    public class DriverMatcherTests
    {
        [Test]
        public void FindDrivers_Sort_ReturnsFiveClosest()
        {
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1),
                new Driver(3, 2, 2),
                new Driver(4, 3, 3),
                new Driver(5, 4, 4),
                new Driver(6, 5, 5)
            };

            var result = DriverSearcher.FindDrivers_Sort(drivers, 0, 0);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[4].Id, Is.EqualTo(5));
        }

        [Test]
        public void FindDrivers_Radius_ReturnsFiveClosest()
        {
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1),
                new Driver(3, 2, 2),
                new Driver(4, 3, 3),
                new Driver(5, 4, 4),
                new Driver(6, 10, 10)
            };

            var result = DriverSearcher.FindDrivers_Radius(drivers, 0, 0);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result.Exists(d => d.Id == 1), Is.True);
            Assert.That(result.Exists(d => d.Id == 6), Is.False);
        }

        [Test]
        public void FindDrivers_TopK_ReturnsFiveClosest()
        {
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1),
                new Driver(3, 2, 2),
                new Driver(4, 3, 3),
                new Driver(5, 4, 4),
                new Driver(6, 5, 5)
            };

            var result = DriverSearcher.FindDrivers_TopK(drivers, 0, 0);

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[4].Id, Is.EqualTo(5));
        }

        [Test]
        public void GetDistanceTo_CalculatesCorrectly()
        {
            var driver = new Driver(1, 3, 4);
            double distance = driver.GetDistanceTo(0, 0);

            Assert.That(distance, Is.EqualTo(5.0).Within(0.001));
        }

        [Test]
        public void FindDrivers_WithEmptyList_ReturnsEmpty()
        {
            var drivers = new List<Driver>();
            var result = DriverSearcher.FindDrivers_Sort(drivers, 0, 0);

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void FindDrivers_WithLessThanFive_ReturnsAll()
        {
            var drivers = new List<Driver>
            {
                new Driver(1, 0, 0),
                new Driver(2, 1, 1)
            };

            var result = DriverSearcher.FindDrivers_Sort(drivers, 0, 0);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[1].Id, Is.EqualTo(2));
        }
    }
}