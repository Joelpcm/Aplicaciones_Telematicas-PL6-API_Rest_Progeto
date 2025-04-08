using Xunit;
using Progeto.Geometry;
using System.Drawing;

namespace Progeto.Geometry.UnitaryTests
{
    public class PointTest
    {
        [Fact]
        public void Point_ShouldReturnCorrectCoordinates()
        {
            var point = new Point(3.5, -2.1);

            Assert.Equal(3.5, point.x);
            Assert.Equal(-2.1, point.y);
        }

        [Fact]
        public void Point_ShouldAllowCoordinateModification()
        {
            var point = new Point(0, 0);

            point.x = 5.2;
            point.y = -3.4;

            Assert.Equal(5.2, point.x);
            Assert.Equal(-3.4, point.y);
        }

        [Fact]
        public void Point_ShouldCalculateSquaredDistanceCorrectly()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);

            var squaredDistance = Point.SquaredDistance(p1, p2);

            Assert.Equal(25, squaredDistance);
        }

        [Fact]
        public void Point_ShouldCalculateDistanceCorrectly()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);

            var distance = Point.Distance(p1, p2);

            Assert.Equal(5, distance);
        }

        [Fact]
        public void Point_ShouldCalculateDistanceToAnotherPoint()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);

            var distance = p1.Distance(p2);

            Assert.Equal(5, distance);
        }

        [Fact]
        public void Point_ShouldSubtractTwoPointsToReturnVector()
        {
            var p1 = new Point(4, 5);
            var p2 = new Point(1, 1);

            var vector = p1 - p2;

            Assert.Equal(3, vector.x);
            Assert.Equal(4, vector.y);
        }

        [Fact]
        public void Point_ShouldAddVectorToPoint()
        {
            var point = new Point(1, 1);
            var vector = new Vector(3, 4);

            var result = point + vector;

            Assert.Equal(4, result.x);
            Assert.Equal(5, result.y);
        }

        [Fact]
        public void Point_ShouldSubtractVectorFromPoint()
        {
            var point = new Point(4, 5);
            var vector = new Vector(3, 4);

            var result = point - vector;

            Assert.Equal(1, result.x);
            Assert.Equal(1, result.y);
        }
    }
}
