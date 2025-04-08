using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using web_api_catalog.Context;
using web_api_catalog.Validators;
using FluentValidation;
using web_api_catalog.Extensions;
using web_api_catalog.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<CategoryValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<ApiLoggingFilter>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.ConfigureExcepetionHandler();
  /*app.UseSwagger();
    app.UseSwaggerUI();*/
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
