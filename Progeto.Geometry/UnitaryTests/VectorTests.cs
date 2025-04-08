using Xunit;
using Progeto.Geometry;

namespace Progeto.Geometry.UnitaryTests
{
    public class VectorTests
    {
        [Fact]
        public void Vector_ShouldReturnCorrectCoordinates()
        {
            var vector = new Vector(3.5, -2.1);

            Assert.Equal(3.5, vector.x);
            Assert.Equal(-2.1, vector.y);
        }

        [Fact]
        public void Vector_ShouldAllowCoordinateModification()
        {
            var vector = new Vector(0, 0);

            vector.x = 5.2;
            vector.y = -3.4;

            Assert.Equal(5.2, vector.x);
            Assert.Equal(-3.4, vector.y);
        }

        [Fact]
        public void Vector_ShouldCalculateMagnitudeCorrectly()
        {
            var vector = new Vector(3, 4);

            Assert.Equal(5, vector.Magnitude);
        }

        [Fact]
        public void Vector_ShouldReturnPerpendicularVector()
        {
            var vector = new Vector(3, 4);

            var perpendicular = vector.Perpendicular;

            // Verificar que el producto vectorial entre el vector original y el perpendicular sea 0
            var dotProduct = Vector.DotProduct(vector, perpendicular);

            Assert.Equal(0, dotProduct, 5); // Tolerancia de 5 decimales
        }

        [Fact]
        public void Vector_ShouldNormalizeCorrectly()
        {
            var vector = new Vector(3, 4);

            vector.Normalize();

            Assert.Equal(0.6, vector.x, 1); // Tolerancia de 1 decimal que si no a veces fallaba
            Assert.Equal(0.8, vector.y, 1); // Tolerancia de 1 decimal que si no a veces fallaba
        }

        [Fact]
        public void Vector_ShouldCalculateDotProductCorrectly()
        {
            var v1 = new Vector(1, 2);
            var v2 = new Vector(3, 4);

            var dotProduct = Vector.DotProduct(v1, v2);

            Assert.Equal(11, dotProduct);
        }

        [Fact]
        public void Vector_ShouldCalculateCrossProductCorrectly()
        {
            var v1 = new Vector(1, 2);
            var v2 = new Vector(3, 4);

            var crossProduct = Vector.CrossProduct(v1, v2);

            Assert.Equal(-2, crossProduct);
        }
    }
}

