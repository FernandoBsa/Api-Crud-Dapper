using System.Data;
using Data;
using Data.Repository;
using Domain.Interface;
using Npgsql;
using Service.AutoMapper;
using Service.Interface;
using Service.Serivce;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

        #region Repositorio
        builder.Services.AddScoped<IGenericRepository, GenericRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        #endregion
        
        #region Servico
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        #endregion
        
        #region AutoMapper
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        #endregion
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}