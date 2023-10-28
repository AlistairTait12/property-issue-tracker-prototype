using PropertyApp.Model;
using System.Text.Json;

namespace PropertyApp.JsonReadWrite;

public class JsonHandler<T> : IJsonHandler<T> where T : IModel
{
    private readonly string _fullPath;

    public JsonHandler(string folderPath)
    {
        var fileNameForModel = $"{typeof(T).Name}s.json";
        _fullPath = Path.Combine(folderPath, fileNameForModel);
    }

    public T GetById(int id)
    {
        var result = GetAll().FirstOrDefault(model => model.Id == id);

        if (result == null)
        {
            throw new KeyNotFoundException($"Model in collection {typeof(T).Name}s with Id of {id} does not exist");
        }

        return result;
    }

    // TODO: Learn how to optimise for LINQ pipeline
    public IEnumerable<T> GetAll()
    {
        using var sr = new StreamReader(_fullPath);
        var raw = sr.ReadToEnd();
        var collection = JsonSerializer.Deserialize<IEnumerable<T>>(raw);

        return collection;
    }
}
