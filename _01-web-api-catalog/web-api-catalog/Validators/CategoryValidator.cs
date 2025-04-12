using FluentValidation;
using web_api_catalog.Models;

namespace web_api_catalog.Validators;

public class CategoryValidator : AbstractValidator<CategoryDto>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.");
    }
}
