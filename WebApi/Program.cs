using ApplicationLayer.Contracts;
using InfrastructureLayer.Implementations;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer.Impletations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStudent, StudentRepo>();
builder.Services.AddScoped<IAdmin, AdminRepo>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();