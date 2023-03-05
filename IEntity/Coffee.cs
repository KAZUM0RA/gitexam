namespace VpuDotnet.Entities;
public class Coffee : IEntity 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } 
    public string? CoffeeName { get; set; }
    public string? CoffeeType { get; set; }
    public int Count { get; set; }
    public string? Price {get; set;}

}