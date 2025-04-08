using System.Drawing;
using System.Numerics;

namespace Progeto.Geometry
{

    // Aqui queda definida la clase Punto
    public class Point : IPrimitive
    {
        // Variablis privadas double
        private double _x;
        private double _y;

        // Para modificar y acceder al valor
        public double x
        {
            get { return _x; }
            set { _x = value; }
        }

        // Para modificar y acceder al valor
        public double y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Constructor de Punto
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // Calcula la distancia cuadrada entre dos puntos
        public static double SquaredDistance(Point p1, Point p2)
        {
            double dx = p1._x - p2._x;
            double dy = p1._y - p2._y;

            return dx * dx + dy * dy;
        }

        // Calcula la distancia entre dos puntos
        public static double Distance(Point p1, Point p2)
        {
            return System.Math.Sqrt(SquaredDistance(p1, p2));
        }

        // Calcula la distancia entre un punto(this) y otro
        public double Distance(Point p)
        {
            return System.Math.Sqrt(SquaredDistance(this, p));
        }

        // Vector que va de p2 a p1
        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p1._x - p2._x, p1._y - p2._y);
        }

        // Suma un punto y un vector
        public static Point operator +(Point p, Vector v)
        {
            return new Point(p._x + v.x, p._y + v.y);
        }

        // Resta un punto y un vector
        public static Point operator -(Point p, Vector v)
        {
            return new Point(p._x - v.x, p._y - v.y);
        }

        // Dibuja un punto
        public void Draw(IGraphics g, Color color, double width)
        {
            g.Draw(this, color, width);
        }
    }
}
