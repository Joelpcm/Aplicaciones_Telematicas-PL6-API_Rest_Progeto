namespace Progeto.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(builder => builder
               .SetIsOriginAllowed((host) => true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               );

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
