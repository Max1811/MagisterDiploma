using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private DataContext _dataContext;

        public AuthorRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddPublicationAuthor(Author author)
        {
            if (!_dataContext.Authors.Any(a => a.Name == author.Name && a.LastName == author.LastName && a.Patronymic == author.Patronymic))
            {
                await AddAsync(author);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AuthorType>> GetAuthorTypes(string? filter)
        {
            Expression<Func<AuthorType, bool>> predicate = string.IsNullOrEmpty(filter)
                ? p => true
                : p => p.Type.Contains(filter);

            return await _dataContext.AuthorTypes
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetPublicationAuthors(string? filter)
        {
            Expression<Func<Author, bool>> predicate = string.IsNullOrEmpty(filter)
                ? p => true
                : p => p.Name.Contains(filter)
                    || p.LastName.Contains(filter)
                    || p.Patronymic.Contains(filter) 
                    || p.AuthorType.Type.Contains(filter);

            return await _dataContext.Authors
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task AddPublicationAuthor(int id, int authorId)
        {
            await _dataContext.PublicationAuthors.AddAsync(new PublicationAuthor { PublicationId = id, AuthorId = authorId });

            await _dataContext.SaveChangesAsync();
        }
    }
}
