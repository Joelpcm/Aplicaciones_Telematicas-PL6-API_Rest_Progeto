
namespace Progeto.Geometry
{
    public class Line
    {
        // Variables privadas double
        private double _a;
        private double _b;
        private double _c;

        // Devuelve a
        public double a
        {
            get { return _a; }
        }

        // Devuelve b
        public double b
        {
            get { return _b; }
        }

        // Devuelve c
        public double c
        {
            get { return _c; }
        }

        // Vector orientacion
        public Vector Orientation
        {
            get { return new Vector(-_b, _a); }
        }

        // Devuelve el vector normal a la linea
        public Vector Normal
        {
            get { return new Vector(_a, _b); }
        }

        // Constructor de linea
        public Line(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        // Constructor de la linea con punto-pendiente y= m·x + b
        public Line(double m, double b)
            : this(m, -1, b) { }

        // Constructor de Linea que recibe dos puntos
        public Line(Point p1, Point p2)
            : this(p2.y - p1.y, p1.x - p2.x, (p2.x - p1.x) * p1.y - (p2.y - p1.y) * p1.x) { }

        // Constructor de Linea que recibe un vector y una distancia
        public Line(Vector normal, double distance)
            : this(normal.x, normal.y, distance) { }

        // Constructor de Linea que recibe un vector orientacion y un punto
        public Line(Vector orientation, Point p)
            : this(-orientation.y, orientation.x, orientation.y * p.x - orientation.x * p.y) { }


        // Hace la interseccion de dos lineas.
        public static Point Intersection(Line l1, Line l2)
        {
            double det = l1._a * l2._b - l1._b * l2._a;

            if (det == 0)
                return null;

            return new Point((l1._b * l2._c - l1._c * l2._b) / det,
                (l1._c * l2._a - l1._a * l2._c) / det);
        }
    }
}
