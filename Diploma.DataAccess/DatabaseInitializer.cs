using Diploma.DataAccess.Entities;

namespace Diploma.DataAccess
{
    public static class DatabaseInitializer
    {
        public static IEnumerable<PublicationType> InitializePublicationTypes()
        {
            return new List<PublicationType>
            {
                new PublicationType
                {
                    Id = 1,
                    Type = "Теза"
                },
                new PublicationType
                {
                    Id = 2,
                    Type = "Стаття"
                }
            };
        }

        public static IEnumerable<ConferenceType> InitializeConferenceTypes()
        {
            return new List<ConferenceType>
            {
                new ConferenceType
                {
                    Id = 1,
                    Type = "Всеукраїнська"
                },
                new ConferenceType
                {
                    Id = 2,
                    Type = "Регіональна"
                },
                new ConferenceType
                {
                    Id = 3,
                    Type = "Міжнародна"
                }
            };
        }

        public static IEnumerable<AuthorType> InitializeAuthorTypes()
        {
            return new List<AuthorType>
            {
                new AuthorType
                {
                    Id = 1,
                    Type = "Студент"
                },
                new AuthorType
                {
                    Id = 2,
                    Type = "Викладач"
                }
            };
        }
    }
}
