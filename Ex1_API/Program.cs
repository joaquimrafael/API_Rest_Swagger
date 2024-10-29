using ApplicationService;
using ApplicationService.Interfaces;
using ApplicationService.ConcreteClasses;
using FluentValidation.AspNetCore;
using Infrastructure.Interfaces;
using Infrastructure.Clients;
using System;


var builder = WebApplication.CreateBuilder(args);
// crio a instancia de aplicação

// Add services to the container.
builder.Services.AddControllers()
       .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MyObjectValidator>());
//validando os objetos a serem postados
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMyService, MyService>(); // adiciono o contexto de objeto para o construtor

// adiciono cliente para o servidor da uri passada
builder.Services.AddHttpClient<ITicketApiClient, TicketApiClient>(client =>
{
    client.BaseAddress = new Uri("http://refund-statement-dev-admin.ticket.edenred.net");
});
// adiciono no escopo do builder as minhas interfaces de regras de negocio
builder.Services.AddScoped<IStatementService, StatementService>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// estabeleço o swagger

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
