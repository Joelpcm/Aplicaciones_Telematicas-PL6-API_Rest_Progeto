using Xunit;
using Progeto.Geometry;

namespace Progeto.Tests
{
    public class LineTests
    {
        [Fact]
        public void Line_ShouldReturnCorrectParameters()
        {
            // Crear una línea en formato general: ax + by + c = 0
            var line = new Line(2, -3, 6);

            // Verificar los valores de los coeficientes
            Assert.Equal(2, line.a);
            Assert.Equal(-3, line.b);
            Assert.Equal(6, line.c);
        }

        [Fact]
        public void Line_ShouldReturnCorrectOrientationVector()
        {
            var line = new Line(2, -3, 6);

            var orientation = line.Orientation;

            Assert.Equal(3, orientation.x);
            Assert.Equal(2, orientation.y);
        }

        [Fact]
        public void Line_ShouldReturnCorrectNormalVector()
        {
            var line = new Line(2, -3, 6);

            var normal = line.Normal;

            Assert.Equal(2, normal.x);
            Assert.Equal(-3, normal.y);
        }

        [Fact]
        public void Line_ShouldCreateFromSlopeAndIntercept()
        {
            var line = new Line(2, 5); // y = 2x + 5

            Assert.Equal(2, line.a);
            Assert.Equal(-1, line.b);
            Assert.Equal(5, line.c);
        }

        [Fact]
        public void Line_ShouldCreateFromTwoPoints()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(3, 3);

            var line = new Line(p1, p2);

            Assert.Equal(2, line.a);
            Assert.Equal(-2, line.b);
            Assert.Equal(0, line.c);
        }

        [Fact]
        public void Line_ShouldCreateFromNormalVectorAndDistance()
        {
            var normal = new Vector(3, 4);
            double distance = 5;

            var line = new Line(normal, distance);

            Assert.Equal(3, line.a);
            Assert.Equal(4, line.b);
            Assert.Equal(5, line.c);
        }

        [Fact]
        public void Line_ShouldCreateFromOrientationVectorAndPoint()
        {
            var orientation = new Vector(1, 1);
            var point = new Point(2, 3);

            var line = new Line(orientation, point);

            Assert.Equal(-1, line.a);
            Assert.Equal(1, line.b);
            Assert.Equal(-1, line.c);
        }

        [Fact]
        public void Line_ShouldReturnNullForParallelLines()
        {
            var line1 = new Line(1, -1, 1); // x - y + 1 = 0
            var line2 = new Line(1, -1, 2); // x - y + 2 = 0

            var intersection = Line.Intersection(line1, line2);

            Assert.Null(intersection);
        }

        [Fact]
        public void Line_ShouldReturnNullForIntersectionWithItself()
        {
            var line = new Line(1, -1, 2); // x - y + 2 = 0

            var intersection = Line.Intersection(line, line);

            Assert.Null(intersection);
        }

        [Fact]
        public void Line_ShouldReturnIntersectionPointForNonParallelLines()
        {
            var line1 = new Line(1, -1, 0); // x - y = 0
            var line2 = new Line(1, 1, -4); // x + y - 4 = 0

            var intersection = Line.Intersection(line1, line2);

            Assert.NotNull(intersection);
            Assert.Equal(2, intersection.x);
            Assert.Equal(2, intersection.y);
        }
    }
}
