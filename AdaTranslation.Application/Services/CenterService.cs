
using AdaTranslation.Application.DTOs;
using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Domain.Interfaces;

namespace AdaTranslation.Application.Services
{
    public class CenterService : ICenterService
    {
        private readonly ICenterRepository _repository;

        public CenterService(ICenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CenterDto>> GetAllCentersAsync()
        {
            return await _repository.GetAll();
        }
 
    }
}
