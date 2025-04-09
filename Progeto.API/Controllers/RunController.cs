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
                return BadRequest(new { error = "El c�digo fuente no puede estar vac�o." });
            }

            // Crear una instancia del interprete de Lua
            var luaInterpreter = new LuaInterpreter();
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Ejecutar el c�digo Lua
                var result = luaInterpreter.RunProgram(request.Source);
                stopwatch.Stop();

                // Crear la respuesta
                var response = new ProgramResponse
                {
                    Result = result.ElementAt(0), // Resultado
                    Svg = result.ElementAt(1), // SVG
                    ExecutionTimeMs = stopwatch.Elapsed.TotalMilliseconds // Tiempo de ejecuci�n
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
