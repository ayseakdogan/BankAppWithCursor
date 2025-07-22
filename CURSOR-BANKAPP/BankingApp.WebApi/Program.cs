using BankingApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankingApp.Persistence;
using BankingApp.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Katman servis registration
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();