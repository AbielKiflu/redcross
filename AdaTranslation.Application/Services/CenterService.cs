
using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;

namespace AdaTranslation.Application.Services
{
    public class CenterService
    {
        private readonly ICenterRepository _repository;

        public CenterService(ICenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Center>> GetAllCentersAsync()
        {
            return await _repository.GetAll();
        }
 
    }
}
