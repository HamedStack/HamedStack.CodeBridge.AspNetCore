using System.Reflection;
using TypeGen.Core;
using TypeGen.Core.Converters;
using TypeGen.Core.Generator;

namespace HamedStack.CodeBridge.AspNetCore;

public class CodeBridgeOption
{
    public IEnumerable<Assembly>? Assemblies { get; set; } = null;
    public TypeNameConverterCollection FileNameConverters { get; set; } = GeneratorOptions.DefaultFileNameConverters;
    public TypeNameConverterCollection TypeNameConverters { get; set; } = GeneratorOptions.DefaultTypeNameConverters;
    public MemberNameConverterCollection PropertyNameConverters { get; set; } =
        GeneratorOptions.DefaultPropertyNameConverters;
    public MemberNameConverterCollection EnumValueNameConverters { get; set; } =
        GeneratorOptions.DefaultEnumValueNameConverters;
    public MemberNameConverterCollection EnumStringInitializersConverters { get; set; } =
        GeneratorOptions.DefaultEnumStringInitializersConverters;
    public bool ExplicitPublicAccessor { get; set; } = GeneratorOptions.DefaultExplicitPublicAccessor;
    public bool SingleQuotes { get; set; } = GeneratorOptions.DefaultSingleQuotes;
    public string TypeScriptFileExtension { get; set; } = GeneratorOptions.DefaultTypeScriptFileExtension;
    public int TabLength { get; set; } = GeneratorOptions.DefaultTabLength;
    public bool UseTabCharacter { get; set; } = GeneratorOptions.DefaultUseTabCharacter;
    public bool CreateIndexFile { get; set; } = GeneratorOptions.DefaultCreateIndexFile;
    public StrictNullTypeUnionFlags CsNullableTranslation { get; set; } = GeneratorOptions.DefaultCsNullableTranslation;
    public bool CsAllowNullsForAllTypes { get; set; } = GeneratorOptions.DefaultCsAllowNullsForAllTypes;
    public bool CsDefaultValuesForConstantsOnly { get; set; } = GeneratorOptions.DefaultCsDefaultValuesForConstantsOnly;
    public IDictionary<string, string> DefaultValuesForTypes { get; set; } =
        GeneratorOptions.DefaultDefaultValuesForTypes;
    public IDictionary<string, IEnumerable<string>> TypeUnionsForTypes { get; set; } = GeneratorOptions.DefaultTypeUnionsForTypes;
    public IDictionary<string, string> CustomTypeMappings { get; set; } = GeneratorOptions.DefaultCustomTypeMappings;
    public bool EnumStringInitializers { get; set; } = GeneratorOptions.DefaultEnumStringInitializers;
    public string FileHeading { get; set; } = GeneratorOptions.DefaultFileHeading;
    public bool UseDefaultExport { get; set; } = GeneratorOptions.DefaultUseDefaultExport;
    public string IndexFileExtension { get; set; } = GeneratorOptions.DefaultIndexFileExtension;
    public bool ExportTypesAsInterfacesByDefault { get; set; } = GeneratorOptions.DefaultExportTypesAsInterfacesByDefault;
    public bool UseImportType { get; set; } = GeneratorOptions.DefaultUseImportType;
    public HashSet<string> TypeBlacklist { get; set; } = GeneratorOptions.DefaultTypeBlacklist;
    public string ContentType { get; set; } = "text/plain";

}