namespace Progeto.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Se añade el servicio de CORS
            builder.Services.AddCors();

            var app = builder.Build();

            // Configuración de CORS
            app.UseCors(builder => builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
            );

            // index.html por defecto
            app.UseDefaultFiles();

            //Habilita archivos estáticos
            app.UseStaticFiles(); 

            app.Run();
        }
    }
}


