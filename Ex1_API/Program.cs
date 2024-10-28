using ApplicationService;
using ApplicationService.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// crio a instancia de aplica��o

// Add services to the container.
builder.Services.AddControllers()
       .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MyObjectValidator>());
//validando os objetos a serem postados
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMyService, MyService>(); // adiciono o contexto de objeto para o construtor

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// estabele�o o swagger

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
