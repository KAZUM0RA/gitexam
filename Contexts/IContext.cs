using VpuDotnet.Entities;
namespace VpuDotnet.Contexts;

public interface IContext<T> where T : IEntity
{

    void Create(T entity);

    void Update(T entity);

    void Delete(Guid id);

    void Delete(T entity);
    
    IEnumerable<T> GetAll();
}