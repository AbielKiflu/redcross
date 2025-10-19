using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.UserLanguages.Dtos;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class UserLanguageRepository : IUserLanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public UserLanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserLanguageCreateDto createUserLanguage, CancellationToken cancellationToken)
        {
            var userLanguage = new UserLanguage()
            {
                UserId = createUserLanguage.UserId,
                LanguageId = createUserLanguage.LanguageId
            };
            var result = await _context.UserLanguages.AddAsync(userLanguage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserLanguageUpdateDto updateUserLanguage, CancellationToken cancellationToken)
        {
            var userLanguage = new UserLanguage()
            {
                Id = updateUserLanguage.Id,
                UserId = updateUserLanguage.UserId,
                LanguageId = updateUserLanguage.LanguageId
            };

            _context.UserLanguages.Update(userLanguage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            _context.Remove(Id);
            await Task.CompletedTask;
        }
    }
}
