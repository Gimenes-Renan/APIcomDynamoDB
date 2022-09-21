using APIcomDynamoDB;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeções de dependência - Adicionar serviços scoped
builder.Services.AddScoped<DynamoContext>();
builder.Services.AddScoped<IDynamoRepository, DynamoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoints
app.MapPost("/createOnDb", ([FromServices] IDynamoRepository repo, Pessoa pessoa) => repo.CreateOnDb(pessoa));
app.MapGet("/getOnDb", async ([FromServices] IDynamoRepository repo, int id) => await repo.GetOnDb(id));

//app.UseCors(policies => policies.AllowAnyOrigin());

app.Run();
