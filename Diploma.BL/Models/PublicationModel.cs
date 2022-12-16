﻿namespace Diploma.BL.Models
{
    public class PublicationModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public string PublishingCity { get; set; }

        public string PublishingHouse { get; set; }

        public string Pages { get; set; }

        public string Organization { get; set; }

        public int? ConferenceId { get; set; }

        public int? DigestId { get; set; }
    }
}
