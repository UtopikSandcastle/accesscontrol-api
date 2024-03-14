using System.Text.Json.Serialization;
using UtopikSandcastle.AccessControlAPI.Models;
using UtopikSandcastle.AccessControlAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AccessControlDatabaseSettings>(
  builder.Configuration.GetSection("AccessControlDatabase"));

builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
  });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.EnableAnnotations();
});

builder.Services.AddSingleton<AccessControlDevicesService>();
builder.Services.AddSingleton<AccessControlSystemsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Utopik Sandcastle Security API V1");
    c.InjectStylesheet("/swagger/custom.css");
    c.RoutePrefix = String.Empty;
  });
  app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials());

if (app.Environment.IsDevelopment())
{
  var devicesService = app.Services.GetRequiredService<AccessControlDevicesService>();
  await devicesService.SeedDataAsync();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
