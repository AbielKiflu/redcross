using AdaTranslation.Application.DTOs;

namespace AdaTranslation.Application.Interfaces
{
    /// <summary>
    ///  Manipulate demands, a demand can be created or updated by the admin or demander
    /// </summary>
    public interface IDemandRepository
    {
        Task<DemandDto> GetById(long id);
        Task<IEnumerable<DemandDto>> GetByCenter(long centerId);
        Task Delete(long id);
        Task<DemandDto> Update(DemandDto demandDto);
        Task<DemandDto> Create(DemandCreateDto demandCreateDto);
    }
}
