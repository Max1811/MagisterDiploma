using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Diploma.DataAccess.Repositories
{
    public class PublicationRepository: GenericRepository<Publication>, IPublicationRepository
    {
        private DataContext _dataContext;

        public PublicationRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Publication>> GetPublications(string? filter, int? pageNumber, int? pageSize)
        {
            Expression<Func<Publication, bool>> predicate = string.IsNullOrEmpty(filter)
                ? p => true
                : p => p.Name.Contains(filter)
                    || p.PublishingCity.Contains(filter)
                    || p.PublishingHouse.Contains(filter)
                    || p.Type.Type.Contains(filter)
                    || p.Organization.Contains(filter)
                    || p.Category.Contains(filter)
                    || p.Link.Contains(filter)
                    || p.Pages.Contains(filter)
                    || (p.Conference != null && p.Conference.ConferenceType.Type.Contains(filter))
                    || (p.Conference != null && p.Conference.Name.Contains(filter))
                    || (p.Conference != null && p.Conference.ConferenceCity.Contains(filter))
                    || (p.Digest != null && p.Digest.Name.Contains(filter))
                    || (p.Digest != null && p.Digest.Type.Contains(filter));

            //conference, digest, author filtering needed

            var filteredPublications = _dataContext
                .Publications
                .Include(p => p.Conference)
                .Include(p => p.Digest)
                .Include(p => p.Type)
                .Include(p => p.PublicationAuthors)
                .Where(predicate)
                .AsEnumerable();

            if(pageNumber != null && pageSize != null)
                filteredPublications = filteredPublications
                    .Skip((pageNumber.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return filteredPublications;
        }
    }
}
