using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class DemandRepository : IDemandRepository
    {
        public Task<DemandDto> Create(DemandCreateDto demandCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DemandDto>> GetByCenter(long centerId)
        {
            throw new NotImplementedException();
        }

        public Task<DemandDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<DemandDto> Update(DemandDto demandDto)
        {
            throw new NotImplementedException();
        }
    }
}
