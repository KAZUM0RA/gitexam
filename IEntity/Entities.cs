namespace VpuDotnet.Entities;
public interface IEntity
{
    Guid Id { get; set; } 
    DateTime CreatedAt { get; set; } 
}