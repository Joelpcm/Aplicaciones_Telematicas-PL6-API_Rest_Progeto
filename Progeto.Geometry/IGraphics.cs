using System.Drawing;

namespace Progeto.Geometry
{
    // Metodos para dibujar diferentes tipos de figuras geometricas.
    public interface IGraphics
    {
        void Draw(Segment s, Color color, double width);
        void Draw(Circle s, Color color, double width);
        void Draw(Point s, Color color, double width);
    }
}
