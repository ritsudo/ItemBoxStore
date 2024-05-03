using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiIntegrationTests
{
    public class ItemRepositoryStub : IItemRepository
    {
        public Task AddAsync(Item itemDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDtoDetailed> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, Expression<Func<Item, object>> orderByExpression, CancellationToken cancellationToken)
        {
            var result = new GetAllResponseWithPagination<ItemDto>();

            result.TotalPages = 1;
            var queryResult = 
                new[] {
                    new ItemDto {
                        Name = "test",
                        SubCategoryId = 5,
                        Location = "test",
                        Price = 5,
                        MainImageId = new Guid()
                    }
                };

            result.Result = queryResult;

            return Task.FromResult(result);
        }

        public Task<IEnumerable<ItemDto>> GetItemsByNameAsync(GetItemsByNameRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemDto>> GetItemsBySpecificationAsync(Specification<Item> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ModifyImage(ModifyImageRequest model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
