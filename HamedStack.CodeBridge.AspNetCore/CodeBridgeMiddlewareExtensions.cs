using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HamedStack.CodeBridge.AspNetCore;

public static class CodeBridgeMiddlewareExtensions
{
    public static IServiceCollection AddCodeBridge(this IServiceCollection service, Action<CodeBridgeOption>? option = default)
    {
        option ??= _ => { };
        service.Configure(option);

        return service;
    }

    public static IApplicationBuilder UseCodeBridge(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CodeBridgeMiddleware>();
    }
}