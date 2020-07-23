using AutoMapper;
using RestAPI.Domain.Models;
using RestAPI.Resources;

namespace RestAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Review, ReviewResource>();
        }
    }
}
