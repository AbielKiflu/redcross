using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandSummaryDto
    {
        public long Id { get; set; }
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public DemandPriority Priority { get; set; }
        public DemandStatus Status { get; set; }
        public DemandType DemandType { get; set; }
        public DateTime CreatedDate { get; set; }
        public required string CreatedByUserName { get; set; }
        public string? CenterName { get; set; }
    }
}
