using Progeto.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progeto.Lua
{
    // Contenedor para primitivas de dibujo junto con sus atributos de color y groso
    class DrawingPrimitive
    {
        IPrimitive _primitive; // La figura geométrica a dibujar
        Color _color; // El color con que se debe dibujar
        double _width; // El grosor a dibujar

        // Retorna la figura geométrica
        public IPrimitive Primitive
        {
            get { return _primitive; }
        }
        // Retorna el color de la figura
        public Color Color
        {
            get { return _color; }
        }

        // Retorna el grosor de la figura
        public double Width
        {
            get { return _width; }
        }

        // Constructor de la clase
        public DrawingPrimitive(IPrimitive primitive, Color color, double width)
        {
            _primitive = primitive;
            _color = color;
            _width = width;
        }

        // Dibuja la figura usando el objeto gráfico g
        public void Draw(IGraphics g)
        {
            _primitive.Draw(g, _color, _width);
        }
    }
}