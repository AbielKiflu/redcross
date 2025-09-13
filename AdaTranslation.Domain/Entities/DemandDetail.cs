namespace AdaTranslation.Domain.Entities
{
    public class DemandDetail
    {
        public int ID { get; set; }
        public int DemandID { get; set; }
        public int ServiceID { get; set; }
        public required string ResponsiblePersonEmail { get; set; }
        public required string Message { get; set; }
        public int Duration { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Demand Demand { get; set; } = null!;
        public Service Service { get; set; } = null!;
        public User CreatedBy { get; set; } = null!;
    }
}