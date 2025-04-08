using Xunit;
using Progeto.Geometry;
using System.Drawing;

namespace Progeto.Geometry.UnitaryTests
{
    public class SegmentTests
    {
        [Fact]
        public void Segment_ShouldReturnCorrectInitialAndFinalPoints()
        {
            var p0 = new Point(1, 2);
            var p1 = new Point(3, 4);

            var segment = new Segment(p0, p1);

            Assert.Equal(p0, segment.InitialPoint);
            Assert.Equal(p1, segment.FinalPoint);
        }

        [Fact]
        public void Segment_ShouldCalculateMiddlePointCorrectly()
        {
            var p0 = new Point(1, 1);
            var p1 = new Point(3, 3);

            var segment = new Segment(p0, p1);

            var middlePoint = segment.MiddlePoint;

            Assert.Equal(2, middlePoint.x);
            Assert.Equal(2, middlePoint.y);
        }

        [Fact]
        public void Segment_ShouldCalculateLengthCorrectly()
        {
            var p0 = new Point(0, 0);
            var p1 = new Point(3, 4);

            var segment = new Segment(p0, p1);

            Assert.Equal(5, segment.Length);
        }

        [Fact]
        public void Segment_ShouldReturnCorrectLine()
        {
            var p0 = new Point(1, 1);
            var p1 = new Point(3, 3);

            var segment = new Segment(p0, p1);

            var line = segment.Line;

            Assert.Equal(2, line.a);
            Assert.Equal(-2, line.b);
            Assert.Equal(0, line.c);
        }
    }
}
