using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskMgmt.Data;
using TaskMgmt.Interfaces.IServices;
using TaskMgmt.Services;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<TaskMgmtContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TaskMgmtDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
        });

        builder.Services.AddScoped<ITaskDetailsService, TaskDetailsService>();
        builder.Services.AddScoped<ICommentsService, CommentsService>();

        var app = builder.Build();
        app.UseCors(builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        }

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}