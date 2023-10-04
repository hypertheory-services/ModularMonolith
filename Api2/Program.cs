using Microsoft.AspNetCore.Mvc;

using SharedUtils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Utils>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/{num:int}", ([FromServices] Utils utils, [FromRoute] int num) =>
{
    return Results.Ok($"{num} being even is {utils.IsEven(num)}");
});

app.Run();

