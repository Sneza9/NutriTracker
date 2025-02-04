using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<UsdaApiService>();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registracija servisa - klase direktno jer imam samo jednu implementaciju UserService-a pa mi ne treba Interface 
// builder.Services.AddScoped<UsdaApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options=>{
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
} 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
