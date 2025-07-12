using Microsoft.EntityFrameworkCore;
using PersonalBudgetingApi.Data;
using PersonalBudgetingApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonalBudgetingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryService, CategoriesService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

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

app.MapControllers();

app.Run();