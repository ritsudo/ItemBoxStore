using FluentValidation;
using ItemBoxStore.Contracts.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Validators
{
    public class CreateItemValidator : AbstractValidator<CreateItemRequest>
    {
        public CreateItemValidator() 
        { 
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Введите название")
                .Length(3,30).WithMessage("Длина должна быть от 3 до 30 символов")
                .Must(s => s.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsDigit(c))).WithMessage("Допускаются буквы, цифры, пробелы");

            RuleFor(x => x.SubCategoryId)
                .NotNull().WithMessage("Укажите категорию")
                .GreaterThan(0)
                .LessThan(11);

            RuleFor(x => x.Description)
                .Length(1, 500).WithMessage("Допускается описание от 1 до 500 символов");

            RuleFor(x => x.Location)
                .Length(1, 50).WithMessage("Длина адреса от 1 до 50 символов");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Стоимость не указана")
                .GreaterThan(0).WithMessage("Стоимость должна быть больше 0")
                .LessThan(100000000).WithMessage("Стоимость должна быть меньше 100000000");
        }
    }
}
