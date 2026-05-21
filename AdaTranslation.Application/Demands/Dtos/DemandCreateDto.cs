using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandCreateDto
    {
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DemandPriority Priority { get; set; } = DemandPriority.Low;
        public DemandStatus Status { get; set; } = DemandStatus.Draft;
        public DemandType DemandType { get; set; } = DemandType.Site;
        public long? DemandedUserId { get; set; }
    }
}
