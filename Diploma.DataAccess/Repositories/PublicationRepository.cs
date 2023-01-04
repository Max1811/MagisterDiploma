using Diploma.DataAccess.Entities;
using Diploma.DataAccess.Repositories.Contracts;

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
    }
}
