using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandCreateDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DemandPriority Priority { get; set; } = DemandPriority.Normal;
        public DemandStatus Status { get; set; } = DemandStatus.Pending;
        public DemandType DemandType { get; set; } = DemandType.Site;
        public long? DemandedUserId { get; set; }
    }
}
