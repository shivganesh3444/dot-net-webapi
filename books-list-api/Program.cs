using books_list_api.Data;
using books_list_api.Data.Services;
using books_list_api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//configure serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Read settings from appsettings.json
    .Enrich.FromLogContext() //add contexual information
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) // Log to rolling files
    .CreateLogger();

//add serilog to asp.net core pipeline
builder.Host.UseSerilog();

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
    // //API header versioning configuration
    //builder.ApiVersionReader = new HeaderApiVersionReader("custom-version");
    // //API content type versioning configuration
    //builder.ApiVersionReader = new MediaTypeApiVersionReader();
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
