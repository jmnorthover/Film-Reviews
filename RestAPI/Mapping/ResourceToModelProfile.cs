using AutoMapper;
using RestAPI.Resources;
using RestAPI.Domain.Models;

namespace RestAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveReviewResource, Review>();
        }
    }
}
