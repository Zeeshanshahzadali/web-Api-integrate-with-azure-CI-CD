using MyFirstApi.ErrorHandeling;
using MyFirstApi.Repository;

namespace MyFirstApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<StudentRepository>();
            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapGet("/", context =>
            {
                context.Response.Redirect("swagger"); // no leading slash
                return Task.CompletedTask;
            });
            app.MapControllers();

            app.Run();
        }
    }
}
