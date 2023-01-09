using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IAuthorRepository: IGenericRepository<Author>
    {
        public Task<IEnumerable<Author>> GetPublicationAuthors(string? filter);

        public Task AddPublicationAuthor(Author author);

        public Task<IEnumerable<AuthorType>> GetAuthorTypes(string? filter);

        public Task AddPublicationAuthor(int id, int authorId);

        public Task<PublicationAuthor?> GetPublicationAuthor(int publicationId);
    }
}
