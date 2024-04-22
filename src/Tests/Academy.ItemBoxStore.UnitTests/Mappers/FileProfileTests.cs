using AutoFixture;
using AutoMapper;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Items;
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
    public class FileProfileTests
    {

        private readonly IMapper _mapper;

        public FileProfileTests()
        {
            _mapper = new MapperConfiguration(
                configure => configure.AddProfile(new StorageFileProfile())
                ).CreateMapper();
        }

        /// <summary>
        /// Проверка валидности профиля StorageFileProfile
        /// </summary>
        [Fact]
        public void MapperConfigrationIsValid()
        {
            var profile = new StorageFileProfile();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            mapper.AssertConfigurationIsValid();
        }

    }
}
