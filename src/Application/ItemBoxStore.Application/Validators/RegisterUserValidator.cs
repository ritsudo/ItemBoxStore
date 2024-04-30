using FluentValidation;
using ItemBoxStore.Contracts.Users;

namespace ItemBoxStore.Application.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequestWithCaptcha>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Login)
                .NotEmpty().WithMessage("Введите логин")
                .MinimumLength(3).WithMessage("Логин должен содержать минимум 3 символа")
                .MaximumLength(30).WithMessage("Логин должен содержать не более 30 символов");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Введите адрес электронной почты")
                .EmailAddress().WithMessage("Неправильный e-mail");

            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Введите имя пользователя")
                .MinimumLength(3).WithMessage("Имя должно содержать минимум 3 символа")
                .MaximumLength(30).WithMessage("Имя должно содержать не более 30 символов");

            RuleFor(user => user.Phone)
                .NotEmpty().WithMessage("Введите телефонный номер пользователя")
                .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$")
                .WithMessage("Неправильный номер телефона");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Введите пароль")
                .MinimumLength(6).WithMessage("Пароль должен содержать минимум 6 символов");

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty().WithMessage("Требуется подтверждение пароля")
                .Equal(user => user.Password).WithMessage("Пароли должны совпадать");

        }
    }
}
