using AutoFixture;
using FluentValidation.TestHelper;
using ItemBoxStore.Application.Validators;
using ItemBoxStore.Contracts.Items;

namespace Academy.ItemBoxStore.UnitTests.Validators
{
    public class CreateItemValidatorTests
    {
        /// <summary>
        /// Проверка валидации CreateItemRequest
        /// </summary>
        [Theory]
        [InlineData("")]
        [InlineData("qq")]
        [InlineData("<>")]
        [InlineData("QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ")]
        public void ShouldError_NameIsIncorrct(string itemName)
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<CreateItemRequest>()
                .With(x => x.Name, itemName)
                .With(x => x.SubCategoryId, 10)
                .With(x => x.Description, "Description")
                .With(x => x.Location, "Test City")
                .With(x => x.Price, 10)
                .Create();

            var validator = new CreateItemValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .Only();
        }

        /// <summary>
        /// Проверка валидации CreateItemRequest
        /// </summary>
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

        /// <summary>
        /// Проверка валидации CreateItemRequest
        /// </summary>
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
