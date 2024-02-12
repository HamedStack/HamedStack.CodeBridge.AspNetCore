using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag.CodeGeneration.OperationNameGenerators;

namespace HamedStack.CodeBridge.AspNetCore;

public static class SwaggerCodeBridgeMiddlewareExtensions
{
    public static IServiceCollection AddSwaggerCodeBridge(this IServiceCollection service,
        Action<SwaggerCodeBridgeOption> option)
    {
        service.Configure(option);
        return service;
    }

    public static IApplicationBuilder UseSwaggerCodeBridge(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerCodeBridgeMiddleware>();
    }
}