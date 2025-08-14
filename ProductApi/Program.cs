using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Data.Repositories;
using ProductApi.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Configura��o dos Servi�os (Inje��o de Depend�ncia) ---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ProductDb")); // Usa banco em mem�ria

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
            .AllowAnyOrigin()    // permite qualquer dom�nio
            .AllowAnyHeader()    // permite qualquer header
            .AllowAnyMethod());  // permite qualquer m�todo HTTP
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
app.UseAuthorization(); // Controllers usam autoriza��o

app.MapControllers(); // Mapeia todos os controllers

app.Run();
