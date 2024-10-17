using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using spendwisebase.Models;
using SpendWiseWebApp.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SpendWiseContext>(opt =>
    opt.UseSqlite("Data Source=SpendWiseDb"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SpendWiseContext>()
    .AddDefaultTokenProviders();    
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


app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
