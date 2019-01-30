using AutoMapper;
using Katil.Business.Entities.Models.User;
using Katil.Common.Utilities;
using Katil.Data.Model;

namespace Katil.Business.Services.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserRegistrationsRequest, User>();
            CreateMap<User, UserRegistrationResponse>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate.ToCmDateTimeString()))
                .ForMember(x => x.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate.ToCmDateTimeString()));
        }
    }
}
