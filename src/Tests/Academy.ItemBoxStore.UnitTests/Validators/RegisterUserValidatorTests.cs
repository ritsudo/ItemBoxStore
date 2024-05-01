using AutoFixture;
using FluentValidation.TestHelper;
using ItemBoxStore.Application.Validators;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.ItemBoxStore.UnitTests.Validators
{
    
    public class RegisterUserValidatorTests
    {
        /// <summary>
        /// Проверка валидации RegisterUserRequest
        /// </summary>
        [Fact]
        public void ShouldError_PasswordIsLessThan6()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, "Login")
                .With(x => x.Email, "test@test.com")
                .With(x => x.Phone, "+912312345678")
                .With(x => x.Name, "UserName")
                .With(x => x.Password, "12345")
                .With(x => x.ConfirmPassword, "12345")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                .Only();
        }

        /// <summary>
        /// Проверка валидации RegisterUserRequest
        /// </summary>
        [Fact]
        public void ShouldError_LoginIsUndefined()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, "")
                .With(x => x.Email, "test@test.com")
                .With(x => x.Phone, "+912312345678")
                .With(x => x.Name, "UserName")
                .With(x => x.Password, "12345678")
                .With(x => x.ConfirmPassword, "12345678")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Login)
                .Only();
        }
    }
}
