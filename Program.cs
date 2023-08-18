using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Repositores;
using ShoppingList.Repositores.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ShoppingDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"),
        new MySqlServerVersion(new Version(8, 0, 26)),
        b => b.MigrationsAssembly(typeof(ShoppingDbContext).Assembly.FullName)));

builder.Services.AddScoped<IUserRepositores, UserRepositore>();
builder.Services.AddScoped<IProductsRepositores, ProductRepositore>();
        
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
