using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandSummaryDto
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DemandPriority Priority { get; set; }
        public DemandStatus Status { get; set; }
        public DemandType DemandType { get; set; }
        public DateTime CreatedDate { get; set; }
        public required string CreatedByUserName { get; set; }
        public string? CenterName { get; set; }
    }
}
