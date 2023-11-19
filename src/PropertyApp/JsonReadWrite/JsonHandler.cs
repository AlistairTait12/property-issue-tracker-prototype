using PropertyApp.Model;
using System.Text.Json;

namespace PropertyApp.JsonReadWrite;

public class JsonHandler<T> : IJsonHandler<T> where T : IModel
{
    private readonly string _fullPath;

    public JsonHandler(string basePath)
    {
        _fullPath = Path.Combine(basePath, $"{typeof(T).Name}s.json");

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        if (!File.Exists(_fullPath))
        {
            File.Create(_fullPath);
        }

        using var fileStream = new FileStream(_fullPath, FileMode.Open, FileAccess.ReadWrite);
        using var streamReader = new StreamReader(fileStream);
        var fileContents = streamReader.ReadToEnd();

        if (fileContents.Length < 0)
        {
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("[]");
        }
    }

    // TODO: in reality, it probably would be a bit inefficient to read the whole file to edit one record
    public T GetById(int id)
    {
        VerifyFilePath();

        var result = GetAll().FirstOrDefault(model => model.Id == id);

        if (result is null)
        {
            // TODO: What is actually the purpose of throwing here?
            // How should not finding the model be dealt with?
            throw new KeyNotFoundException(
                $"Model in collection {typeof(T).Name}s with {nameof(IModel.Id)} of {id} does not exist");
        }

        return result;
    }

    // TODO: Learn how to optimise for LINQ pipeline
    public IEnumerable<T> GetAll()
    {
        VerifyFilePath();

        using var streamReader = new StreamReader(_fullPath);
        var rawJson = streamReader.ReadToEnd();
        var collection = JsonSerializer.Deserialize<IEnumerable<T>>(rawJson);

        return collection;
    }
    // TODO: Json Writing, or is that another class?
    // TODO: It shouldn't be reading and writing at the same time (at least not the same record)

    public async Task AddAsync(T entity)
    {
        VerifyFilePath();

        using var streamReader = new StreamReader(_fullPath);
        var fileContents = await streamReader.ReadToEndAsync();
        streamReader.Dispose();

        var collection = fileContents == string.Empty
            ? new List<T>()
            : JsonSerializer.Deserialize<List<T>>(fileContents);

        entity.Id = collection.Any()
            ? collection.OrderBy(entity => entity.Id).Last().Id + 1
            : 1;

        collection.Add(entity);

        var json = JsonSerializer.Serialize(collection,
            new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreReadOnlyProperties = true,
            });

        await File.WriteAllTextAsync(_fullPath, json);
    }

    private void VerifyFilePath()
    {
        if (!File.Exists(_fullPath))
        {
            throw new FileNotFoundException(
                $"File for model type {typeof(T).Name} does not exist in storage");
        }
    }
}
