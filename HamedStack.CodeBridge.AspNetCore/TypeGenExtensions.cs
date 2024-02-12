using System.Reflection;
using TypeGen.Core.Generator;

namespace HamedStack.CodeBridge.AspNetCore
{
    public static class TypeGenUtility
    {
        public static string Generate(Assembly assembly, GeneratorOptions? options = default)
        {
            var baseDir = Path.Combine(Directory.GetCurrentDirectory(), "Generated");
            var directory = new DirectoryInfo(baseDir);
            var generator = new Generator
            {
                Options =
                {
                    BaseOutputDirectory = baseDir,
                    FileNameConverters = options?.FileNameConverters ?? GeneratorOptions.DefaultFileNameConverters,
                    TypeNameConverters = options?.TypeNameConverters ?? GeneratorOptions.DefaultTypeNameConverters,
                    PropertyNameConverters = options?.PropertyNameConverters ?? GeneratorOptions.DefaultPropertyNameConverters,
                    EnumValueNameConverters = options?.EnumValueNameConverters ?? GeneratorOptions.DefaultEnumValueNameConverters,
                    EnumStringInitializersConverters = options?.EnumStringInitializersConverters ?? GeneratorOptions.DefaultEnumStringInitializersConverters,
                    ExplicitPublicAccessor = options?.ExplicitPublicAccessor ?? GeneratorOptions.DefaultExplicitPublicAccessor,
                    SingleQuotes = options?.SingleQuotes ?? GeneratorOptions.DefaultSingleQuotes,
                    TypeScriptFileExtension = options?.TypeScriptFileExtension?? GeneratorOptions.DefaultTypeScriptFileExtension,
                    TabLength = options?.TabLength ?? GeneratorOptions.DefaultTabLength,
                    UseTabCharacter = options?.UseTabCharacter ?? GeneratorOptions.DefaultUseTabCharacter,
                    CreateIndexFile = options?.CreateIndexFile ?? GeneratorOptions.DefaultCreateIndexFile,
                    CsNullableTranslation = options?.CsNullableTranslation ?? GeneratorOptions.DefaultCsNullableTranslation,
                    CsAllowNullsForAllTypes = options?.CsAllowNullsForAllTypes ?? GeneratorOptions.DefaultCsAllowNullsForAllTypes,
                    CsDefaultValuesForConstantsOnly = options?.CsDefaultValuesForConstantsOnly ?? GeneratorOptions.DefaultCsDefaultValuesForConstantsOnly,
                    DefaultValuesForTypes = options?.DefaultValuesForTypes ?? GeneratorOptions.DefaultDefaultValuesForTypes,
                    TypeUnionsForTypes = options?.TypeUnionsForTypes ?? GeneratorOptions.DefaultTypeUnionsForTypes,
                    CustomTypeMappings = options?.CustomTypeMappings?? GeneratorOptions.DefaultCustomTypeMappings,
                    EnumStringInitializers = options?.EnumStringInitializers ?? GeneratorOptions.DefaultEnumStringInitializers,
                    FileHeading = options?.FileHeading?? GeneratorOptions.DefaultFileHeading,
                    UseDefaultExport = options?.UseDefaultExport ?? GeneratorOptions.DefaultUseDefaultExport,
                    IndexFileExtension = options?.IndexFileExtension?? GeneratorOptions.DefaultIndexFileExtension,
                    ExportTypesAsInterfacesByDefault = options?.ExportTypesAsInterfacesByDefault?? GeneratorOptions.DefaultExportTypesAsInterfacesByDefault,
                    UseImportType = options?.UseImportType ?? GeneratorOptions.DefaultUseImportType,
                    TypeBlacklist = options?.TypeBlacklist ?? GeneratorOptions.DefaultTypeBlacklist,
                }
            };
            _ = generator.Generate(assembly);
            var files = directory.GetFiles().Select(x => File.ReadAllText(x.FullName));
            var result = files.Aggregate((a, b) => a + "\n\n" + b).Trim();

            directory.Delete(true);

            return result;
        }
    }
}
