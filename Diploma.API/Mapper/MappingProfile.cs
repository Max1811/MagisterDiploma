using AutoMapper;
using Diploma.API.Models;
using Diploma.API.Models.Request;
using Diploma.API.Models.Response;
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

            CreateMap<ConferenceModel, ConferenceDto>();
            CreateMap<Conference, ConferenceModel>();

            CreateMap<ConferenceTypeResponseDto, ConferenceTypeModel>();
            CreateMap<ConferenceTypeModel, ConferenceType>();

            CreateMap<ConferenceTypeModel, ConferenceTypeResponseDto>();
            CreateMap<ConferenceType, ConferenceTypeModel>();

            CreateMap<PublicationTypeDto, PublicationTypeModel>();
            CreateMap<PublicationTypeModel, PublicationType>();

            CreateMap<PublicationTypeModel, PublicationTypeDto>();
            CreateMap<PublicationType, PublicationTypeModel>();

            CreateMap<DigestRequestDto, DigestModel>();
            CreateMap<DigestModel, Digest>();

            CreateMap<DigestModel, DigestRequestDto>();
            CreateMap<Digest, DigestModel>();

            CreateMap<AuthorRequestDto, AuthorModel>();
            CreateMap<AuthorModel, Author>();

            CreateMap<AuthorModel, AuthorRequestDto>();
            CreateMap<Author, AuthorModel>();

            CreateMap<AuthorTypeModel, AuthorTypeResponseDto>();
            CreateMap<AuthorType, AuthorTypeModel>();

            CreateMap<AuthorTypeResponseDto, AuthorTypeModel>();
            CreateMap<AuthorTypeModel, Author>();
        }
    }
}
