namespace Progeto.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Configurar index.html como archivo predeterminado
            app.UseDefaultFiles();

            // Servir contenido estático
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "text/plain"
            });

            app.Run();
        }
    }
}
