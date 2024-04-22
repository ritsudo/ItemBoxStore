using AutoFixture;
using AutoMapper;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.MapProfiles;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ItemBoxStore.UnitTests.Mappers
{
    public class UserProfileTests
    {

        private readonly IMapper _mapper;

        public UserProfileTests()
        {
            _mapper = new MapperConfiguration(
                configure => configure.AddProfile(new UserProfile())
                ).CreateMapper();
        }

        /// <summary>
        /// Проверка UserProfile
        /// </summary>
        [Fact]
        public void MapperConfigrationIsValid()
        {
            var profile = new UserProfile();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Проверка конвертации RegisterUserRequest в User
        /// </summary>
        [Fact]
        public void CheckUserProfileMapping_RegisterUserRequest_To_User()
        {
            var fixture = new Fixture();
            var request = fixture.Create<RegisterUserRequest>();

            var user = _mapper.Map<User>(request);

            user.ShouldNotBeNull();
            user.Login.ShouldBe(request.Login);
            user.Id.ShouldNotBe(Guid.Empty);
            user.CreatedAt.ShouldNotBe(default);
            
        }
    }
}
