using Presentation.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
// Retrieve PostgreSQL connection string
var connectionString = builder.Configuration.GetConnectionString("ConnStr");

// Retrieve MongoDB settings
var mongoConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
var mongoDatabaseName = builder.Configuration.GetSection("MongoDB:DatabaseName").Value;

// Add services to the container.
services.AddCors();
services.AddFramework(builder.Configuration, connectionString, mongoConnectionString, mongoDatabaseName);

builder.Services.AddControllers();
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

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
