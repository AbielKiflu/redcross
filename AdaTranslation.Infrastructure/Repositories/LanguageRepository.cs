using AdaTranslation.Application.Interfaces;
using AdaTranslation.Domain.Entities;
using AdaTranslation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdaTranslation.Infrastructure.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Language>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Languages.ToListAsync(cancellationToken);
        }

        public async Task<Language> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var language = await _context.Languages
                .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

            if (language == null)
                throw new KeyNotFoundException($"Language with ID {id} was not found.");

            return language;
        }
    }
}
