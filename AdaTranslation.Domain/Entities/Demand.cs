using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Domain.Entities
{
    public class Demand
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DemandPriority Priority { get; set; } = DemandPriority.Normal;
        public DemandStatus Status { get; set; } = DemandStatus.Pending;
        public DemandType DemandType { get; set; } = DemandType.Site;
        public int? DemandedUserID { get; set; }
        public int CenterID { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }

        public User? DemandedUser { get; set; }
        public Center Center { get; set; } = null!;
        public User CreatedBy { get; set; } = null!;
        public ICollection<DemandDetail> DemandDetails { get; } = [];
    }
}
