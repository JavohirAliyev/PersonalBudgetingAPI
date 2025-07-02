using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi;
using PersonalBudgetingApi.Migrations;
using PersonalBudgetingApi.Database;

var builder = WebApplication.CreateBuilder(args);

// Register AppDbContext with SQLite (update connection string as needed)
builder.Services.AddDbContext<PersonalBudgetingApi.Database.AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();