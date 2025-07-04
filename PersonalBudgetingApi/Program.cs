using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonalBudgetingDbContext>(options =>
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