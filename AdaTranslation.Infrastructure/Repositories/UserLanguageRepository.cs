using AdaTranslation.Application.Common.Interfaces;
using AdaTranslation.Application.Features.UserLanguages.Dtos;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

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
            bool exists = await _context.UserLanguages
                .AnyAsync(ul =>
                    ul.UserId == createUserLanguage.UserId &&
                    ul.LanguageId == createUserLanguage.LanguageId,
                    cancellationToken);

            if (exists)
                return; // skip duplicate

            var userLanguage = new UserLanguage(createUserLanguage.UserId, createUserLanguage.LanguageId);

            await _context.UserLanguages.AddAsync(userLanguage, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(UserLanguageUpdateDto updateUserLanguage, CancellationToken cancellationToken)
        {
            var userLanguage = await _context.UserLanguages
                .FindAsync(new object[] { updateUserLanguage.Id }, cancellationToken);

            if (userLanguage == null)
                throw new KeyNotFoundException($"UserLanguage with Id {updateUserLanguage.Id} not found");

            userLanguage.Update(updateUserLanguage.UserId, updateUserLanguage.LanguageId);

            _context.UserLanguages.Update(userLanguage);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _context.UserLanguages.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return;

            _context.UserLanguages.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SyncUserLanguagesAsync(long userId, List<int> newLanguageIds, CancellationToken cancellationToken)
        {
            // Load current associations
            var existingUserLanguages = await _context.UserLanguages
                .Where(ul => ul.UserId == userId)
                .ToListAsync(cancellationToken);

            var existingIds = existingUserLanguages.Select(ul => ul.LanguageId).ToList();
            var toAdd = newLanguageIds.Except(existingIds).ToList();
            var toRemove = existingUserLanguages.Where(ul => !newLanguageIds.Contains(ul.LanguageId)).ToList();

            // Add new
            foreach (var langId in toAdd)
            {
                await _context.UserLanguages.AddAsync(new UserLanguage(userId, langId)
                , cancellationToken);
            }

            // Remove deselected
            if (toRemove.Any())
                _context.UserLanguages.RemoveRange(toRemove);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
