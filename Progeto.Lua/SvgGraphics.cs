using Progeto.Geometry;
using System;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Progeto.Lua
{
    //Convierte objetos como Segment, Circle y Point en elementos SVG para su representación gráfica.
    public class SvgGraphics : IGraphics
    {
        // Almacena el contenido SVG generado.
        private StringBuilder content = new StringBuilder();

        // Dibuja un segmento en SVG
        public void Draw(Segment s, Color color, double width)
        {
            var lineStr = "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" style=\"{4}\"/>\n";
            content.AppendFormat(CultureInfo.InvariantCulture, lineStr, s.InitialPoint.x, s.InitialPoint.y, s.FinalPoint.x, s.FinalPoint.y, toStyle(color, width));
        }

        // Dibuja un círculo en SVG
        public void Draw(Circle c, Color color, double width)
        {
            var lineStr = "<circle cx=\"{0}\" cy=\"{1}\" r=\"{2}\" style =\"{3}\"/>\n";
            content.AppendFormat(CultureInfo.InvariantCulture, lineStr, c.Center.x, c.Center.y, c.Radius, toStyle(color, width));
        }

        // Dibuja un punto como una elipse pequeña en SVG
        public void Draw(Geometry.Point p, Color color, double width)
        {
            var ellipseStr = "<ellipse cx=\"{0}\" cy=\"{1}\" rx=\"{2}\" ry=\"{3}\" style=\"{4}\"/>\n";
            content.AppendFormat(CultureInfo.InvariantCulture, ellipseStr, p.x, p.y, width, width, toStyle(color, width));
        }

        // Devuelve todo el contenido SVG generado
        public string Text()
        {
            var start = "<svg xmlns=\"http://www.w3.org/2000/svg\" id=\"drawing\" version=\"1.1\" height=\"100%\" width=\"100%\">\n";
            var end = "</svg>";
            return start + content + end;
        }

        // Crea un estilo SVG a partir de color y ancho
        private string toStyle(Color color, double width)
        {
            return String.Format(CultureInfo.InvariantCulture, "stroke-width:{0};stroke:{1};fill:none;", width, toColorString(color));
        }

        // Convierte el color en formato SVG (usa rgb)
        private string toColorString(Color c)
        {
            return string.Format("rgb({0},{1},{2})", c.R, c.G, c.B);
        }
    }
}