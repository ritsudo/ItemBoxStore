using AutoMapper;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.MapProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<RegisterUserRequest, User>()
                .ForMember(s => s.Id, map => map.MapFrom(s => Guid.NewGuid()))
                .ForMember(s => s.CreatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.UpdatedAt, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(s => s.EmailConfirmed, map => map.MapFrom(s => false));
        }
    }
}
