namespace AxonCFS.Domain.Models
{
    public class Event : BaseEntity<string>
    {
        public int Number { get; set; }
    }
}