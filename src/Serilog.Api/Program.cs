using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
        configuration.WriteTo.Console();
        // configuration.WriteTo.File("/Users/john.doe/Downloads/serilog-api.log");
    });

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options => { options.DescribeAllParametersInCamelCase(); });

services.AddRouting(options => options.LowercaseUrls = true);

var application = builder.Build();

application.UseSerilogRequestLogging();

application.UseSwagger();
application.UseSwaggerUI(
    options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

application.UseRouting();

application.MapGet(
    pattern: "say-hello",
    handler: (ILogger<Program> logger) => logger.LogInformation("Hello"));

application.Run();