using NSwag.CodeGeneration.TypeScript;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace HamedStack.CodeBridge.AspNetCore;

public class SwaggerCodeBridgeMiddleware
{
    private readonly RequestDelegate _next;

    public SwaggerCodeBridgeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IOptions<SwaggerCodeBridgeOption> configureOption)
    {
        if (context.Request.Path.Value == $"/{configureOption.Value.OutputEndpoint.Trim('/')}" && context.Request.Method == "GET")
        {
            var document = NSwag.OpenApiDocument.FromUrlAsync(configureOption.Value.SwaggerEndpoint).GetAwaiter().GetResult();
            var settings = configureOption.Value.Settings ?? new TypeScriptClientGeneratorSettings();
            var generator = new TypeScriptClientGenerator(document, settings);
            var source = generator.GenerateFile();
            var result = configureOption.Value.Process?.Invoke(source) ?? source;
            context.Response.ContentType = configureOption.Value.ContentType;
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync(result);
            return;
        }
        await _next(context);
    }
}