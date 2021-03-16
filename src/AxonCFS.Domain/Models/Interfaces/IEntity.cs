namespace AxonCFS.Domain.Models.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}