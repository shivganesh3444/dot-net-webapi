using books_list_api.Data;
using books_list_api.Data.Services;
using books_list_api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//configure connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

//register db context 
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//register the service
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublishersService>();

//register api version with default version
builder.Services.AddApiVersioning(builder =>
{
    builder.DefaultApiVersion = new ApiVersion(1, 0);
    builder.AssumeDefaultVersionWhenUnspecified = true;
});

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

//built in exception handling
//app.ConfigureBuildInMiddlewareException();

//Custom exception using middleware
//app.UseCustomExceptionMiddleware();

app.MapControllers();

//AppDbInitializer.Seed(app);

app.Run();
