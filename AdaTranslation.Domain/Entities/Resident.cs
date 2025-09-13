namespace AdaTranslation.Domain.Entities
{
    public class Resident
    {
        public int ID { get; set; }
        public required string FullName { get; set; }
        public required string Badge { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Nationality { get; set; }
        public ICollection<DemandDetail> DemandDetails { get; } = [];
    }
}
