using System.Drawing;

namespace Progeto.Geometry
{
    // Operación básica de Dibujo
    public interface IDraw
    {
        // Método Draw que debe ser implementado por las clases que implementen esta interfaz
        void Draw(IGraphics g, Color color, double width);
    }
}
