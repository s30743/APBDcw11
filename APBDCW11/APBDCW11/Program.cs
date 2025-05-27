using APBDCW11.Dal;
using APBDCW11.Service;
using Microsoft.EntityFrameworkCore;

namespace APBDCW11;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
    
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddDbContext<DatabaseContext>(options => 
            options.UseSqlServer(connectionString)
        );
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IpatientService, patientService>();
        builder.Services.AddScoped<IPrescrpitonServicw, PrescriptionService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        

        app.Run();
    }
}