using AutoMapper;
using Diploma.API.Models;
using Diploma.BL.Models;
using Diploma.DataAccess.Entities;

namespace Diploma.API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpDto, SignUpModel>();
            CreateMap<SignUpModel, User>();

            CreateMap<ChangePasswordDto, ChangePasswordModel>();

            CreateMap<PublicationDto, PublicationModel>();
            CreateMap<PublicationModel, Publication>();

            CreateMap<ConferenceDto, ConferenceModel>();
            CreateMap<ConferenceModel, Conference>();

            CreateMap<PublicationTypeDto, PublicationTypeModel>();
            CreateMap<PublicationTypeModel, PublicationType>();
        }
    }
}
