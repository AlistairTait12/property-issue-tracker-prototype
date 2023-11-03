using PropertyApp.Model;

namespace PropertyApp.JsonReadWrite;

public interface IJsonHandler<T> where T : IModel
{
    T GetById(int id);

    IEnumerable<T> GetAll();
}
