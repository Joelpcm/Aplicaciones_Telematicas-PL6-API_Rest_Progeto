using Xunit;
using Progeto.Geometry;
using System.Drawing;
using System.Linq;

namespace Progeto.Lua.UnitaryTests
{
    public class LuaInterpreterTests
    {
        [Fact]
        public void LuaInterpreter_ShouldExecutePrintFunction()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
                print('Hello, Lua!')
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("Hello, Lua!", result[0]);
        }

        [Fact]
        public void LuaInterpreter_ShouldSetColorCorrectly()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
            color(255, 0, 0) -- Cambiar el color a rojo
            draw(Point(0, 0))
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            // Ajusta el sub-string según el formato real del SVG
            Assert.Contains("rgb(255,0,0)", result[1]); // Verifica que el color rojo esté en el SVG
        }


        [Fact]
        public void LuaInterpreter_ShouldSetWidthCorrectly()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
            width(5) -- Cambiar el grosor a 5
            draw(Point(0, 0))
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("stroke-width:5", result[1]); // Verifica que el grosor esté en el SVG
        }

        [Fact]
        public void LuaInterpreter_ShouldDrawPoint()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
            draw(Point(1, 2))
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("ellipse", result[1]); // Verifica que se dibuje un punto (como un círculo en SVG)
        }


        [Fact]
        public void LuaInterpreter_ShouldDrawSegment()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
                draw(Segment(Point(0, 0), Point(3, 4)))
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("line", result[1]); // Verifica que se dibuje un segmento (como una línea en SVG)
        }

        [Fact]
        public void LuaInterpreter_ShouldHandleInvalidLuaCode()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
                invalid_function()
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("Exception", result[0]); // Verifica que se maneje la excepción
        }

        [Fact]
        public void LuaInterpreter_ShouldDrawCircle()
        {
            var interpreter = new LuaInterpreter();
            string luaCode = @"
                draw(Circle(Point(5, 5), 10))
            ";

            var result = interpreter.RunProgram(luaCode).ToArray();

            Assert.Contains("circle", result[1]); // Verifica que se dibuje un círculo en el SVG
        }
    }
}

