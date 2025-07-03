using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Database;

var builder = WebApplication.CreateBuilder(args);

// Connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext with SQLite
builder.Services.AddDbContext<PersonalBudgetingDbContext>(options =>
    options.UseSqlite(connectionString));

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
