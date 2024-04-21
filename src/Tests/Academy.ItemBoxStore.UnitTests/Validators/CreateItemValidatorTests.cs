using AutoFixture;
using FluentValidation.TestHelper;
using ItemBoxStore.Application.Validators;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ItemBoxStore.UnitTests.Validators
{
    public class CreateItemValidatorTests
    {
        [Fact]
        public void ShouldError_PriceEquals0()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateItemRequest>()
                .With(x => x.Name, "Name")
                .With(x => x.SubCategoryId, 10)
                .With(x => x.Description, "Description")
                .With(x => x.Location, "Test City")
                .With(x => x.Price, 0)
                .Create();

            var validator = new CreateItemValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Price)
                .Only();
        }

        [Fact]
        public void ShouldError_NameIsNull()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateItemRequest>()
                .With(x => x.Name, "")
                .With(x => x.SubCategoryId, 10)
                .With(x => x.Description, "Description")
                .With(x => x.Location, "Test City")
                .With(x => x.Price, 100)
                .Create();

            var validator = new CreateItemValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .Only();
        }
    }
}
