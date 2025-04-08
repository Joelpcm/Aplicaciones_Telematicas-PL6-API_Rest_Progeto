using Xunit;

namespace Progeto.Geometry.UnitaryTests
{
    public class CircleTests
    {
        [Fact]
        public void Circle_ShouldReturnCenterAndRadius()
        {
            var center = new Point(2, 3);
            double radius = 5;
            var circle = new Circle(center, radius);

            Assert.Equal(center, circle.Center);
            Assert.Equal(radius, circle.Radius);
        }

        [Fact]
        public void Circle_ShouldCalculateCorrectPerimeter()
        {
            var circle = new Circle(new Point(0, 0), 1);
            double expected = 2 * Math.PI * 1;

            Assert.Equal(expected, circle.Perimeter, precision: 5);
        }
    }
}
