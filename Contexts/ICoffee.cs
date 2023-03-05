using VpuDotnet.Entities;
using System.Text.Json;
namespace VpuDotnet.Contexts;


public class CoffeeContext : IContext<Coffee>
{
    private string _fileNameCoffee = "Coffee.json";
    
    private List<Coffee> _coffee;
    public CoffeeContext()
    {
        if (!File.Exists(_fileNameCoffee))
        {
            File.Create(_fileNameCoffee);
        }
        var reader = new StreamReader(_fileNameCoffee);

        string fileContent = reader.ReadToEnd();
        reader.Close();
        if (fileContent.Length < 2)
        {
            _coffee = new List<Coffee>();
        }
        else
        {
            _coffee = JsonSerializer.Deserialize<List<Coffee>>(fileContent);
        }
    }
    public void Save()
    {
        string json = JsonSerializer.Serialize(_coffee);
        var write = new StreamWriter(_fileNameCoffee);
        write.Write(json);
        write.Close();
    }
    public void Create(Coffee entity)
    {
        _coffee.Add(entity);
    }

    public void Delete(Guid id)
    {
        _coffee.RemoveAll(coffee => coffee.Id == id);

    }

    public void Delete(Coffee entity)
    {
        Delete(entity.Id);
    }

    public IEnumerable<Coffee> GetAll()
    {
        
        return _coffee;

    }

    public void Update(Coffee entity)
    {
        var coffee = _coffee.FirstOrDefault(coffee => coffee.Id == entity.Id);
        if (coffee is null)
            throw new ArgumentException("error");
        coffee.CoffeeName = entity.CoffeeName;
        coffee.CoffeeType = entity.CoffeeType;
        coffee.Price = entity.Price;
        
    }
}