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
        /// Проверка валидации RegisterUserRequest - логин некорректен
        /// </summary>
        [Theory]
        [InlineData("")]
        [InlineData("QQ")]
        [InlineData("Q Q Q")]
        [InlineData("1")]
        [InlineData("TestUser<New>")]
        public void ShouldError_LoginIsIncorrect(string loginString)
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, loginString)
                .With(x => x.Email, "test@test.com")
                .With(x => x.Phone, "+912312345678")
                .With(x => x.Name, "UserName")
                .With(x => x.Password, "12345Qq")
                .With(x => x.ConfirmPassword, "12345Qq")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Login)
                .Only();
        }


        /// <summary>
        /// Проверка валидации RegisterUserRequest - пароль меньше 6 знаков
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
        /// Проверка валидации RegisterUserRequest - Введён некорректный E-mail 
        /// </summary>
        [Fact]
        public void ShouldError_EmailIsIncorrect()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, "Login")
                .With(x => x.Email, "test@te")
                .With(x => x.Phone, "+912312345678")
                .With(x => x.Name, "UserName")
                .With(x => x.Password, "123456Qq")
                .With(x => x.ConfirmPassword, "123456Qq")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .Only();
        }

        /// <summary>
        /// Проверка валидации RegisterUserRequest - Имя
        /// </summary>
        [Fact]
        public void ShouldError_NameIsIncorrect()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, "Login")
                .With(x => x.Email, "test@test.com")
                .With(x => x.Phone, "+912312345678")
                .With(x => x.Name, "Вася 3 устройства")
                .With(x => x.Password, "123456Qq")
                .With(x => x.ConfirmPassword, "123456Qq")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .Only();
        }

        /// <summary>
        /// Проверка валидации RegisterUserRequest - Телефон
        /// </summary>
        [Fact]
        public void ShouldError_PhoneIsIncorrect()
        {
            //Arrange
            var fixture = new Fixture();
            var query = fixture.Build<RegisterUserRequestWithCaptcha>()
                .With(x => x.Login, "Login")
                .With(x => x.Email, "test@test.com")
                .With(x => x.Phone, "678")
                .With(x => x.Name, "Вася")
                .With(x => x.Password, "123456Qq")
                .With(x => x.ConfirmPassword, "123456Qq")
                .Create();

            var validator = new RegisterUserValidator();

            //Act
            var result = validator.TestValidate(query);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Phone)
                .Only();
        }

        /// <summary>
        /// Проверка валидации RegisterUserRequest - логин не указан
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
