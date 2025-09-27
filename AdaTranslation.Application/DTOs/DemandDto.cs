using AdaTranslation.Domain.Enums;

namespace AdaTranslation.Application.DTOs
{
    public record DemandDto(
     long Id,
     string Description,
     DateTime StartDate,
     DateTime FinishDate,
     DemandPriority Priority,
     DemandStatus Status,
     DemandType DemandType,
     long? DemandedUserId,
     int CenterId,
     long CreatedById,
     DateTime CreatedDate
 );

}


