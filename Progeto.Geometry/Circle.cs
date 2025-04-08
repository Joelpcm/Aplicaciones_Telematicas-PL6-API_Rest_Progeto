using System.Drawing;

namespace Progeto.Geometry
{
    // Clase Circle que implementa la interfaz IPrimitive
    public class Circle : IPrimitive
    {
        // Variables privadas de solo lectura centro (punto) y radio (double)
        private readonly Point _center;
        private readonly double _radius;

        // Devuelve el Radius
        public double Radius
        {
            get { return _radius; }
        }

        // Devuelve el centro
        public Point Center
        {
            get { return _center; }
        }

        // Constructor de Circle que recibe un punto y un radio
        public Circle(Point center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        // Calcula el perimetro del circulo 2*pi*R
        public double Perimeter
        {
            get { return 2 * System.Math.PI * _radius; }
        }

        // Dibuja el circulo
        public void Draw(IGraphics g, Color color, double width)
        {
            g.Draw(this, color, width);
        }
    }
}