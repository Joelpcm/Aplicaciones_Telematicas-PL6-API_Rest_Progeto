namespace Progeto.API
{
    // Modelo para las peticiones que entran
    public class ProgramRequest
    {
        public required string Source { get; set; } // C�digo Lua a ejecutar
    }
}
