using PropertyApp.Model;

namespace PropertyApp.JsonReadWrite;

public class JsonHandler<T> : IJsonHandler<T> where T : IModel
{
    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    // TODO: Learn how to optimise for LINQ pipeline
    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }
}
