using Vesia.Template.API.Extensions;
using Vesia.Template.Application;
using Vesia.Template.Infrastructure;
using Vesia.Template.Infrastructure.Configuration;
using Vesia.Dispatch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppSettings>()
    .Bind(builder.Configuration.GetSection("AppSettings"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var config = builder.Configuration.GetSection("AppSettings").Get<AppSettings>() 
             ?? throw new InvalidOperationException("AppSettings section is missing or invalid in configuration. Check AppSettings.json");

builder.Services.AddOpenApi();

builder.Services.AddControllers();

// Add Application Services
builder.Services.AddApplication();
// Add Infrastructure and DbContext
builder.Services.AddInfrastructure(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
