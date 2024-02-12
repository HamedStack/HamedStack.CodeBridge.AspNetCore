using NSwag.CodeGeneration.TypeScript;

namespace HamedStack.CodeBridge.AspNetCore;

public class SwaggerCodeBridgeOption
{
    public TypeScriptClientGeneratorSettings? Settings { get; set; }
    public string OutputEndpoint { get; set; } = null!;
    public string SwaggerEndpoint { get; set; } = null!;
    public string ContentType { get; set; } = "text/plain";
    public Func<string, string>? Process { get; set; }
}