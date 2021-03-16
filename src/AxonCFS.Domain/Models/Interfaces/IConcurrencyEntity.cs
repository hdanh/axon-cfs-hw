namespace AxonCFS.Domain.Models.Interfaces
{
    public interface IConcurrencyEntity
    {
        byte[] Tstamp { get; set; }
    }
}