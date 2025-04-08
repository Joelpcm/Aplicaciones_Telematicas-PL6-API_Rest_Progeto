namespace Progeto.Geometry
{
    public class Vector
    {
        // Variables privadas de tipo double
        private double _x;
        private double _y;

        // Devuelve o modifica el valor de la coordenada x
        public double x
        {
            get { return _x; }
            set { _x = value; }
        }

        //Devuelve o modifica el valor de la coordenada y
        public double y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Constructor de Vector
        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // Constructor de Vector a partir de dos puntos
        public Vector(Point p1, Point p2)
        {
            _x = p1.x - p2.x;
            _y = p1.y - p2.y;
        }

        //Devuelve la distancia cuadrada entre dos vectores
        public double Magnitude
        {
            get
            {
                return System.Math.Sqrt(_x * _x + _y * _y);
            }
        }

        // Devuelve el vector perpendicular a otro.
        public Vector Perpendicular
        {
            get
            {
                return new Vector(_y, -_x);
            }
        }

        // Devuelve el vector unitario
        public void Normalize()
        {
            double norm = this.Magnitude;

            _x /= norm;
            _y /= norm;
        }

        // Adapta la operacion de suma a la suma de vectores
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1._x + v2._x, v1._y + v2._y);
        }

        // Adapta la operacion de resta a la resta de vectores
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1._x - v2._x, v1._y - v2._y);
        }

        // Multiplca un vector por otro
        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1._x * v2._x + v1._y * v2._y;
        }

        // Hace el producto cruzado entre dos vectores
        public static double CrossProduct(Vector v1, Vector v2)
        {
            return v1.x * v2.y - v1.y * v2.x;
        }


        // Adapta la operacion de suma a la suma de un vector y un escalar
        public static Vector operator +(Vector v, double value)
        {
            return new Vector(v._x + value, v._y + value);
        }

        // Adapta la operacion de resta a la resta de un vector y un escalar
        public static Vector operator -(Vector v, double value)
        {
            return new Vector(v._x - value, v._y - value);
        }

        // Adapta la operacion de multiplicacion a la multiplicacion de un vector y un escalar
        public static Vector operator *(Vector v, double value)
        {
            return new Vector(v._x * value, v._y * value);
        }
    }
}