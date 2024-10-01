using GestioneGioco.Business;
using GestioneGioco.Business.Abstractions;
using GestioneGioco.Repository;
using GestioneGioco.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddDbContext<GestioneGiocoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IGrigliaDiGiocoRepository, GrigliaDiGiocoRepository>();
builder.Services.AddScoped<IGrigliaPartitaRepository, GrigliaPartitaRepository>();
builder.Services.AddScoped<IMossaRepository, MossaRepository>();
builder.Services.AddScoped<IPartitaRepository, PartitaRepository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
