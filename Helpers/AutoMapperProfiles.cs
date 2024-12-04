using AutoMapper;
using SampleApiController.DTOs;
using SampleApiController.Entities;

namespace SampleApiController.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>().ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
        CreateMap<Photo, PhotoDto>();
    }
}

