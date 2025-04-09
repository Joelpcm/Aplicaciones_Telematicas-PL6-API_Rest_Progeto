using Progeto.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progeto.Lua
{
    public class LuaInterpreter
    {

        List<DrawingPrimitive> _primitives; // Almacén de la lista de primitivas
        Color _color; // Color por defecto
        double _width; // Grosor por defecto
        StringBuilder _output;

        // Constructor
        public LuaInterpreter()
        {
            _primitives = new List<DrawingPrimitive>();
            _color = Color.Black;
            _width = 1;
            _output = new StringBuilder();
        }

        // Método CreateInterpreter para inicializar el intérprete de Lua y
        // registrar las funciones y las clases que se quiere integran en el lenguaje
        private NLua.Lua CreateInterpreter()
        {
            NLua.Lua lua = new NLua.Lua();
            lua.LoadCLRPackage();

            // RegisterFunction se encarga de registrar una función de C# en Lua
            lua.RegisterFunction("print", this, GetType().GetMethod("Print"));
            lua.RegisterFunction("draw", this, GetType().GetMethod("Draw"));
            lua.RegisterFunction("width", this, GetType().GetMethod("SetWidth"));
            lua.RegisterFunction("color", this, GetType().GetMethod("SetColor"));

            // DoString sirve para ejecutar código de Lua
            lua.DoString(@"
             luanet.load_assembly('Progeto.Geometry')

             Segment = luanet.import_type('Progeto.Geometry.Segment')
             Point = luanet.import_type('Progeto.Geometry.Point')
             Line = luanet.import_type('Progeto.Geometry.Line')
             Circle = luanet.import_type('Progeto.Geometry.Circle')
             Vector = luanet.import_type('Progeto.Geometry.Vector')
             ", "Init");

            return lua;
        }

        // Métodos normales de la clase que se ejecutaran en Lua
        public void SetColor(int r, int g, int b)
        {
            _color = Color.FromArgb(r, g, b);
        }

        public void SetWidth(double width)
        {
            _width = width;
        }

        public void Print(object o)
        {
            _output.AppendLine(o.ToString());
        }

        public void Draw(IPrimitive primitive)
        {
            if (primitive != null)
                _primitives.Add(new DrawingPrimitive(primitive, _color, _width));
        }


        // Realiza la ejecución del código Lua

        public IEnumerable<string> RunProgram(string program)
        {
            _primitives.Clear();
            _output.Clear();

            try
            {
                NLua.Lua lua = CreateInterpreter();

                lua.DoString(program, "Program");
            }
            catch (Exception ex)
            {
                _output.AppendLine("Exception: " + ex.Message);
            }

            SvgGraphics svg = new SvgGraphics();
            foreach (var p in _primitives)
                p.Draw(svg);
            string svgText = svg.Text();

            return new string[] { _output.ToString(), svgText };
        }
    }
}
