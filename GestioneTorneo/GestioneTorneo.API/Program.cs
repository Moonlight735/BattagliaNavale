using GestioneTorneo.Business;
using GestioneTorneo.Business.Abstractions;
using GestioneStanze.ClientHttp;
using GestioneStanze.ClientHttp.Abstractions;
using GestioneTorneo.Repository;
using GestioneTorneo.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using KafkaFlow;
using KafkaFlow.Serializer;

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

builder.Services.AddDbContext<GestioneTorneoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddHttpClient<GestioneStanze.ClientHttp.Abstractions.IClientHttp, GestioneStanze.ClientHttp.ClientHttp>("GestioneStanzeClientHttp", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("GestioneStanzeClientHttp:BaseAddress").Value);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure KafkaFlow
const string topicName = "gestionetorneo-event-topic";
const string producerName = "gestionetorneo-producer";

builder.Services.AddKafka(
    kafka => kafka
        .UseMicrosoftLog()
        .AddCluster(
            cluster => cluster
                .WithBrokers(new[] { "localhost:9092" })
                .CreateTopicIfNotExists(topicName, 1, 1)
                .AddProducer(
                    producerName,
                    producer => producer
                        .DefaultTopic(topicName)
                        .AddMiddlewares(m =>
                            m.AddSerializer<KafkaFlow.Serializer.JsonCoreSerializer>()
                        )
                )
        )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
