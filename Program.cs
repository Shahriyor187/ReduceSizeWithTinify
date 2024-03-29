using ReduceSizeTinify.Interface;
using ReduceSizeTinify.Service;

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add endpoint routing for API Explorer
builder.Services.AddEndpointsApiExplorer();

// Add Swagger/OpenAPI generation
builder.Services.AddSwaggerGen();

// Register the ImageService with transient lifetime
builder.Services.AddTransient<IImageService, ImageService>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();