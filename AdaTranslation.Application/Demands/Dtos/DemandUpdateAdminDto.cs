using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.Demands.Dtos
{
    public class DemandUpdateAdmin
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DemandStatus Status { get; set; } = DemandStatus.Draft;
        public DemandType DemandType { get; set; } = DemandType.Site;
        public long DemandedUserId { get; set; }
    }
}
