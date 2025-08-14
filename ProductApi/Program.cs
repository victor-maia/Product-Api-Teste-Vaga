using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Data.Repositories;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Configuração dos Serviços (Injeção de Dependência) ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb")); // Usa banco em memória

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Adiciona Controllers
builder.Services.AddControllers();

// Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Product API", Version = "v1" });
});

// CORS para React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()    // permite qualquer domínio
            .AllowAnyHeader()    // permite qualquer header
            .AllowAnyMethod());  // permite qualquer método HTTP
});


var app = builder.Build();

// --- Pipeline HTTP ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1"));
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization(); // Controllers usam autorização

app.MapControllers(); // Mapeia todos os controllers

app.Run();
