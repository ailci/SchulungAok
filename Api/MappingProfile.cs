using AutoMapper;
using Domain.Entities;
using Service.Resolver;
using Shared.DataTransferObjects;

namespace Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Quote, QuoteOfTheDayDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorForCreateDto, Author>()
            .ForMember(dest => dest.Photo,
                opt =>
                {
                    opt.PreCondition(c => c.Photo is not null);

                    opt.MapFrom<FormFileToByteArrayResolver>();
                })
            .ForMember(dest => dest.PhotoMimeType,
                opt =>
                {
                    opt.PreCondition(c => c.Photo is not null);
                    opt.MapFrom(src => src.Photo!.ContentType);
                });
    }
}