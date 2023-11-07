using Microsoft.Extensions.Options;
using PropertyApp.Model;
using System.Text.Json;
using System.Xml.Serialization;

namespace PropertyApp.JsonReadWrite;

public class JsonHandler<T> : IJsonHandler<T> where T : IModel
{
    private readonly string _fullPath;

    public JsonHandler(IOptions<StorageOptions> options)
    {
        // TODO: Figure out how to dynamically resolve location on a per device basis.
        // It is highly likely that the path here is specific to the device I am emulating
        var basePath = options.Value.StorageBasePath;
        var fileNameForModel = $"{typeof(T).Name}s.json";
        _fullPath = Path.Combine(basePath, fileNameForModel);
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

    private void VerifyFilePath()
    {
        if (!File.Exists(_fullPath))
        {
            throw new FileNotFoundException(
                $"File for model type {typeof(T).Name} does not exist in storage");
        }
    }
}
