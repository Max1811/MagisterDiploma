namespace LoginForm.DataAccess.Entities
{
    public class Publication : BaseEntity
    {
        public string Name { get; set; }

        public int TypeId { get; set; }

        public int ConferenceId { get; set; }

        public int DigestId { get; set; }

        public string PublishingCity { get; set; }

        public string PublishingHouse { get; set; }

        public string Pages { get; set; }

        public string Organization { get; set; }

        public PublicationType Type { get; set; }

        public Conference Conference { get; set; }

        public Digest Digest { get; set; }

        public List<PublicationAuthor> PublicationAuthors { get; set; }
    }
}
