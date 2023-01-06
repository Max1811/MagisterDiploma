using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess.Repositories.Contracts
{
    public interface IDigestRepository: IGenericRepository<Digest>
    {
        public Task<IEnumerable<Digest>> GetDigests(string? filter);

        public Task AddDigest(Digest digest);
    }
}
