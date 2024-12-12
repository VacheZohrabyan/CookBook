using System.Text.Json.Nodes;

namespace Cookbook.FileAccess;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) =>
        (fileFormat == FileFormat.Json) ? "json" : "txt";
}