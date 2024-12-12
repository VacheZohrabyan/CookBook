namespace Cookbook.DataAccess;

public abstract class StringsRepository : IStringsRepository
{ 
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToString(fileContents);
        }

        return new List<string>();
    }

    protected abstract List<string> TextToString(string fileContents);
    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, StringToText(strings));
    }
    protected abstract string StringToText(List<string> strings);
}
