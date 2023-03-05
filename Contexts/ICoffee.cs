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

     public void PrintAllSortedByDate() 
     {
        for (int i = 0; i < _coffee.Count- 1; i++)
            for (int j = 0; j < _coffee.Count - i - 1; j++)
            {
                var cof1 = _coffee[j];
                var cof2 = _coffee[j + 1];
                if (cof1.CreatedAt > cof2.CreatedAt)
                {
                    _coffee[j] = cof2;
                    _coffee[j + 1] = cof1;
                }
            } 
        
        for (int i = 0; i < _coffee.Count; i++)
        {
            var NewCof = _coffee[i];
            Console.WriteLine(" ");
            Console.WriteLine(NewCof.CoffeeType);
            Console.WriteLine(NewCof.Price);
            Console.WriteLine(NewCof.Count);
            Console.WriteLine(NewCof.CreatedAt);
        }

    } 

    public void PrintAllSortedPrice()
    {
        for (int i = 0; i < _coffee.Count- 1; i++)
            for (int j = 0; j < _coffee.Count - i - 1; j++)
            {
                var cofnew = _coffee[j];
                var cofnext = _coffee[j + 1];
                if (cofnew.Price > cofnext.Price)
                {
                    _coffee[j] = cofnext;
                    _coffee[j + 1] = cofnew;
                }
            } 
        
        for (int i = 0; i < _coffee.Count; i++)
        {
            var cofnew = _coffee[i];
            Console.WriteLine(" ");
            Console.WriteLine(cofnew.CoffeeType);
            Console.WriteLine(cofnew.Count);
            Console.WriteLine(cofnew.Price);
        }
        
    }
    public int GetAllMoney()
    {
        int AllMoney = 0;
        foreach(var coffee in _coffee)
            AllMoney += coffee.Count * coffee.Price;
            
        return AllMoney;
        
    }
}