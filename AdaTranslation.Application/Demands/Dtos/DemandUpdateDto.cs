using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandUpdate
    {
        public long Id { get; set; }
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DemandPriority Priority { get; set; } = DemandPriority.Normal;
        public DemandStatus Status { get; set; } = DemandStatus.Pending;
        public DemandType DemandType { get; set; } = DemandType.Site;
        public long? DemandedUserId { get; set; }
    }
}
