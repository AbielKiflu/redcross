namespace AdaTranslation.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public ICollection<DemandDetail> DemandDetails { get; } = [];
    }
}
