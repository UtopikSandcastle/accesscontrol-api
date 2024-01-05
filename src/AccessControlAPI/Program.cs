using System.Text.Json.Serialization;
using UtopikSandcastle.AccessControl.API;
using UtopikSandcastle.AccessControl.API.Models;
using UtopikSandcastle.AccessControl.API.Services;

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
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Utopik Sandcastle Security API V1");
    c.InjectStylesheet("/swagger/custom.css");
    c.RoutePrefix = String.Empty;
  });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
