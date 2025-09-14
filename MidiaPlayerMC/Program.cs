using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Data;
using MidiaPlayerMC.Interfaces;
using MidiaPlayerMC.Models;
using MidiaPlayerMC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Jun��o das Interfaces com as Classes Reposit�rios
builder.Services.AddScoped<IMediaInterface, MediaService>();
builder.Services.AddScoped<IPlaylistInterface, PlaylistService>();

// Configurando a conex�o com o banco de dados adicionando a depend�ncia.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
