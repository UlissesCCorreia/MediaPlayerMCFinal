﻿using Microsoft.EntityFrameworkCore;
using MidiaPlayerMC.Data;
using MidiaPlayerMC.Interfaces;
using MidiaPlayerMC.Models;
using MidiaPlayerMC.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicione o serviço de CORS aqui, antes do builder.Services.Build()
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin() // Permite qualquer origem.
                   .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.).
                   .AllowAnyHeader(); // Permite qualquer cabeçalho.
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Junção das Interfaces com as Classes Repositórios
builder.Services.AddScoped<IMediaInterface, MediaService>();
builder.Services.AddScoped<IPlaylistInterface, PlaylistService>();
builder.Services.AddScoped<IMediaPlaylistInterface, MediaPlaylistService>();

builder.Services.AddHttpClient();

// Configurando a conexão com o banco de dados adicionando a dependência.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
