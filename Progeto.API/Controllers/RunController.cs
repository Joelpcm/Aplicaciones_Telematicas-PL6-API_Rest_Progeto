using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Progeto.Lua;

namespace Progeto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RunController : ControllerBase
    {
        // POST api/run
        [HttpPost]    
        public IActionResult Run([FromBody] ProgramRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Source))
            {
                return BadRequest(new { error = "El código fuente no puede estar vacío." });
            }

            // Crear una instancia del interprete de Lua
            var luaInterpreter = new LuaInterpreter();
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Ejecutar el código Lua
                var result = luaInterpreter.RunProgram(request.Source);
                stopwatch.Stop();

                // Crear la respuesta
                var response = new ProgramResponse
                {
                    Result = result.ElementAt(0), // Resultado
                    Svg = result.ElementAt(1), // SVG
                    ExecutionTimeMs = stopwatch.Elapsed.TotalMilliseconds // Tiempo de ejecución
                };

                // Devolver OK y la respuesta
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                stopwatch.Stop();
                return StatusCode(500, new
                {
                    error = "Error al ejecutar el programa.",
                    details = ex.Message,
                    executionTimeMs = stopwatch.Elapsed.TotalMilliseconds
                });
            }
        }
    }
}
