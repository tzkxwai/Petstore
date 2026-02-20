using FluentValidation;
using BaseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTest.Validators
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0);

            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(p => p.Status)
                .Must(s => s == "available" || s == "pending" || s == "sold")
                .WithMessage("Status must be available, pending or sold");

            RuleFor(p => p.Category)
                .NotNull();

            RuleFor(p => p.Category.Name)
                .NotEmpty();
        }
    }
}