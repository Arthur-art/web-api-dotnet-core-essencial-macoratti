using FluentValidation;
using web_api_catalog.Models;

namespace web_api_catalog.Validators;

public class ProductValidator : AbstractValidator<ProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome do produto é obrigatório.")
            .MaximumLength(80).WithMessage("O produto deve ter no máximo 80 caracteres.");
        RuleFor(x => x.Description)
                  .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                  .MaximumLength(300).WithMessage("A descrição deve ter no máximo 300 caracteres.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("O preço do produto é obrigatório.")
            .GreaterThan(0).WithMessage("O preço deve ser um valor positivo.");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("A imagem do produto é obrigatória.")
            .MaximumLength(300).WithMessage("A URL da imagem deve ter no máximo 300 caracteres.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("O ID da categoria deve ser um valor positivo.");
    }
}
