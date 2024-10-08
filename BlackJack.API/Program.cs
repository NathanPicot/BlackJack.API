using Microsoft.AspNetCore.Cors;
using BlackJack.API.Entity;
using BlackJack.API.Interface;
using BlackJack.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services here
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IJoueurService, JoueurService>();
builder.Services.AddScoped<ICarteService, CarteService>();
builder.Services.AddScoped<IPartieService, PartieService>();
// Add services for other tables as needed

builder.Services.AddCors(options =>
{
  options.AddPolicy("MyPolicy", builder =>
  {
    builder.WithOrigins("https://nathanpicot.github.io") // Remplacez par l'origine de votre application Vue.js
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("MyPolicy"); // Apply the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();