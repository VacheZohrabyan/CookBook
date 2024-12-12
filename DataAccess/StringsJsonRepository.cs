using System.Text.Json;
namespace Cookbook.DataAccess;


public class StringsJsonRepository : StringsRepository
{
    protected override string StringToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToString(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}