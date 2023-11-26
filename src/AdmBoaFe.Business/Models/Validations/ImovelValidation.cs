using FluentValidation;

namespace AdmBoaFe.Business.Models.Validations
{
    public class ImovelValidation : AbstractValidator<Imovel>
    {
        public ImovelValidation()
        {
            RuleFor(i => i.Nome)
                .NotEmpty()
                .WithMessage("O nome do imóvel deve ser fornecido.")
                .Length(2, 100)
                .WithMessage("O nome do imóvel deve ter entre 2 e 100 caracteres.");

            RuleFor(i => i.Descricao)
                .MaximumLength(255)
                .WithMessage("A descrição do imóvel não pode ter mais de 255 caracteres.");

            RuleFor(i => i.Imagem)
                .NotEmpty()
                .WithMessage("Uma imagem deve ser fornecida.");

            RuleFor(i => i.Valor)
                .GreaterThan(0)
                .WithMessage("O valor do imóvel deve ser maior que zero.");

            RuleFor(i => i.DataCadastro)
                .NotEmpty()
                .WithMessage("A data de cadastro do imóvel deve ser fornecida.");

            RuleFor(i => i.Ativo)
                .NotNull()
                .WithMessage("O campo Ativo deve ser fornecido.");
        }
    }
}
