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

            // Endpoint para subir archivos
            app.MapPost("/upload", async (HttpRequest request) =>
            {
                if (!request.HasFormContentType || request.Form.Files.Count == 0)
                {
                    return Results.BadRequest("No se ha enviado ningún archivo.");
                }

                var file = request.Form.Files[0];
                var uploadsFolder = Path.Combine(app.Environment.WebRootPath, "uploads");

                // Crear la carpeta "uploads" si no existe
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, file.FileName);

                // Guardar el archivo en el servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Results.Ok(new { Message = "Archivo subido exitosamente.", FileName = file.FileName });
            });

            // Endpoint para listar archivos en la carpeta "uploads"
            app.MapGet("/list-uploads", () =>
            {
                var uploadsFolder = Path.Combine(app.Environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    return Results.Ok(new List<string>()); // Si no existe la carpeta devolvemos lista vacía
                }

                var files = Directory.GetFiles(uploadsFolder)
                                     .Select(Path.GetFileName) // Obtener solo los nombres de los archivos
                                     .ToList();

                return Results.Ok(files);
            });

            app.Run();
        }
    }
}
