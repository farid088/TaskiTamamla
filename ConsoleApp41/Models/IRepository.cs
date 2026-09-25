public interface IRepository<T>
{
  void Add(T entity);
    void GetById(int id);
    void GetAll();
    void Update(T entity);
    void Delete(int id);
}
public class Repository<T> : IRepository<T>
{
    private List<T> entities = new List<T>();
    public void Add(T entity)
    {
        entities.Add(entity);
        Console.WriteLine($"Entity of type {typeof(T).Name} added successfully.");
    }
    public void GetById(int id)
    {
        var entity = entities.FirstOrDefault(e => e.GetHashCode() == id);
        if (entity != null)
        {
            Console.WriteLine($"Entity of type {typeof(T).Name} with ID {id} found.");
        }
        else
        {
            Console.WriteLine($"Entity of type {typeof(T).Name} with ID {id} not found.");
        }
    }
    public void GetAll()
    {
        Console.WriteLine($"Retrieving all entities of type {typeof(T).Name}:");
        foreach (var entity in entities)
        {
            Console.WriteLine(entity);
        }
    }
    public void Update(T entity)
    {
        var existingEntity = entities.FirstOrDefault(e => e.Equals(entity));
        if (existingEntity != null)
        {
            entities.Remove(existingEntity);
            entities.Add(entity);
            Console.WriteLine($"Entity of type {typeof(T).Name} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Entity of type {typeof(T).Name} not found for update.");
        }
    }
    public void Delete(int id)
    {
        var entity = entities.FirstOrDefault(e => e.GetHashCode() == id);
        if (entity != null)
        {
            entities.Remove(entity);
            Console.WriteLine($"Entity of type {typeof(T).Name} with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Entity of type {typeof(T).Name} with ID {id} not found for deletion.");
        }
    }
}