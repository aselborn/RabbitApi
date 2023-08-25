using RabbitApi.Models;
using RabbitApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration
    ;
//builder.Configuration.GetSection("FIS_WebAPI").Value




builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMQ"));
//builder.Services.AddHostedService<QueueHostedBackgroundService>();
builder.Services.AddSingleton<IConsumeService, ConsumeService>();
builder.Services.AddSingleton<IAddmessageService, AddMessageService>();
builder.Services.AddSingleton<IRabbitQueueService, RabbitQueueService >();

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
