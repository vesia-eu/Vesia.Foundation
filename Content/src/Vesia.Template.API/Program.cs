using Vesia.Template.API.Extensions;
using Vesia.Template.Application;
using Vesia.Template.Infrastructure;
using Vesia.Template.Infrastructure.Configuration;
using Vesia.Dispatch;
using Vesia.Dispatch.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<AppSettings>()
    .Bind(builder.Configuration.GetSection("AppSettings"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var config = builder.Configuration.GetSection("AppSettings").Get<AppSettings>() 
             ?? throw new InvalidOperationException("AppSettings section is missing or invalid in configuration. Check AppSettings.json");

builder.Services.AddOpenApi();

// Add Vesia.Dispatch to Register all Command- and QueryHandlers
builder.Services.AddDispatch(options =>
{
    options.CommandLogging = LoggingMode.All;
    options.QueryLogging = LoggingMode.OptIn;
});

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

app.Run();
