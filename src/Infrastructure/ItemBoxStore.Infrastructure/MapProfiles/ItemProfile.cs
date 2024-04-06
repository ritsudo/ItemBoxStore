using AutoMapper;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ItemBoxStore.Contracts.Items.CreateItem;

namespace ItemBoxStore.Infrastructure.MapProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>();
        }
    }
}
