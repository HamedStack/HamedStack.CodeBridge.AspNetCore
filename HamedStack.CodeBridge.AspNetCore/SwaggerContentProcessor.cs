using System.Text;
using System.Text.RegularExpressions;

namespace HamedStack.CodeBridge.AspNetCore
{
    public static class SwaggerContentProcessor
    {
        public static string ExtractClasses(string source)
        {
            var result = new StringBuilder();
            var matches = Regex.Matches(source, @"export.+class\s*(.+)[^\s](.*?\n)*?}");
            foreach (Match match in matches)
            {
                result.AppendLine(match.Value.Trim());
                result.AppendLine();

            }
            var content = result.ToString().Trim();
            return content;
        }
        public static string ExtractInterfaces(string source)
        {
            var result = new StringBuilder();
            var matches = Regex.Matches(source, @"export.+interface\s*(.+)[^\s](.*?\n)*?}");
            foreach (Match match in matches)
            {
                result.AppendLine(match.Value.Trim());
                result.AppendLine();

            }
            var content = result.ToString().Trim();
            return content;
        }
        public static string ExtractEnums(string source)
        {
            var result = new StringBuilder();
            var matches = Regex.Matches(source, @"export.+enum\s*(.+)[^\s](.*?\n)*?}");
            foreach (Match match in matches)
            {
                result.AppendLine(match.Value.Trim());
                result.AppendLine();

            }
            var content = result.ToString().Trim();
            return content;
        }

    }
}
