using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.DTOs
{
    public record DemandCreateDto
    {
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime FinishDate { get; init; }
        public DemandPriority Priority { get; init; } = DemandPriority.Normal;
        public DemandStatus Status { get; init; } = DemandStatus.Pending;
        public DemandType DemandType { get; init; } = DemandType.Site;
        public long? DemandedUserId { get; init; }
        public int CenterId { get; init; }
        public long CreatedById { get; init; }
    }


}


