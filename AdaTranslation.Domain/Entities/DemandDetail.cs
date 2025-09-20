namespace AdaTranslation.Domain.Entities
{
    public class DemandDetail
    {
        public int Id { get; set; }
        public int DemandId { get; set; }
        public int ServiceId { get; set; }
        public required string ResponsiblePersonEmail { get; set; }
        public required string Message { get; set; }
        public int Duration { get; set; }
        public long CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public Demand Demand { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}