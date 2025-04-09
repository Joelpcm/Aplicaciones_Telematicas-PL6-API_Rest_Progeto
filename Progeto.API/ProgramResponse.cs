namespace Progeto.API
{
    // Modelo para las respuestas de la API
    public class ProgramResponse
    {
        public required string Result { get; set; } // Resultado
        public required string Svg { get; set; } // SVG
        public double ExecutionTimeMs { get; set; } // Tiempo de ejecución en milisegundos
    }
}
