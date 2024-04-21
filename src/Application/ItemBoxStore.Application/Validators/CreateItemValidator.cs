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
                .Length(1,30)
                .Must(s => s.All(char.IsLetter));

            RuleFor(x => x.SubCategoryId)
                .NotNull()
                .GreaterThan(0)
                .LessThan(90);

            RuleFor(x => x.Description)
                .Length(1, 500);

            RuleFor(x => x.Location)
                .Length(1, 50);

            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThan(0)
                .LessThan(100000000);
        }
    }
}
