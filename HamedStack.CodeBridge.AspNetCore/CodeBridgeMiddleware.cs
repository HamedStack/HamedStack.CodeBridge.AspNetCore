using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TypeGen.Core.Generator;

namespace HamedStack.CodeBridge.AspNetCore;

public class CodeBridgeMiddleware
{
    private readonly RequestDelegate _next;

    public CodeBridgeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IOptions<CodeBridgeOption> configureOption)
    {
        if (context.Request.Method != "GET")
        {
            await _next(context);
            return;
        }

        var assemblies = configureOption.Value.Assemblies ?? new List<Assembly> { Assembly.GetEntryAssembly()! };

        var types = assemblies.SelectMany(t => t.GetTypes())
                .Where(t => t.GetCustomAttributes(typeof(CodeBridgeEndpoint), false).Length > 0)
                .Select(t => new
                {
                    Endpoint = ((CodeBridgeEndpoint)t.GetCustomAttribute(typeof(CodeBridgeEndpoint))!).Route.Trim('/'),
                    Type = t
                }).ToList()
            ;

        var blacklists = types.Where(t => $"/{t.Endpoint}" != context.Request.Path.Value)
            .Select(x => x.Type.Name).ToList();

        if (types.Count == blacklists.Count)
        {
            await _next(context);
            return;
        }

        var result = TypeGenUtility.Generate(Assembly.GetEntryAssembly()!, new GeneratorOptions()
        {
            TypeBlacklist = configureOption.Value.TypeBlacklist.Union(blacklists).ToHashSet(),
            CreateIndexFile = configureOption.Value.CreateIndexFile,
            CsAllowNullsForAllTypes = configureOption.Value.CsAllowNullsForAllTypes,
            CsDefaultValuesForConstantsOnly = configureOption.Value.CsDefaultValuesForConstantsOnly,
            CsNullableTranslation = configureOption.Value.CsNullableTranslation,
            DefaultValuesForTypes = configureOption.Value.DefaultValuesForTypes,
            CustomTypeMappings = configureOption.Value.CustomTypeMappings,
            EnumStringInitializers = configureOption.Value.EnumStringInitializers,
            EnumStringInitializersConverters = configureOption.Value.EnumStringInitializersConverters,
            EnumValueNameConverters = configureOption.Value.EnumValueNameConverters,
            ExplicitPublicAccessor = configureOption.Value.ExplicitPublicAccessor,
            ExportTypesAsInterfacesByDefault = configureOption.Value.ExportTypesAsInterfacesByDefault,
            FileHeading = configureOption.Value.FileHeading,
            FileNameConverters = configureOption.Value.FileNameConverters,
            IndexFileExtension = configureOption.Value.IndexFileExtension,
            PropertyNameConverters = configureOption.Value.PropertyNameConverters,
            SingleQuotes = configureOption.Value.SingleQuotes,
            TabLength = configureOption.Value.TabLength,
            TypeNameConverters = configureOption.Value.TypeNameConverters,
            TypeScriptFileExtension = configureOption.Value.TypeScriptFileExtension,
            TypeUnionsForTypes = configureOption.Value.TypeUnionsForTypes,
            UseDefaultExport = configureOption.Value.UseDefaultExport,
            UseImportType = configureOption.Value.UseImportType,
            UseTabCharacter = configureOption.Value.UseTabCharacter
            
        });
        context.Response.ContentType = configureOption.Value.ContentType;
        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsync(result);
    }
}