using System.Drawing;

namespace Progeto.Geometry
{
    // Aqui queda definida la clase Segmento
    public class Segment : IPrimitive
    {
        // Variables privadas de tipo Point y solo lectura
        private readonly Point _p0;
        private readonly Point _p1;

        // Constructor de Segmento
        public Segment(Point p0, Point p1)
        {
            _p0 = p0;
            _p1 = p1;
        }

        // Devuelve el punto inicial del segmento
        public Point InitialPoint
        {
            get { return _p0; }
        }

        // Devuelve el punto final del segmento
        public Point FinalPoint
        {
            get { return _p1; }
        }

        // Devuelve el punto medio del segmento
        public Point MiddlePoint
        {
            get
            {
                Vector v = _p1 - _p0;
                return _p0 + v * 0.5;
            }
        }

        //Devuelve la longitud del segmento
        public double Length
        {
            get { return _p0.Distance(_p1); }
        }

        // Devuelve una linea que va del punto inicial al final del segmento
        public Line Line
        {
            get { return new Line(_p0, _p1); }
        }


        // Dibuja el segemento
        public void Draw(IGraphics g, Color color, double width)
        {
            g.Draw(this, color, width);
        }
    }
}
